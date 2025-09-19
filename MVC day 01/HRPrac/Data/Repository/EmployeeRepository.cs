using HRPrac.Business.Models;
using HRPrac.Business.Interfaces;
using HRPrac.Data.Presistence;
namespace HRPrac.Data.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public HRSystemDBContext _Context;
        public EmployeeRepository(HRSystemDBContext context)
        {
            _Context = context;
        }
        public List<Employee> GetAll()
        {
            return _Context.Employees.Include(d => d.Department).ToList();
        }
        public Employee GetbyId(int id)
        {
            return _Context.Employees
                .Include(d => d.Department)
                .Include(b => b.Benefit)
                .FirstOrDefault(e => e.EmployeeId == id);
        }
        public void Create(Employee employee)
        {
            _Context.Employees.Add(employee);
            _Context.SaveChanges();
        }
        public void Delete(Employee employee)
        {
            _Context.Employees.Remove(employee);
            _Context.SaveChanges();
        }
        public void Update(Employee employee)
        {
            _Context.Employees.Update(employee);
            _Context.SaveChanges();
        }
    }
}
