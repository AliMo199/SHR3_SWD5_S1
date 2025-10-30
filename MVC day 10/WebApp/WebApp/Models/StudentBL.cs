using Microsoft.EntityFrameworkCore;

namespace WebApp.Models
{
    public class StudentBL
    {

        private readonly ApplicationDBContext context;

        public StudentBL(ApplicationDBContext context)
        {
            this.context = context;
        }

        public Student GetById(int id)
        {
            return context.Students
                          .Include(s => s.Department)
                          .FirstOrDefault(e => e.Id == id);
        }

        public List<Student> GetAll()
        {
            return context.Students
                          .Include(s => s.Department)
                          .ToList();
        }
        public void AddStudent(Student student)
        {
            context.Students.Add(student);
            context.SaveChanges();
        }
        public void UpdateStudent(Student student)
        {
            context.Students.Update(student);
            context.SaveChanges();
        }
        public void DeleteStudent(Student student)
        {
            context.Students.Remove(student);
            context.SaveChanges();
        }
    }
}
