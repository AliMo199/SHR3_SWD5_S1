using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly StudentBL studentBL;
        private readonly DepartmentBL departmentBL;

        public DepartmentController(DepartmentBL departmentBL, StudentBL studentBL)
        {
            this.departmentBL = departmentBL;
            this.studentBL = studentBL;
        }
        [HttpGet]
        public IActionResult ShowAll()
        {
            var departments = departmentBL.GetAll();
            return View(departments);
        }
        [HttpGet]
        public IActionResult ShowDetailsById(int id)
        {
            var department = departmentBL.GetById(id);
            if (department == null)
                return NotFound();

            var studentsAbove25 = department.Students
                                            .Where(s => s.Age > 25)
                                            .ToList();
            var students = department.Students.ToList();

            var state = department.Students.Count > 50 ? "Main" : "Branch";

            var departmentVM = new DepartmentViewModel
            {
                DepartmentName = department.Name,
                Students = students,
                StudentsAbove25 = studentsAbove25,
                DepartmentState = state
            };

            return View(departmentVM);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Department department)
        {
            if (!ModelState.IsValid)
            {
                return View(department);
            }

            departmentBL.AddDept(department);
            return RedirectToAction("ShowAll");
        }
    }
}
