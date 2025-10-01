using System.ComponentModel.DataAnnotations;
using WebApp.Models;

namespace WebApp.ViewModels
{
    public class StudentDetailsViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(1, 35)]
        public int Age { get; set; }
        public int DepartmentId { get; set; }
        public List<Department>? departments { get; set; }

        }
}
