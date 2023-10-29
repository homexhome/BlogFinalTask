using BlogFinalTask.Data.Models;
using BlogFinalTask.Data.Models.HelperModels;
using BlogFinalTask.Data.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BlogFinalTask.Services.AdministrationTools
{
    [Authorize(Policy = "RequireAdminRole")]
    public class AdministratorService : IAdministratorService
    {
        private readonly UserManager<CustomIdentity> _userManager;
        private readonly RoleManager<CustomRole> _roleManager;
        private readonly IRepositoryCollection _repo;
        private readonly SignInManager<CustomIdentity> _signInManager;

        public AdministratorService(UserManager<CustomIdentity> userManager, RoleManager<CustomRole> roleManager,
            IRepositoryCollection repo, SignInManager<CustomIdentity> signInManager) {
            _userManager = userManager;
            _roleManager = roleManager;
            _repo = repo;
            _signInManager = signInManager;
        }

        public async Task<List<CustomUserTransferModel>> GetAllUsers() {
            List<CustomUserTransferModel> allUserList = new();
            List<CustomIdentity> userList = await _userManager.Users.ToListAsync();
            if (userList.Count == 0) {
                throw new Exception("Users not foind");
            }
            foreach (var user in userList) {
                var role = await _userManager.GetRolesAsync(user);
                allUserList.Add(new CustomUserTransferModel {
                    UserName = user.UserName!,
                    UserId = user.Id,
                    UserRole = role.FirstOrDefault()!.ToString()
                });
            }
            return allUserList;
        }

        public async Task<string>? GetUserName(string userId) {
            var user = await _userManager.FindByIdAsync(userId);
            if (user is not null && user.UserName is not null) {
                return user.UserName;
            } else {
                return null!;
            }
        }

        public async Task<List<string>> GetAllRolesList() {
            List<string> result = new();
            var roleList = await _roleManager.Roles.ToListAsync();
            if (roleList.Count == 0) {
                throw new Exception("No Roles in Role list");
            }

            foreach (var role in roleList) {
                result.Add(role.Name!.ToString());
            }
            return result;
        }

        public async Task<List<CustomRole>> GetAllRoles() {
            List<CustomRole> result = new();
            var roleList = await _roleManager.Roles.ToListAsync();
            if (roleList.Count == 0) {
                throw new Exception("No Roles in Role list");
            }

            foreach (CustomRole role in roleList) {
                result.Add(role);
            }
            return result;
        }

        public async Task UpdateUser(CustomUserTransferModel customUserModel) {
            RoleService roleService = new(_userManager, _roleManager);
            ClaimsService claimsService = new(_userManager, _roleManager);
            CustomIdentity? userToUpdate = await _userManager.FindByIdAsync(customUserModel.UserId)
                ?? throw new Exception("User not found when updating ");

            List<string> rolesList = await GetAllRolesList();
            await claimsService.UpdateUserClaim(userToUpdate, customUserModel, rolesList);
            await roleService.UpdateUserRole(userToUpdate, customUserModel);
            string userId = customUserModel.UserId;
            await LogOutUser(_signInManager, userId);
        }


        public async Task SaveChangesAsync() {
            try {
                await _repo.Save();
            }
            catch (Exception ex) {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task LogOutUser(SignInManager<CustomIdentity> signInManager, string userId) {
            var principle = await GetUserClaimsPrincipalById(userId);
            if (signInManager.IsSignedIn(principle)) { //BIG TODO: Не могу понять пока, как тут это настроить, чтобы разлогинить пользователя
                await signInManager.SignOutAsync();
            }
        }

        public async Task<ClaimsPrincipal> GetUserClaimsPrincipalById(string userId) {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null) {
                var userClaims = await _userManager.GetClaimsAsync(user);

                var claimsIdentity = new ClaimsIdentity(userClaims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                return claimsPrincipal;
            }

            return null!; // Пользователь с указанным Id не найден
        }
    }
}
