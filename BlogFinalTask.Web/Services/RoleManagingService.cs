using BlogFinalTask.Web.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BlogFinalTask.Web.Services
{
    public class RoleManagingService
    {
        private readonly RoleManager<CustomRole> _roleManager;
        private readonly UserManager<CustomIdentity> _userManager;

        public RoleManagingService(RoleManager<CustomRole> roleManager, UserManager<CustomIdentity> userManager) {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        //public async Task CreateRoleAsync(string name) {
        //    if (!string.IsNullOrEmpty(name)) {
        //        IdentityResult result = await _roleManager.CreateAsync(new CustomRole(name));
        //        if (result.Succeeded) {
        //            return;
        //        } else {
        //            foreach (var error in result.Errors) {
        //                throw new NotImplementedException();
        //            }
        //        }
        //    } 
        //}

        public async Task<List<CustomRole>> GetAllRoles() {
            return await _roleManager.Roles.ToListAsync();
        }

        public async Task<string> GetRoleIdByName(string name) {
            var result = await _roleManager.Roles.FirstOrDefaultAsync(i => i.Name == name);
            return result!.Id;
        }

        public async Task<string> GetUserRole(CustomIdentity user) {
            if (user != null) {
                    var result = await _userManager.GetRolesAsync(user);
                return result.FirstOrDefault()!;
            } else {
                return string.Empty;
            }
        }

        public async Task ChangeUserRole(CustomIdentity user, IdentityRole role, List<string> roles) {
            if (!roles.Contains(role.Name!)) {
                await _userManager.AddToRoleAsync(user, role.Name!);
            };
        }

        public async Task DeleteUserRole(CustomIdentity user, IdentityRole role, List<string> roles) {
            if (roles.Contains(role.Name!)) {
                await _userManager.RemoveFromRoleAsync(user, role.Name!);
            }
        }
    }
}
