using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        [StringLength(50, ErrorMessage = "Role name must be between 3 and 50 characters.", MinimumLength = 3)]
        [Display(Name = "Role Name")]
        public string RoleName { get; set; }
    }
}
