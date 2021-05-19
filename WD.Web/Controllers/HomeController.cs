using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;
using WD.Data.Models;
using WD.Data.Tools;
using WD.Web.Models;
using WD.Web.ViewModels;

namespace VD.Web.Controllers
{
    public class HomeController : Controller
    {
        #region Fields & properties
        private readonly IWDWebRepository _repository;
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public IConfiguration Configuration { get; }
        #endregion

        #region Constructors
        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment hostingEnvironment, IWDWebRepository repository,
            IConfiguration configuration)
        {
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
            _repository = repository;

            Configuration = configuration;
        }
        #endregion

        #region Views
        public IActionResult Index(User user)
        {
            return View(new UserViewModel(user));
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string email, string password)
        {
            if (ModelState.IsValid)
            {
                var hashedPassword = PasswordHasher.GetHashedPassword(password);
                var users = _repository.Users.Where(u => u.Email.Equals(email) && u.Password.Equals(hashedPassword)).ToList();

                if(users.Count > 0)
                {
                    var _user = users.FirstOrDefault();
                    HttpContext.Session.SetString("Name", _user.Name);
                    HttpContext.Session.SetString("Surname", _user.Surname);
                    HttpContext.Session.SetString("Email", _user.Email);
                    HttpContext.Session.SetInt32("UserID", _user.UserID);

                    return RedirectToAction("index", "home", _user);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Nieudane logowanie");
                    _logger.LogInformation(string.Format("Home\t|Could not find user with email: {0}", email));
                    return View();
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(User _user)
        {
            if (ModelState.IsValid)
            {
                var check = _repository.Users.FirstOrDefault(u => u.Email == _user.Email);
                if(check == null)
                {
                    _user.Password = PasswordHasher.GetHashedPassword(_user.Password);
                    _repository.Users.Add(_user);
                    return RedirectToAction("login");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "User with this email addres already exists.");
                    return View();
                }
            }
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("login");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        #endregion
    }
}
