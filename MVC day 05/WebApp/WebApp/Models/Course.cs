using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public decimal Degree { get; set; }
        public decimal MinDegree { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public ICollection<StudentCourses> StudentCourses { get; set; } = new List<StudentCourses>();
        public ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
    }
}
