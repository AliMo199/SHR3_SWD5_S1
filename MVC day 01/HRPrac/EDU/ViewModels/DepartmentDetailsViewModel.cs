using HRPrac.Business.Models;
namespace EDU.ViewModels
{
    public class DepartmentDetailsViewModel
    {
        public string DepartmentName { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
