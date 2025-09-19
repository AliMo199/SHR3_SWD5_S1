using HRPrac.Business.Models;
using EDU.ViewModels;
namespace EDU.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> UserManager;
        private readonly SignInManager<ApplicationUser> SignInManager;

        public AccountController(UserManager<ApplicationUser> UserManager, SignInManager<ApplicationUser> SignInManager)
        {
            this.UserManager = UserManager;
            this.SignInManager = SignInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserViewModel UserVM)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser
                {
                    UserName = UserVM.UserName,
                    Email = UserVM.Email,
                    PhoneNumber = UserVM.PhoneNumber
                };
                IdentityResult result = await UserManager.CreateAsync(user, UserVM.Password);
                if (result.Succeeded)
                {
                    // Optionally, you can sign in the user after registration
                    await SignInManager.SignInAsync(user,false);
                    //List<Claim> claims = new List<Claim>
                    //{
                    //    new Claim(ClaimTypes.Name, user.UserName),
                    //};
                    //await SignInManager.SignInWithClaimsAsync(user,isPersistent:false,claims);
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(UserVM);
        }
        [HttpGet]
        public IActionResult Login(string? returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginUserViewModel UserVM, string? returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                ApplicationUser user = await UserManager.FindByEmailAsync(UserVM.Email);
                if (user != null)
                {
                    /*
                    Alternative:
                    - CheckPasswordAsync()
                    List<Claim> claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.UserName),
                    };
                    await SignInManager.SignInWithClaimsAsync(user, UserVM.RememberMe, claims);
                    */
                    var result = await SignInManager.PasswordSignInAsync(user, UserVM.Password, UserVM.RememberMe, false);
                    
                    if (result.Succeeded)
                    {
                        if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                        {
                            return Redirect(returnUrl);
                        }
                        return RedirectToAction("Index", "Home");
                    }
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "User not found.");
                }
            }
            return View(UserVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await SignInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
    }
}
