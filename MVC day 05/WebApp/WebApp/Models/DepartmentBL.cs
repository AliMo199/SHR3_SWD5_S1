using Microsoft.EntityFrameworkCore;

namespace WebApp.Models
{
    public class DepartmentBL
    {

        private readonly ApplicationDBContext context;
        public DepartmentBL(ApplicationDBContext context)
        {
            this.context = context;
        }

        public List<Department> GetAll()
        {
            return context.Departments.Include(D => D.Students).ToList();
        }

        public void AddDept(Department Dept)
        {
            context.Add(Dept);
            context.SaveChanges();
        }

        public void DeleteDept(Department Dept)
        {
            context.Remove(Dept);
            context.SaveChanges();
        }

        public Department? GetById(int id)
        {
            return context.Departments.Include(s => s.Students)
                                      .FirstOrDefault(d => d.Id == id);
        }
    }
}
