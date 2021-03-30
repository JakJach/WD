using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;
using WD.Data.Models;
using WD.Data.Services;
using WD.Web.Models;

namespace VD.Web.Controllers
{
    public class HomeController : Controller
    {
        #region Fields
        private readonly IVDRepository _repository;
        private readonly ILogger<HomeController> _logger;
        public IConfiguration Configuration { get; }

        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        #endregion

        #region Constructors
        public HomeController(ILogger<HomeController> logger, IVDRepository repository,
            IConfiguration configuration, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _repository = repository;
            Configuration = configuration;
            _signInManager = signInManager;
            _userManager = userManager;
        }
        #endregion

        #region Views
        [HttpGet]
        public IActionResult Index()
        {
            var model = new HomeViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(HomeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

                if (result.Succeeded)
                {
                    if (_repository.GetUser(model.Email).IsStudent)
                    {
                        Student student = _repository.GetStudent(model.Email);
                        return RedirectToAction("index", "student", new { id = student.ID });
                    }
                    else
                    {
                        Teacher teacher = _repository.GetTeacher(model.Email);
                        return RedirectToAction("index", "teacher", new { id = teacher.ID });
                    }
                }
                ModelState.AddModelError(string.Empty, "Nieudane logowanie");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(HomeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = model.Email, Email = model.Email, PasswordHash = model.Password };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("index", "home");
                }
            }
            return View(model);
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
