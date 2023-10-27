using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace BlogFinalTask.Data.Models
{
    public class CustomRole : IdentityRole
    {
        [MaxLength]
        public string Description { get; set; } = null!;
    }
}
