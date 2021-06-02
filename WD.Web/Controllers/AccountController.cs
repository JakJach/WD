using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;
using WD.Web.ViewModels;

namespace WD.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        private readonly ILogger<AccountController> _logger;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager,
                                ILogger<AccountController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;

            _logger = logger;
        }

        #region Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser()
                {
                    UserName = vm.Email,
                    Email = vm.Email
                };

                var result = await _userManager.CreateAsync(user, vm.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(vm);
        }
        #endregion

        #region Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel vm, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(vm.Email, vm.Password, vm.RememberMe, false);

                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl))
                        return LocalRedirect(returnUrl);
                    else
                        return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Login failed!");
            }
            return View(vm);
        }
        #endregion

        #region Logout
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
        #endregion

        #region Error
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        #endregion

        [AcceptVerbs("Get", "Post")]
        public async Task<IActionResult> IsEmailInUse(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
                return Json(true);
            else
                return Json($"Email {email} is already taken.");
        }
    }
}
