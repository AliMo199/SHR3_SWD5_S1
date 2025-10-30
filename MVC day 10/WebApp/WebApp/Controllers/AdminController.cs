using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.Models;
using WebApp.Models.ViewModels;

namespace WebApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // GET /Admin/AddRoleToUser
        [HttpGet]
        public async Task<IActionResult> AddRoleToUser(string userId = null!)
        {
            var model = new AddRoleViewModel();

            // Dropdown for users
            model.Users = _userManager.Users.Select(u => new SelectListItem
            {
                Value = u.Id,
                Text = u.Email
            }).ToList();

            // Dropdown for roles (Admin or Moderator)
            model.Roles = _roleManager.Roles
                .Select(r => new SelectListItem
                {
                    Value = r.Name,
                    Text = r.Name
                }).ToList();

            if (!string.IsNullOrEmpty(userId))
            {
                model.UserId = userId;
                var user = await _userManager.FindByIdAsync(userId);
                if (user != null)
                {
                    model.CurrentRoles = await _userManager.GetRolesAsync(user);
                }
            }

            return View(model);
        }

        // POST: /Admin/AddRoleToUser
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddRoleToUser(AddRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.UserId);
                if (user != null)
                {
                    // Remove existing roles if needed (optional; here we add without removing)
                    // var currentRoles = await _userManager.GetRolesAsync(user);
                    // await _userManager.RemoveFromRolesAsync(user, currentRoles);

                    await _userManager.AddToRoleAsync(user, model.RoleName);
                    return RedirectToAction("AddRoleToUser");  // Or to a user list
                }
                ModelState.AddModelError(string.Empty, "User not found.");
            }

            // Repopulate dropdowns on error
            model.Users = _userManager.Users.Select(u => new SelectListItem { Value = u.Id, Text = u.Email }).ToList();
            model.Roles = _roleManager.Roles.Where(r => r.Name == "Admin" || r.Name == "Moderator")
                .Select(r => new SelectListItem { Value = r.Name, Text = r.Name }).ToList();

            return View(model);
        }

        // GET: /Admin/RegisterUser
        [HttpGet]
        public IActionResult RegisterUser()
        {
            var model = new AdminRegisterViewModel();
            model.Roles = new List<SelectListItem>
            {
                new SelectListItem { Value = "Admin", Text = "Admin" },
                new SelectListItem { Value = "Moderator", Text = "Moderator" }
            };
            return View(model);
        }

        // POST: /Admin/RegisterUser
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterUser(AdminRegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    // Assign selected role
                    await _userManager.AddToRoleAsync(user, model.RoleName);
                    return RedirectToAction("RegisterUser");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            model.Roles = new List<SelectListItem>
            {
                new SelectListItem { Value = "Admin", Text = "Admin" },
                new SelectListItem { Value = "Moderator", Text = "Moderator" }
            };
            return View(model);
        }
    }
}