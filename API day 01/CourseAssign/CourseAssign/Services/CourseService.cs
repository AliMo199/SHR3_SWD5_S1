using CourseAssign.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseAssign.Services
{
    public class CourseService
    {
        private readonly ApplicationDbContext _context;

        public CourseService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Course>> Get()
        {
            return await _context.Courses.ToListAsync();
        }

        public async Task<Course?> GetById(int id)
        {
            return await _context.Courses.FindAsync(id);
        }

        public async Task<Course?> CourseByName(string name)
        {
            return await _context.Courses.FirstOrDefaultAsync(c => c.Crs_Name == name);
        }

        public async Task<Course> AddCourse(Course course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
            return course;
        }

        public async Task<bool> UpdateCourse(int id, Course updatedCourse)
        {
            if (id != updatedCourse.Id)
                return false;

            var existing = await _context.Courses.FindAsync(id);
            if (existing == null)
                return false;

            existing.Crs_Name = updatedCourse.Crs_Name;
            existing.Crs_Desc = updatedCourse.Crs_Desc;
            existing.Duration = updatedCourse.Duration;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCourse(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null)
                return false;

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
