using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Department
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Manager Name")]
        public string MgrName { get; set; }

        public ICollection<Course> Courses { get; set; } = new List<Course>();
        public ICollection<Student>? Students { get; set; } = new List<Student>();
        public ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
    }
}
