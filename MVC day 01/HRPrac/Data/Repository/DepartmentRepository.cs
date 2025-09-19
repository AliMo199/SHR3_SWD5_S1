using HRPrac.Business.Models;
using HRPrac.Business.Interfaces;
using HRPrac.Data.Presistence;
namespace HRPrac.Data.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        public HRSystemDBContext _Context;
        public DepartmentRepository(HRSystemDBContext context)
        {
            _Context = context;
        }
        public List<Department> GetAll()
        {
            return _Context.Departments.Include(e=>e.Employees).ToList();
        }
        public Department GetById(int id)
        {
            return _Context.Departments.FirstOrDefault(d => d.DepartmentId == id);
        }
        public Department GetByIdWithInclusion(int id)
        {
            return _Context.Departments.Include(d => d.Employees).FirstOrDefault(d => d.DepartmentId == id);
        }
        public void Create(Department department)
        {
            _Context.Departments.Add(department);
            _Context.SaveChanges();
        }
        public void Update(Department department)
        {
            _Context.Departments.Update(department);
            _Context.SaveChanges();
        }
        public void Delete(Department department)
        {
            _Context.Departments.Remove(department);
            _Context.SaveChanges();
        }
    }
}
