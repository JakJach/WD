using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using WD.Data.Models;
using WD.Web.Models;
using WD.Web.ViewModels;

namespace VD.Web.Controllers
{
    public class HomeController : Controller
    {
        #region Fields & properties
        private readonly WDWebContext _context;
        private readonly ILogger<HomeController> _logger;
        public IConfiguration Configuration { get; }
        #endregion

        #region Constructors
        public HomeController(ILogger<HomeController> logger, WDWebContext context,
            IConfiguration configuration)
        {
            _logger = logger;
            _context = context;

            Configuration = configuration;
        }
        #endregion

        #region Views
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(string email, string password)
        {
            if (ModelState.IsValid)
            {
                var hashedPassword = GetHashedPassword(password);
                var users = _context.Users.Where(u => u.Email.Equals(email) && u.Password.Equals(hashedPassword)).ToList();

                if(users.Count > 0)
                {
                    var _user = users.FirstOrDefault();
                    HttpContext.Session.SetString("Name", _user.Name);
                    HttpContext.Session.SetString("Surname", _user.Surname);
                    HttpContext.Session.SetString("Email", _user.Email);
                    HttpContext.Session.SetInt32("UserID", _user.UserID);

                    if (_user.GetType() == typeof(Student))
                        return RedirectToAction("index", "student", _user.UserID);
                    else
                        return RedirectToAction("index", "teacher", _user.UserID);
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
                var check = _context.Users.FirstOrDefault(u => u.Email == _user.Email);
                if(check == null)
                {
                    _user.Password = GetHashedPassword(_user.Password);
                    _context.Users.Add(_user);
                    _context.SaveChanges();
                    return RedirectToAction("index", "home");
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
            return RedirectToAction("index");
        }

        private static string GetHashedPassword(string password)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] source = Encoding.UTF8.GetBytes(password);
            byte[] target = md5.ComputeHash(source);
            string result = null;

            for(int i = 0; i < target.Length; i++)
            {
                result += target[i].ToString("x2");
            }
            return result;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        #endregion

        #region Methods

        #endregion
    }
}
