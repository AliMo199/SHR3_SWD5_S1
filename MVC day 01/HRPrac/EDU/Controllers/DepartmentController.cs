using Microsoft.AspNetCore.Mvc;
using HRPrac.Business.Models;
using HRPrac.Business.Interfaces;
using EDU.ViewModels;
namespace EDU.Controllers
{
    [Authorize]
    public class DepartmentController : Controller
    {
        IDepartmentRepository DepartmentRepo;
        public DepartmentController(IDepartmentRepository DeptRepo)
        {
            DepartmentRepo = DeptRepo;
        }
        public IActionResult Index()
        {
            List<Department> DeptList = DepartmentRepo.GetAll();
            return View("Index",DeptList);
        }
        public IActionResult New()
        {
            return View("New",new Department());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveNew(Department Dept)
        {
            if (ModelState.IsValid)
            {
                DepartmentRepo.Create(Dept);
                return RedirectToAction("Index");
            }
            return View("New",Dept);
        }
        public IActionResult DeptEdit(int id)
        {
            Department department = DepartmentRepo.GetById(id);
            if (department == null)
                return NotFound();
            return View(department);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveDeptEdit (int id,Department department)
        {
            Department existingDept= DepartmentRepo.GetById(id);
            if (ModelState.IsValid)
            {
                existingDept.Name=department.Name;
                DepartmentRepo.Update(existingDept);
                return RedirectToAction("Index");
            }
            return View("DeptEdit",department);
        }
        public IActionResult DeptDetails(int id)
        {
            Department department= DepartmentRepo.GetByIdWithInclusion(id);
            if (department == null)
                return NotFound();
            DepartmentDetailsViewModel viewModel = new DepartmentDetailsViewModel
            {
                DepartmentName = department.Name,
                Employees = department.Employees.ToList()
            };
            return View(viewModel);
        }
        public IActionResult DeptDelete(int id)
        {
            Department department = DepartmentRepo.GetById(id);
            if (department == null) return NotFound();
            DepartmentRepo.Delete(department);
            return RedirectToAction("Index");
        }
    }
}
