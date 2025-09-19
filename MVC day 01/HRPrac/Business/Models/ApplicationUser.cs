global using Microsoft.AspNetCore.Identity;
namespace HRPrac.Business.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? Address { get; set; }

    }
}
