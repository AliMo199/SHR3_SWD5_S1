using Microsoft.AspNetCore.Mvc;
using HRPrac.Business.Models;
using HRPrac.Business.Interfaces;
using EDU.ViewModels;
namespace EDU.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        IEmployeeRepository EmployeeRepo;
        IDepartmentRepository DepartmentRepo;
        IHealthBenefitRepository HealthBenefitRepo;
        public EmployeeController(IEmployeeRepository EmpRepo,IDepartmentRepository DeptRepo,IHealthBenefitRepository HBRepo)
        {
            EmployeeRepo = EmpRepo;
            DepartmentRepo = DeptRepo;
            HealthBenefitRepo = HBRepo;
        }
        public IActionResult Index()
        {
            List<Employee> Emplist = EmployeeRepo.GetAll();
            return View("Index",Emplist);
        }
        public IActionResult NewEmp()
{
            EmployeeDetailsViewModel EmpViewModel = new EmployeeDetailsViewModel
            {
                DepartmentList = DepartmentRepo.GetAll(),
                BenefitList = HealthBenefitRepo.GetAll(),
                EmpTypes = new List<string> { "Commission", "Hourly", "Salaried", "Manager" }
            };
    
    return View(EmpViewModel);
}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveEmp(EmployeeDetailsViewModel Model)
        {
            if (ModelState.IsValid)
            {
                Employee employee=new Employee();
                EmployeeRepo.Create(SetPropertiesForEntity(employee, Model));
                return RedirectToAction("Index");
            }
            else
            {
                Model.DepartmentList = DepartmentRepo.GetAll();
                Model.BenefitList = HealthBenefitRepo.GetAll();
                Model.EmpTypes = new List<string> { "Commission", "Hourly", "Salaried", "Manager" };
                return View("NewEmp", Model);
            }
        }
        public IActionResult EmpDetails(int Id)
        {
            Employee employee = EmployeeRepo.GetbyId(Id);

            if (employee == null)
                return NotFound();

            EmployeeDetailsViewModel EmpViewModel = new EmployeeDetailsViewModel();
            return View(SetPropertiesForModel(employee,EmpViewModel));
        }
        public IActionResult EmpEdit(int Id)
        {
            Employee employee = EmployeeRepo.GetbyId(Id);

            if (employee == null)
                return NotFound();

            EmployeeDetailsViewModel EmpViewModel = new EmployeeDetailsViewModel();
            return View(SetPropertiesForModel(employee,EmpViewModel));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveEmpEdit(int id,EmployeeDetailsViewModel Model)
        {
            if (ModelState.IsValid)
            {
                Employee existingEmployee = EmployeeRepo.GetbyId(id);
                if (existingEmployee == null)
                    return NotFound();
                EmployeeRepo.Update(SetPropertiesForEntity(existingEmployee, Model));
                return RedirectToAction("Index");
            }
            else
            {
                Model.DepartmentList = DepartmentRepo.GetAll();
                Model.BenefitList = HealthBenefitRepo.GetAll();
                Model.EmpTypes = new List<string> { "Commission", "Hourly", "Salaried", "Manager" };
                return View("EmpEdit", Model);
            }
        }
        public IActionResult EmpDelete(int id)
        {
            Employee employee = EmployeeRepo.GetbyId(id);
            if (employee == null) return NotFound();
            EmployeeRepo.Delete(employee);
            return RedirectToAction("Index");
        }

        private Employee SetPropertiesForEntity(Employee employee, EmployeeDetailsViewModel model)
        {
            employee.Name = model.Name;
            employee.PhoneNum = model.PhoneNum;
            employee.Email = model.Email;
            employee.JobTitle = model.JobTitle;
            employee.DepartmentId = model.DepartmentId;
            employee.BenefitId = model.BenefitId;
            employee.EmployeeType = model.EmployeeType;
            if (model.EmployeeType == "Salaried")
            {
                employee.Salary= model.Salary;
            }
            else if (model.EmployeeType == "Manager")
            {
                employee.Salary= model.Salary;
                employee.Bonus = model.Bonus;
            }
            else if (model.EmployeeType == "Hourly")
            {
                employee.Hoursworked= model.Hoursworked;
                employee.HourlyRate= model.HourlyRate;
            }
            else if (model.EmployeeType == "Commission")
            {
                employee.CommissionRate= model.CommissionRate;
                employee.Target = model.Target;
            }
            else
            {
                throw new InvalidOperationException("Unknown employee type");
            }
            return employee;
        }
        private EmployeeDetailsViewModel SetPropertiesForModel(Employee employee, EmployeeDetailsViewModel model)
        {
            List<Department> departments = DepartmentRepo.GetAll();
            List<HealthBenefit> benefits = HealthBenefitRepo.GetAll();
            model.Employee = employee;
            model.Department = employee.Department;
            model.DepartmentList = departments;
            model.BenefitList = benefits;
            model.EmpTypes = new List<string> { "Commission", "Hourly", "Salaried", "Manager" };
            model.Benefit = employee.Benefit;
            model.Name = employee.Name;
            model.PhoneNum = employee.PhoneNum;
            model.Email = employee.Email;
            model.JobTitle = employee.JobTitle;
            model.DepartmentId = employee.DepartmentId;
            model.BenefitId = employee.BenefitId;
            model.EmployeeType = employee.EmployeeType;
            if (employee.EmployeeType == "Salaried")
            {
                model.Salary = employee.Salary;
            }
            else if (employee.EmployeeType == "Manager")
            {
                model.Salary = employee.Salary;
                model.Bonus = employee.Bonus;
            }
            else if (employee.EmployeeType == "Hourly")
            {
                model.Hoursworked = employee.Hoursworked;
                model.HourlyRate = employee.HourlyRate;
            }
            else if (employee.EmployeeType == "Commission")
            {
                model.CommissionRate = employee.CommissionRate;
                model.Target = employee.Target;
            }
            else
            {
                throw new InvalidOperationException("Unknown employee type");
            }
            return model;
        }
    }
}
