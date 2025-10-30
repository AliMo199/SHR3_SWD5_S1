using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.ViewModels
{
    public class AddRoleViewModel
    {
        [Required]
        [Display(Name = "Select User")]
        public string UserId { get; set; }

        [Required]
        [Display(Name = "Select Role")]
        public string RoleName { get; set; }

        public List<SelectListItem> Users { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Roles { get; set; } = new List<SelectListItem>();

        public IList<string>? CurrentRoles { get; set; }
    }
}
