using HRPrac.Business.Models;

namespace HRPrac.Business.Interfaces
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAll();
        Employee GetbyId(int id);
        void Create(Employee employee);
        void Update(Employee employee);
        void Delete(Employee employee);
    }
}
