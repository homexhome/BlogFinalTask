using BlogFinalTask.Web.Data.Models;
using BlogFinalTask.Web.Data.Models.HelperModels;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Security.Claims;

namespace BlogFinalTask.Web.Services
{
    public class UserClaimsService
    {
        private readonly UserManager<CustomIdentity> _userManager;
        private readonly RoleManager<CustomRole> _roleManager;

        public UserClaimsService(UserManager<CustomIdentity> userManager, RoleManager<CustomRole> roleManager) {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task AddDefaultClaim(CustomIdentity user) {
            var roleClaim = new Claim(ClaimTypes.Role, "User");
            await _userManager.AddClaimAsync(user, roleClaim);
        }

        public async Task RemoveAllClaimsFromUser(CustomIdentity user, List<Claim>? currentClaims) {
            if (currentClaims is null) {
                currentClaims = (List<Claim>)await _userManager.GetClaimsAsync(user);
            }
            foreach (var claim in currentClaims) {
                await _userManager.RemoveClaimAsync(user, claim);
            }
        }

        public async Task UpdateUserClaim(CustomIdentity user, CustomUserTransferModel transferModel, List<string> roleList) {
            var roles = await _userManager.GetRolesAsync(user);
            string roleToUpdate = roles.FirstOrDefault()!;
            if (transferModel.UserRole == roleToUpdate) {
                return;
            }

            if (!roleList.Contains(transferModel.UserRole) || !roleList.Contains(roleToUpdate)) {
                throw new Exception("Invalid role provided");
            }

            List<Claim> claimsToAdd = new();

            if (transferModel.UserRole == "User") {
                claimsToAdd.Add(new Claim(ClaimTypes.Role, transferModel.UserRole));
            }
            else if (transferModel.UserRole == "Moderator" || transferModel.UserRole == "Admin") {
                claimsToAdd.Add(new Claim(ClaimTypes.Role, transferModel.UserRole));

                if (roleToUpdate != "User") {
                    claimsToAdd.Add(new Claim(ClaimTypes.Role, transferModel.UserRole));
                }
            }

            await RemoveAllClaimsFromUser(user, (List<Claim>)await _userManager.GetClaimsAsync(user));
            await _userManager.AddClaimsAsync(user, claimsToAdd);
        }
    }
}
