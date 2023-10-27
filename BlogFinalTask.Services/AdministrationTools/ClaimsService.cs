using BlogFinalTask.Data.Models;
using BlogFinalTask.Data.Models.HelperModels;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using BlogFinalTask.Services.Helpers;

namespace BlogFinalTask.Services.AdministrationTools
{
    public class ClaimsService
    {
        private readonly UserManager<CustomIdentity> _userManager;
        private readonly RoleManager<CustomRole> _roleManager;

        public ClaimsService(UserManager<CustomIdentity> userManager, RoleManager<CustomRole> roleManager) {
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
            Claim newClaim = new Claim("Role", $"{transferModel.UserRole}");
            List<Claim> claimsToAdd = new List<Claim> { newClaim } ;

            await RemoveAllClaimsFromUser(user, (List<Claim>)await _userManager.GetClaimsAsync(user));
            await _userManager.AddClaimsAsync(user, claimsToAdd);
        }
        public async Task UpdateRoleClaimValue(string roleId, string newClaimValue) {
            var role = await _roleManager.FindByIdAsync(roleId);
            if (role != null) {
                var existingClaims = await _roleManager.GetClaimsAsync(role);
                Claim? existingClaim = existingClaims.FirstOrDefault();
                if (existingClaim != null) {
                    await _roleManager.RemoveClaimAsync(role, existingClaim);
                }
                await _roleManager.AddClaimAsync(role,new Claim("Role", newClaimValue));
            }
        }

        public async Task UpdateAllClaimValue(string oldClaim, string newClaim) {
            if (oldClaim == newClaim) {  return; }

            Claim? claimToUpdate = new("Role", oldClaim);
            Claim? resultClaim = new("Role", newClaim);
            var comparer = new ClaimComparer();
            var userList = await _userManager.Users.ToListAsync();
            foreach (var user in userList) {
                var userClaim = (await _userManager.GetClaimsAsync(user)).FirstOrDefault();
                if (comparer.Equals(claimToUpdate, userClaim) && userClaim is not null) {
                    await _userManager.ReplaceClaimAsync(user, userClaim, resultClaim);
                }
            }
            
        }
    }

}
