using System.ComponentModel.DataAnnotations;

namespace CourseAssign.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        public string? Crs_Name { get; set; }
        public string? Crs_Desc { get; set; }
        public int? Duration { get; set; }
    }
}
