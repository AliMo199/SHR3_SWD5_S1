namespace HRPrac.Business.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual List<Employee>? Employees { get; set; }
    }
}
