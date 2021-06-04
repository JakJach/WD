using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using WD.Web.Models;
using WD.Web.ViewModels;

namespace VD.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IWDWebRepository _repository;
        private readonly ILogger<HomeController> _logger;

        public IConfiguration Configuration { get; }

        public HomeController(ILogger<HomeController> logger, IWDWebRepository repository,
            IConfiguration configuration)
        {
            _logger = logger;
            _repository = repository;

            Configuration = configuration;
        }

        #region Index
        [HttpGet]
        public IActionResult Index()
        {
            var model = new IndexViewModel()
            {
                Classes = _repository.Classes,
                Projects = _repository.Projects,
                Theses = _repository.Theses,
                Files = _repository.Files
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
