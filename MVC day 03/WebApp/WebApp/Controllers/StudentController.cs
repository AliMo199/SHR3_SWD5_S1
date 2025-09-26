using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDBContext _context;

        public StudentController(ApplicationDBContext context)
        {
            _context = context;
        }

        public IActionResult ShowAll()
        {
            var studentBL = new StudentBL(_context);
            List<Student> studentList = studentBL.GetAll();
            return View(studentList);
        }

        public IActionResult ShowDetails(int id)
        {
            StudentBL studentBL = new StudentBL(_context);
            Student student = studentBL.GetById(id);

            if (student == null)
                return NotFound();


            return View("GetById", student);
        }
        
    }
}
