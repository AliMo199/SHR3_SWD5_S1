using System.ComponentModel.DataAnnotations.Schema;

namespace HRPrac.Business.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string PhoneNum { get; set; }
        public string Email { get; set; }
        public string JobTitle { get; set; }
        [ForeignKey("Benefit")]
        public int BenefitId { get; set; }  
        public HealthBenefit? Benefit { get; set; }
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public string EmployeeType { get; set; }
        [Range(0, int.MaxValue)]
        public int Hoursworked { get; set; }
        [Range(0.0, Double.MaxValue)]
        public double HourlyRate { get; set; }
        [Range(0.0, Double.MaxValue)]
        public double Target { get; set; }
        [Range(0.0, Double.MaxValue)]
        public double CommissionRate { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Salary must be greater than 0")]
        public int Salary { get; set; }
        [Range(0.0, Double.MaxValue)]
        public double Bonus { get; set; }
    }
}
