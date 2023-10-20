using BlogFinalTask.Web.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BlogFinalTask.Web.Services
{
    public class AdministratorService
    {
        private readonly UserManager<CustomIdentity> _userManager;

        public AdministratorService(UserManager<CustomIdentity> userManager) {
            _userManager = userManager;
        }

        public async Task<List<CustomIdentity>> GetAllUsers() {
            return await _userManager.Users.ToListAsync();
        }
        
    }
}
