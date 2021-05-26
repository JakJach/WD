using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using WD.Data.Tools;
using WD.Web.Models;
using WD.Web.ViewModels;

namespace WD.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        private readonly ILogger<UserController> _logger;
        private readonly IWDWebRepository _repository;

        public UserController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager,
                                ILogger<UserController> logger, IWDWebRepository repository)
        {
            _userManager = userManager;
            _signInManager = signInManager;

            _logger = logger;
            _repository = repository;
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
                    UserName = string.Format("{0} {1}", vm.Name, vm.Surname),
                    Email = vm.Email
                };

                var result = await _userManager.CreateAsync(user, vm.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    RedirectToAction("Index", "Home");
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
        public IActionResult Login(string email, string password)
        {
            if (ModelState.IsValid)
            {
                var hashedPassword = PasswordHasher.GetHashedPassword(password);
                var users = _repository.Users.Where(u => u.Email.Equals(email) && u.Password.Equals(hashedPassword)).ToList();

                if (users.Count > 0)
                {
                    var user = users.FirstOrDefault();

                    _logger.LogTrace(string.Format("{0} {1} succesfully logged in", user.Name, user.Surname));
                    return RedirectToAction("Index", new { id = user.UserID });
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Nieudane logowanie");
                    _logger.LogError(string.Format("Could not log in - user with email: {0} not found", email));
                    return View();
                }
            }
            return View();
        }
        #endregion
    }
}
