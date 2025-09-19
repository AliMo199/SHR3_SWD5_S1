using HRPrac.Business.Models;
namespace EDU.ViewModels
{
    public class EmployeeDetailsViewModel
    {
        public List<Department>? DepartmentList { get; set; }
        public List<HealthBenefit>? BenefitList { get; set; }
        public List<Employee>? Employees { get; set; }
        public Employee? Employee { get; set; }
        public int EmployeeId { get; set; }
        public List<string>? EmpTypes { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? PhoneNum { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        [Display(Name = "Job Title")]
        public string? JobTitle { get; set; }
        [Required]
        [Display(Name = "Employee Type")]
        public string? EmployeeType { get; set; }
        public HealthBenefit? Benefit { get; set; }
        public int? BenefitType { get; set; }
        [Required]
        [Display(Name = "Benefit")]
        public int BenefitId { get; set; }
        public Department? Department { get; set; }
        public int? DepartmentName { get; set; }
        [Required]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        public double Target { get; set; }
        public double CommissionRate { get; set; }
        public int Hoursworked { get; set; }
        public double HourlyRate { get; set; }
        public int Salary { get; set; }
        public double Bonus { get; set; }
    }
}

