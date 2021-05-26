using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using WD.Data.Models;
using WD.Data.Tools;
using WD.Web.Models;
using WD.Web.ViewModels;

namespace WD.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IWDWebRepository _repository;

        public UserController(ILogger<UserController> logger, IWDWebRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var check = _repository.Users.FirstOrDefault(u => u.Email == vm.Email);
                if (check == null)
                {
                    vm.Password = PasswordHasher.GetHashedPassword(vm.Password);

                    User newUser = null;
                    if (vm.IsStudent)
                        newUser = new Student() { Email = vm.Email, Name = vm.Name, Password = vm.Password, Surname = vm.Surname, HasThesis = false };
                    else if (vm.IsTeacher)
                        newUser = new Teacher() { Email = vm.Email, Name = vm.Name, Password = vm.Password, Surname = vm.Surname, CanBePromoter = true, CanBeReviewer = true, Title = null };
                    else
                        newUser = new User() { Email = vm.Email, Name = vm.Name, Password = vm.Password, Surname = vm.Surname };

                    var result = _repository.Add(newUser);

                    _logger.LogInformation(string.Format("New user {0} {1} registered", result.Name, result.Surname));
                    return RedirectToAction("Index", new { id = result.UserID });
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "User with this email address already exists.");
                    _logger.LogError(string.Format("Could not register - user with email address: {0} already exists", vm.Email));
                    return View();
                }
            }
            return View();
        }
    }
}
