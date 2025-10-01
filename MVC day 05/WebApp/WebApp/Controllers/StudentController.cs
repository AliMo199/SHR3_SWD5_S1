using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDBContext _context;

        public StudentController(ApplicationDBContext context)
        {
            _context = context;
        }
        private const int DefaultPageSize = 10;
        public async Task<IActionResult> ShowAll(string searchString, int? departmentId, int page = 1, int pageSize = DefaultPageSize)
        {
            ViewData["CurrentFilter"] = searchString;
            ViewData["CurrentDepartment"] = departmentId;
            ViewData["PageSize"] = pageSize;


            var studentsQuery = _context.Students
            .Include(s => s.Department)
            .AsQueryable();


            if (!string.IsNullOrWhiteSpace(searchString))
            {
                string s = searchString.Trim();
                studentsQuery = studentsQuery.Where(su =>
                su.Name.Contains(s));
            }


            if (departmentId.HasValue && departmentId.Value > 0)
            {
                studentsQuery = studentsQuery.Where(s => s.DepartmentId == departmentId.Value);
            }


            studentsQuery = studentsQuery.OrderBy(s => s.Name);


            var paged = await PaginatedList<Student>.CreateAsync(studentsQuery.AsNoTracking(), page, pageSize);


            ViewBag.Departments = await _context.Departments.OrderBy(d => d.Name).ToListAsync();


            return View(paged);
        }

        public IActionResult ShowDetails(int id)
        {
            StudentBL studentBL = new StudentBL(_context);
            Student student = studentBL.GetById(id);

            if (student == null)
                return NotFound();


            return View("GetById", student);
        }

        public IActionResult Add()
        {
            DepartmentBL departmentBL = new DepartmentBL(_context);
            StudentDetailsViewModel studentDetailsViewModel = new StudentDetailsViewModel
            {
                departments = departmentBL.GetAll()
            };
            return View(studentDetailsViewModel);
        }
        [HttpPost]
        public IActionResult Add(StudentDetailsViewModel student)
        {
            if (ModelState.IsValid)
            {
                StudentBL studentBL = new StudentBL(_context);
                Student newStudent = new Student
                {
                    Name = student.Name,
                    Age = student.Age,
                    DepartmentId = student.DepartmentId
                };
                studentBL.AddStudent(newStudent);
                return RedirectToAction("ShowAll");
            }
            DepartmentBL departmentBL = new DepartmentBL(_context);
            student.departments = departmentBL.GetAll();
            return View("Add", student);
        }
        public IActionResult Edit(int id)
        {
            StudentBL studentBL = new StudentBL(_context);
            Student student = studentBL.GetById(id);
            DepartmentBL departmentBL = new DepartmentBL(_context);
            StudentDetailsViewModel studentDetailsViewModel = new StudentDetailsViewModel
            {
                Id = student.Id,
                Name = student.Name,
                Age = student.Age,
                DepartmentId = student.DepartmentId,
                departments = departmentBL.GetAll()
            };
            return View(studentDetailsViewModel);
        }
        [HttpPost]
        public IActionResult Edit(int id, StudentDetailsViewModel student)
        {
            if (ModelState.IsValid)
            {
                StudentBL studentBL = new StudentBL(_context);
                Student existingStudent = studentBL.GetById(id);
                if (existingStudent == null)
                    return NotFound();
                existingStudent.Name = student.Name;
                existingStudent.Age = student.Age;
                existingStudent.DepartmentId = student.DepartmentId;
                studentBL.UpdateStudent(existingStudent);
                return RedirectToAction("ShowAll");
            }
            DepartmentBL departmentBL = new DepartmentBL(_context);
            student.departments = departmentBL.GetAll();
            return View("Edit", student);
        }

        public IActionResult Delete(int id)
        {
            StudentBL studentBL = new StudentBL(_context);
            Student student = studentBL.GetById(id);
            if (student == null)
                return NotFound();
            studentBL.DeleteStudent(student);
            return RedirectToAction("ShowAll");
        }

    }
}
