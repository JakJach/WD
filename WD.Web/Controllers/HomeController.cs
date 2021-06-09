using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using WD.Web.Models;
using WD.Web.ViewModels;

namespace VD.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IWDWebRepository _repository;
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<IdentityUser> _userManager;
        public IConfiguration Configuration { get; }

        public HomeController(ILogger<HomeController> logger, IWDWebRepository repository, UserManager<IdentityUser> userManager,
            IConfiguration configuration)
        {
            _logger = logger;
            _repository = repository;
            _userManager = userManager;

            Configuration = configuration;
        }

        #region Index
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                _logger.LogError($"User {User.Identity.Name} was not found in database");
                ViewBag.ErrorMessage = $"User {User.Identity.Name} was not found in database";
                return View("NotFound");
            }

            var userRoles = await _userManager.GetRolesAsync(user);

            var model = new HomeViewModel()
            {
                UserId = user.Id,
                Username = user.NormalizedUserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Roles = (List<string>)userRoles
            };

            return View(model);
        }
        #endregion

        #region Error
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        #endregion
    }
}
