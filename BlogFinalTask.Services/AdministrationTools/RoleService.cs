using BlogFinalTask.Data.Models;
using BlogFinalTask.Data.Models.HelperModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BlogFinalTask.Services.AdministrationTools
{
    public class RoleService
    {
        private readonly UserManager<CustomIdentity> _userManager;
        private readonly RoleManager<CustomRole> _roleManager;
        private ClaimsService? _claimsService;

        public RoleService(UserManager<CustomIdentity> userManager, RoleManager<CustomRole> roleManager) {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        /// <summary>
        /// Устанавливает базовую роль "User"
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task AssignBaseRole(CustomIdentity user) {
            //Setting base role
            var roleId = await _roleManager.Roles.FirstOrDefaultAsync(i => i.Name == "User");
            if (roleId != null) {
                await _userManager.AddToRoleAsync(user, "User");
            }
        }

        /// <summary>
        /// Апдейтит роль для конкретного юзера
        /// </summary>
        /// <param name="user"></param>
        /// <param name="userTransferModel"></param>
        /// <returns></returns>
        public async Task UpdateUserRole(CustomIdentity user, CustomUserTransferModel userTransferModel) {
            var rolesList = await _userManager.GetRolesAsync(user!);
            string roleToUpdate = rolesList.FirstOrDefault()!.ToString();

            if (user != null) {
                user.UserName = userTransferModel.UserName;
                if (roleToUpdate != userTransferModel.UserRole) {
                    await _userManager.RemoveFromRoleAsync(user, roleToUpdate);
                    await _userManager.AddToRoleAsync(user, userTransferModel.UserRole);
                }
            }
        }

        /// <summary>
        /// Создает роль при залогиненом юзере
        /// </summary>
        /// <param name="user"></param>
        /// <param name="roleTransferModel"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<string> CreateRole(ClaimsPrincipal user, CustomRoleTransferModel roleTransferModel) {
            bool isRoleExist = await _roleManager.RoleExistsAsync(roleTransferModel.RoleName);
            if (!isRoleExist && user is not null) {
                CustomRole roleCreated = new CustomRole {
                    Id = Guid.NewGuid().ToString(),
                    Name = roleTransferModel.RoleName,
                    NormalizedName = roleTransferModel.RoleName.ToUpper(),
                    Description = roleTransferModel.RoleDescription,
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                };

                var result = await _roleManager.CreateAsync(roleCreated);
                if (result.Succeeded) {
                    await _roleManager.AddClaimAsync(roleCreated, new Claim("Role", $"{roleTransferModel.RoleName}"));
                }
                else {
                    throw new Exception("Cannot create Role");
                }
                return roleCreated.Id;
            };
            return null!;

        }

        /// <summary>
        /// Возвращает список всех ролей в приложении, если реквестирующий юзер залогинен
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<List<CustomRoleTransferModel>> GetAllRoles(ClaimsPrincipal user) {
            List<CustomRoleTransferModel> roles = new();
            if (user is not null) {
                var rolesInApp = await _roleManager.Roles.ToListAsync();
                foreach (var role in rolesInApp) {
                    roles.Add(new CustomRoleTransferModel {
                        RoleId = role.Id,
                        RoleDescription = role.Description,
                        RoleName = role.Name!
                    });
                }
                return roles;
            }
            else {
                return new List<CustomRoleTransferModel> { };
            }

        }

        /// <summary>
        /// Ищет роль по её имени в приложении
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public async Task<bool> FindIfRoleExists(CustomRoleTransferModel role) {
            if (role is not null) {
                var existingRole = await _roleManager.FindByNameAsync(role.RoleName);
                return existingRole != null;
            } else { return false; }
        }

        public async Task<CustomRole?> FindExistinRole(CustomRoleTransferModel role) {
            if (role != null) {
                return await _roleManager.FindByIdAsync(role.RoleId);
            }
            else {
                throw new Exception("Requested role does not exists.");
            }
        }

        /// <summary>
        /// Апдейтит роль, если юзер залогинен и роль существует.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        public async Task UpdateRole(ClaimsPrincipal user, CustomRoleTransferModel role) {
            if (role is not null && user is not null) {
                _claimsService = new ClaimsService(_userManager, _roleManager);

                var roleToUpdate = await FindExistinRole(role);
                if (roleToUpdate is not null && roleToUpdate.Name is not null) {
                    string oldName = roleToUpdate.Name;
                    roleToUpdate.Description = role.RoleDescription;
                    roleToUpdate.Name = role.RoleName;
                    await _claimsService.UpdateRoleClaimValue(roleToUpdate.Id, role.RoleName);
                    await _claimsService.UpdateAllClaimValue(oldName, role.RoleName);
                    await _roleManager.UpdateAsync(roleToUpdate);
                }
            }
        }
    }
}
