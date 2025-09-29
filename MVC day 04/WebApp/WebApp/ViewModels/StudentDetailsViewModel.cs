using WebApp.Models;

namespace WebApp.ViewModels
{
    public class StudentDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int DepartmentId { get; set; }
        public List<Department>? departments { get; set; }

        }
}
