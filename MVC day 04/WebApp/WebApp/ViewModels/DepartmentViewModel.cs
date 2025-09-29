using WebApp.Models;

namespace WebApp.ViewModels
{
    public class DepartmentViewModel
    {
        public string DepartmentName { get; set; } = string.Empty;
        public List<Student> StudentsAbove25 { get; set; } = new List<Student>();
        public List<Student> Students { get; set; } = new List<Student>();
        public string DepartmentState { get; set; } = string.Empty;
    }
}
