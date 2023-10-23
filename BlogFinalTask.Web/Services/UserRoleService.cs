using BlogFinalTask.Web.Data.Models;
using BlogFinalTask.Web.Data.Models.HelperModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BlogFinalTask.Web.Services
{
    public class UserRoleService
    {
        private readonly UserManager<CustomIdentity> _userManager;
        private readonly RoleManager<CustomRole> _roleManager;

        public UserRoleService(UserManager<CustomIdentity> userManager, RoleManager<CustomRole> roleManager) {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task AssignBaseRole(CustomIdentity user) {
            //Setting base role
            var roleId = await _roleManager.Roles.FirstOrDefaultAsync(i => i.Name == "User");
            if (roleId != null) {
                await _userManager.AddToRoleAsync(user, "User");
            }
        }

        public async Task UpdateUserRole(CustomIdentity user, CustomUserTransferModel transferModel) {
            var rolesList = await _userManager.GetRolesAsync(user!);
            string roleToUpdate = rolesList.FirstOrDefault()!.ToString();

            if (user != null) {
                user.UserName = transferModel.UserName;
                if (roleToUpdate != transferModel.UserRole) {
                    await _userManager.RemoveFromRoleAsync(user, roleToUpdate);
                    await _userManager.AddToRoleAsync(user, transferModel.UserRole);
                }
            }
        }
    }
}
