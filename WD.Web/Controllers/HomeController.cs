using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;
using WD.Data.Models;
using WD.Web.Models;
using WD.Web.ViewModels;

namespace VD.Web.Controllers
{
    public class HomeController : Controller
    {
        #region Fields & properties
        private readonly IWDWebRepository _repository;
        private readonly ILogger<HomeController> _logger;
        public IConfiguration Configuration { get; }
        #endregion

        #region Constructors
        public HomeController(ILogger<HomeController> logger, IWDWebRepository repository,
            IConfiguration configuration)
        {
            _logger = logger;
            _repository = repository;

            Configuration = configuration;
        }
        #endregion

        #region Views
        [HttpGet]
        public IActionResult Index(int id)
        {
            User user = _repository.Users.Where(u => u.UserID == id).FirstOrDefault();
            IndexViewModel vm = null;
            if (user != null)
                vm = new IndexViewModel(user);
            return View(vm);
        }

        public IActionResult Logout()
        {
            return RedirectToAction("Login");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        #endregion
    }
}
