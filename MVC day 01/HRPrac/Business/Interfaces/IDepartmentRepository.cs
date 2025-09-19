using HRPrac.Business.Models;

namespace HRPrac.Business.Interfaces
{
    public interface IDepartmentRepository
    {
        List<Department> GetAll();
        Department GetById(int id);
        Department GetByIdWithInclusion(int id);
        void Create(Department department);
        void Update(Department department);
        void Delete(Department department);
    }
}
