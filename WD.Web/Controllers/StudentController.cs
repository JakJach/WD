using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WD.Data.Models;
using WD.Data.Presentation;
using WD.Web.Models;
using WD.Web.ViewModels;

namespace WD.Web.Controllers
{
    [Authorize(Roles = "Student")]
    public class StudentController : Controller
    {
        private readonly ILogger<StudentController> _logger;
        private readonly IWDWebRepository _repository;
        private readonly IHostEnvironment _hostingEnvironment;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly string _uploadFolder;

        public StudentController(ILogger<StudentController> logger, IWDWebRepository repository, IHostEnvironment hostingEnvironment, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _repository = repository;
            _hostingEnvironment = hostingEnvironment;
            _userManager = userManager;

            _uploadFolder = Path.Combine(_hostingEnvironment.ContentRootPath, "wwwroot", "files");
        }

        #region Index
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var student = await _userManager.GetUserAsync(User);

            if (student == null)
            {
                _logger.LogError($"Student {User.Identity.Name} was not found in database");
                ViewBag.ErrorMessage = $"Student {User.Identity.Name} was not found in database";
                return View("NotFound");
            }

            var studentClasses = _repository.StudentCourses.Where(sc => sc.StudentId == student.Id);
            List<StudentFinalNote> finalNotes = new List<StudentFinalNote>();
            foreach (var sc in studentClasses)
            {
                Course c = _repository.Courses.Where(c => c.Id == sc.CourseId).FirstOrDefault();
                var teacher = await _userManager.FindByIdAsync(c.TeacherId);
                finalNotes.Add(
                    new StudentFinalNote()
                    {
                        FinalNote = sc.FinalNote,
                        CourseName = c.Name,
                        Teacher = teacher?.UserName
                    });
            }

            var studentProjects = _repository.ProjectStudents.Where(ps => ps.StudentId == student.Id);
            List<Project> projects = new List<Project>();
            foreach (var sp in studentProjects)
                projects.Add(_repository.Projects.Where(p => p.Id == sp.ProjectId).FirstOrDefault());

            var model = new StudentViewModel()
            {
                Thesis = _repository.Theses.Where(t => t.StudentId == student.Id).FirstOrDefault(),
                FinalNotes = finalNotes,
                Projects = projects
            };

            return View(model);
        }
        #endregion

        #region Submit Thesis
        [HttpGet]
        public async Task<IActionResult> SubmitThesis(int id)
        {
            var thesis = _repository.Theses.Where(t => t.Id == id).FirstOrDefault();

            if (thesis == null)
            {
                ViewBag.ErrorMessage = $"Thesis with ID = {id} was not found";
                return View("NotFound");
            }

            var student = await _userManager.FindByIdAsync(thesis.StudentId);
            var promoter = await _userManager.FindByIdAsync(thesis.PromoterId);
            var reviewer = await _userManager.FindByIdAsync(thesis.ReviewerId);

            var model = new SubmitThesisViewModel()
            {
                Id = thesis.Id,
                Student = student.UserName,
                Promoter = promoter.UserName,
                Reviever = reviewer.UserName,
                Title = thesis.Title
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SubmitThesis(SubmitThesisViewModel model)
        {
            var user = await _userManager.GetUserAsync(User);

            var thesis = _repository.Theses.Where(t => t.Id == model.Id).FirstOrDefault();

            if (thesis == null)
            {
                ViewBag.ErrorMessage = $"Thesis with ID = {model.Id} was not found";
                return View("NotFound");
            }

            try
            {
                foreach (var file in model.Files)
                {
                    string fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                    string filePath = Path.Combine(_uploadFolder, fileName);
                    file.CopyTo(new FileStream(filePath, FileMode.Create));

                    _repository.Add(new Data.Models.File() { FileName = fileName, UploadDate = DateTime.Now });

                    var fileId = _repository.Files.Where(f => f.FileName == fileName).FirstOrDefault().Id;

                    _repository.Add(new ThesisFile() { ThesisId = thesis.Id, FileId = fileId });
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Could not save changes for the specified thesis");

                return View(model);
            }

            return RedirectToAction("Index", "Student");
        }
        #endregion

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
