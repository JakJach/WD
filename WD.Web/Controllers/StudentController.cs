using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
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

        public StudentController(ILogger<StudentController> logger, IWDWebRepository repository, IHostEnvironment hostingEnvironment, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _repository = repository;
            _hostingEnvironment = hostingEnvironment;
            _userManager = userManager;
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
                finalNotes.Add(new StudentFinalNote() { FinalNote = sc.FinalNote, CourseName = c.Name, Teacher = teacher.UserName });
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
        //#region Index
        //public IActionResult Index(int id = 1)
        //{
        //    _student = _repository.GetStudent(id);
        //    TempData["studentID"] = id;
        //    StudentViewModel model = new StudentViewModel
        //    {
        //        LoggedInStudent = _student,
        //        StudentClasses = _repository.GetStudentClasses(_student),
        //        StudentProjects = _repository.GetStudentProjects(_student),
        //        StudentThesis = _repository.GetStudentThesis(_student)
        //    };
        //    return View(model);
        //}
        //#endregion

        //#region AddProject
        //[HttpGet]
        //public IActionResult AddProject(int id)
        //{
        //    _student = _repository.GetStudent((int)TempData["studentID"]);
        //    TempData["studentID"] = _student.ID;
        //    if (ModelState.IsValid)
        //    {
        //        StudentAddProjectViewModel model = new StudentAddProjectViewModel();
        //        Project project = _repository.GetProject(id);
        //        Classes classes = _repository.GetClasses(project.ClassesID);
        //        model.ClassesName = classes.Name;
        //        model.Title = project.Name;
        //        TempData["classesName"] = classes.Name;
        //        TempData["title"] = project.Name;
        //        return View(model);
        //    }
        //    return RedirectToAction("index", "student", new { id = _student.ID });
        //}

        //[HttpPost]
        //public IActionResult AddProject(StudentAddProjectViewModel model)
        //{
        //    _student = _repository.GetStudent((int)TempData["studentID"]);
        //    TempData["studentID"] = _student.ID;
        //    string classesName = (string)TempData["classesName"];
        //    if (ModelState.IsValid)
        //    {
        //        if (model.File != null)
        //        {
        //            string uploadFolder = Path.Combine(_hostingEnvironment1.ContentRootPath, "wwwroot", "files");
        //            string fileName = Guid.NewGuid().ToString() + "_" + model.File.FileName;
        //            string filePath = Path.Combine(uploadFolder, fileName);
        //            model.File.CopyTo(new FileStream(filePath, FileMode.Create));

        //            Classes classes = _repository.GetClasses(classesName);
        //            Project project = _repository.GetProject(classes, _student);
        //            project.FileName = fileName;

        //            if (model.Attachments != null)
        //            {
        //                List<string> names = project.AttachmentsName ?? new List<string>();
        //                uploadFolder = Path.Combine(_hostingEnvironment1.ContentRootPath, "wwwroot", "files");
        //                foreach (IFormFile attachment in model.Attachments)
        //                {
        //                    if (!names.Any(n => n.Contains(attachment.FileName)))
        //                    {
        //                        fileName = Guid.NewGuid().ToString() + "_" + attachment.FileName;
        //                        filePath = Path.Combine(uploadFolder, fileName);
        //                        attachment.CopyTo(new FileStream(filePath, FileMode.Create));
        //                        names.Add(fileName);
        //                    }
        //                }
        //                project.AttachmentsName = names;
        //            }
        //            project.IsUploaded = true;
        //            _repository.UpdateProject(project);

        //        }
        //        return RedirectToAction("index", "student", new { id = _student.ID });
        //    }
        //    return View();
        //}
        //#endregion

        //#region AddThesis
        //[HttpGet]
        //public IActionResult AddThesis()
        //{
        //    _student = _repository.GetStudent((int)TempData["studentID"]);
        //    TempData["studentID"] = _student.ID;
        //    if (ModelState.IsValid)
        //    {
        //        StudentAddThesisViewModel model = new StudentAddThesisViewModel();
        //        Thesis thesis = _repository.GetStudentThesis(_student);
        //        model.Thesis = thesis;

        //        model.StudentName = _student.Name + " " + _student.Surname;

        //        Teacher promoter = _repository.GetTeacher(thesis.PromoterID);
        //        model.PromoterName = promoter.Name + " " + promoter.Surname;

        //        Teacher reviewer = _repository.GetTeacher(thesis.ReviewerID);
        //        model.RevieverName = reviewer.Name + " " + reviewer.Surname;

        //        TempData["thesis_id"] = thesis.ID;
        //        return View(model);
        //    }
        //    return RedirectToAction("index", "student", new { id = _student.ID });
        //}

        //[HttpPost]
        //public IActionResult AddThesis(StudentAddThesisViewModel model)
        //{
        //    _student = _repository.GetStudent((int)TempData["studentID"]);
        //    TempData["studentID"] = _student.ID;
        //    model.Thesis = _repository.GetThesis((int)TempData["thesis_id"]);
        //    if (ModelState.IsValid)
        //    {
        //        if (model.File != null)
        //        {
        //            string uploadFolder = Path.Combine(_hostingEnvironment1.ContentRootPath, "wwwroot", "files");
        //            string fileName = Guid.NewGuid().ToString() + "_" + model.File.FileName;
        //            string filePath = Path.Combine(uploadFolder, fileName);
        //            model.File.CopyTo(new FileStream(filePath, FileMode.Create));

        //            Thesis thesis = _repository.GetStudentThesis(_student);
        //            thesis.FileName = fileName;

        //            if (model.Attachments != null)
        //            {
        //                List<string> names = thesis.AttachmentsName ?? new List<string>();
        //                uploadFolder = Path.Combine(_hostingEnvironment1.ContentRootPath, "wwwroot", "files");
        //                foreach (IFormFile attachment in model.Attachments)
        //                {
        //                    if (!names.Any(n => n.Contains(attachment.FileName)))
        //                    {
        //                        fileName = Guid.NewGuid().ToString() + "_" + attachment.FileName;
        //                        filePath = Path.Combine(uploadFolder, fileName);
        //                        attachment.CopyTo(new FileStream(filePath, FileMode.Create));
        //                        names.Add(fileName);
        //                    }
        //                }
        //                thesis.AttachmentsName = names;
        //            }
        //            thesis.IsUploaded = true;
        //            _repository.UpdateThesis(thesis);
        //        }
        //        return RedirectToAction("index", "student", new { id = _student.ID });
        //    }
        //    return View();
        //}
        //#endregion

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
