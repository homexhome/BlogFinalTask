using Microsoft.AspNetCore.Identity;

namespace BlogFinalTask.Web.Data.Models
{
    public class CustomIdentity : IdentityUser
    {
        public string RoleId { get; set; } = null!;
        public CustomRole Role { get; set; } = null!;
    }
}
