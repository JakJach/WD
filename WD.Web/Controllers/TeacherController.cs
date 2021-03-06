using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WD.Data.Models;
using WD.Data.Presentation;
using WD.Web.Models;
using WD.Web.ViewModels;

namespace WD.Web.Controllers
{
    [Authorize(Roles = "Teacher, Administrator")]
    public class TeacherController : Controller
    {
        private readonly ILogger<TeacherController> _logger;
        private readonly IWDWebRepository _repository;
        private readonly IHostEnvironment _hostingEnvironment;
        private readonly UserManager<IdentityUser> _userManager;

        public TeacherController(ILogger<TeacherController> logger, IWDWebRepository repository, IHostEnvironment hostingEnvironment, UserManager<IdentityUser> userManager)
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
            var teacher = await _userManager.GetUserAsync(User);

            if (teacher == null)
            {
                _logger.LogError($"Teacher {User.Identity.Name} was not found in database");
                ViewBag.ErrorMessage = $"Teacher {User.Identity.Name} was not found in database";
                return View("NotFound");
            }

            var courses = _repository.Courses.Where(c => c.TeacherId == teacher.Id);

            List<TeacherCourseFinal> finals = new List<TeacherCourseFinal>();
            List<CourseProjectsList> courseProjects = new List<CourseProjectsList>();

            if (courses.Any())
            {
                foreach (var course in courses)
                {
                    //Final Notes
                    var courseStudents = _repository.StudentCourses.Where(sc => sc.CourseId == course.Id);
                    List<TeacherFinalNote> finalNotes = new List<TeacherFinalNote>();

                    foreach (var studentId in courseStudents.Select(sc => sc.StudentId))
                    {
                        var student = await _userManager.FindByIdAsync(studentId);
                        if (student == null)
                            continue;
                        var finalNote = courseStudents.Where(sc => sc.StudentId == studentId).FirstOrDefault().FinalNote;
                        finalNotes.Add(new TeacherFinalNote() { Student = student.UserName, StudentId = studentId, FinalNote = finalNote });
                    }
                    finals.Add(new TeacherCourseFinal()
                    {
                        CourseId = course.Id,
                        CourseName = course.Name,
                        FinalNotes = finalNotes
                    });

                    //Course Projects
                    var projects = _repository.Projects.Where(p => p.CourseId == course.Id);

                    List<ProjectPresentation> projectPresentations = new List<ProjectPresentation>();

                    foreach (var project in projects)
                    {
                        List<string> students = new List<string>();
                        var studentIds = _repository.ProjectStudents.Where(ps => ps.ProjectId == project.Id);
                        foreach (var studentId in studentIds.Select(ps => ps.StudentId))
                        {
                            var student = await _userManager.FindByIdAsync(studentId);
                            if (student != null)
                                students.Add(student.UserName);
                        }

                        projectPresentations.Add(new ProjectPresentation()
                        {
                            Goal = project.Goal,
                            IsSubmitted = project.IsSubmitted,
                            ProjectId = project.Id,
                            ProjectName = project.Title,
                            Note = project.Note,
                            Review = project.Review,
                            Scope = project.Scope,
                            SubmissionDate = project.SubmissionDate,
                            Students = students
                        });
                    }

                    courseProjects.Add(new CourseProjectsList()
                    {
                        CourseId = course.Id,
                        CourseName = course.Name,
                        Projects = projectPresentations
                    });
                }
            }

            TeacherViewModel model = new TeacherViewModel()
            {
                Courses = courseProjects,
                PromotedTheses = _repository.Theses.Where(t => t.PromoterId == teacher.Id),
                ReviewedTheses = _repository.Theses.Where(t => t.ReviewerId == teacher.Id),
                Finals = finals
            };

            return View(model);
        }
        #endregion

        #region Create Thesis
        [HttpGet]
        public async Task<IActionResult> CreateThesis()
        {
            var user = await _userManager.GetUserAsync(User);

            var teachers = await _userManager.GetUsersInRoleAsync("Teacher");
            List<SelectListItem> reviewerOptions = new List<SelectListItem>();
            foreach (var t in teachers)
            {
                reviewerOptions.Add(new SelectListItem(t.UserName, t.Id));
            }

            reviewerOptions.RemoveAll(ro => ro.Text == user.UserName || ro.Value == user.Id);

            var students = await _userManager.GetUsersInRoleAsync("Student");
            List<SelectListItem> studentOptions = new List<SelectListItem>();
            foreach (var s in students)
            {
                studentOptions.Add(new SelectListItem(s.UserName, s.Id));
            }

            var model = new CreateThesisViewModel()
            {
                Reviewers = reviewerOptions,
                Students = studentOptions
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateThesis(CreateThesisViewModel model)
        {
            var user = await _userManager.GetUserAsync(User);

            if (ModelState.IsValid)
            {
                Thesis thesis = new Thesis()
                {
                    Title = model.Title,
                    CreationDate = DateTime.Now,
                    Goal = model.Goal,
                    ReviewerId = model.SelectedReviewer,
                    Scope = model.Scope,
                    StudentQualifications = model.StudentQualifications,
                    PromoterId = user.Id
                };

                if (model.SelectedStudent != null)
                {
                    thesis.StudentId = model.SelectedStudent;
                    thesis.IsTaken = true;
                    thesis.TakeDate = DateTime.Now;
                }

                var result = _repository.Add(thesis);

                if (result != null)
                    return RedirectToAction("Index", "Teacher");

                ModelState.AddModelError("", "Could not create specified thesis");
            }

            return View(model);
        }
        #endregion

        #region Edit Thesis
        [HttpGet]
        public async Task<IActionResult> EditThesis(int id)
        {
            var thesis = _repository.Theses.Where(t => t.Id == id).FirstOrDefault();

            if (thesis == null)
            {
                ViewBag.ErrorMessage = $"Thesis with ID = {id} was not found";
                return View("NotFound");
            }

            var user = await _userManager.GetUserAsync(User);

            var teachers = await _userManager.GetUsersInRoleAsync("Teacher");
            List<SelectListItem> reviewerOptions = new List<SelectListItem>();
            foreach (var t in teachers)
            {
                reviewerOptions.Add(new SelectListItem(t.UserName, t.Id));
            }

            reviewerOptions.RemoveAll(ro => ro.Text == user.UserName || ro.Value == user.Id);

            var students = await _userManager.GetUsersInRoleAsync("Student");
            List<SelectListItem> studentOptions = new List<SelectListItem>();
            foreach (var s in students)
            {
                studentOptions.Add(new SelectListItem(s.UserName, s.Id));
            }

            var model = new EditThesisViewModel()
            {
                Id = id,
                Goal = thesis.Goal,
                Scope = thesis.Scope,
                Title = thesis.Title,
                StudentQualifications = thesis.StudentQualifications,
                SelectedStudent = (await _userManager.FindByIdAsync(thesis.StudentId)).UserName,
                SelectedReviewer = (await _userManager.FindByIdAsync(thesis.ReviewerId)).UserName,
                Reviewers = reviewerOptions,
                Students = studentOptions
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditThesis(EditThesisViewModel model)
        {
            var user = await _userManager.GetUserAsync(User);

            var thesis = _repository.Theses.Where(t => t.Id == model.Id).FirstOrDefault();

            if (thesis == null)
            {
                ViewBag.ErrorMessage = $"Thesis with ID = {model.Id} was not found";
                return View("NotFound");
            }
            else
            {
                thesis.Title = model.Title;
                thesis.Goal = model.Goal;
                thesis.ReviewerId = model.SelectedReviewer;
                thesis.Scope = model.Scope;
                thesis.StudentQualifications = model.StudentQualifications;
                thesis.StudentId = model.SelectedStudent;
                thesis.PromoterId = user.Id;

                if (model.SelectedStudent != null)
                {
                    thesis.IsTaken = true;
                    thesis.TakeDate = DateTime.Now;
                }

                var result = _repository.Update(thesis);

                if (result != null)
                    return RedirectToAction("Index", "Teacher");

                ModelState.AddModelError("", "Could not save changes for the specified thesis");
            }

            return View(model);
        }
        #endregion

        #region Review Thesis
        [HttpGet]
        public async Task<IActionResult> ReviewThesis(int id)
        {
            var thesis = _repository.Theses.Where(c => c.Id == id).FirstOrDefault();

            if (thesis == null)
            {
                ViewBag.ErrorMessage = $"Thesis with ID = {id} was not found";
                return View("NotFound");
            }

            var student = await _userManager.FindByIdAsync(thesis.StudentId);
            var promoter = await _userManager.FindByIdAsync(thesis.PromoterId);
            var reviewer = await _userManager.FindByIdAsync(thesis.ReviewerId);

            var fileIds = _repository.ThesisFiles.Where(tf => tf.ThesisId == thesis.Id).Select(tf => tf.FileId);
            var filenames = _repository.Files.Where(f => fileIds.Contains(f.Id)).Select(f => f.FileName);

            var model = new ReviewThesisViewModel()
            {
                Student = student.UserName,
                Promoter = promoter.UserName,
                Reviewer = reviewer.UserName,
                Title = thesis.Title,
                Id = thesis.Id,
                Files = filenames
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ReviewThesis(ReviewThesisViewModel model)
        {
            var user = await _userManager.GetUserAsync(User);

            var thesis = _repository.Theses.Where(c => c.Id == model.Id).FirstOrDefault();

            if (thesis == null)
            {
                ViewBag.ErrorMessage = $"Thesis with ID = {model.Id} was not found";
                return View("NotFound");
            }

            if (thesis.PromoterId == user.Id)
            {
                thesis.PromoterNote = model.Note;
                thesis.PromoterOpinion = model.Review;
                thesis.AcceptationDate = DateTime.Now;
                thesis.IsAccepted = true;
            }
            else if (thesis.ReviewerId == user.Id)
            {
                thesis.ReviewerNote = model.Note;
                thesis.Review = model.Review;
                thesis.ReviewDate = DateTime.Now;
                thesis.IsReviewed = true;
            }

            var result = _repository.Update(thesis);

            if (result != null)
                return RedirectToAction("Index", "Teacher");

            ModelState.AddModelError("", "Could not save changes for the specified thesis");

            return View(model);
        }
        #endregion

        #region Add Final Note
        [HttpGet]
        public async Task<IActionResult> AddFinalNote(string studentid, int courseid)
        {
            var course = _repository.Courses.Where(c => c.Id == courseid).FirstOrDefault();

            if (course == null)
            {
                ViewBag.ErrorMessage = $"Course with ID = {courseid} was not found";
                return View("NotFound");
            }

            var student = await _userManager.FindByIdAsync(studentid);

            if (student == null)
            {
                ViewBag.ErrorMessage = $"Student with ID = {studentid} was not found";
                return View("NotFound");
            }

            var model = new AddFinalNoteViewModel()
            {
                CourseId = course.Id,
                Course = course.Name,
                Student = student.UserName,
                StudentId = student.Id
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddFinalNote(AddFinalNoteViewModel model)
        {
            var course = _repository.Courses.Where(c => c.Id == model.CourseId).FirstOrDefault();

            if (course == null)
            {
                ViewBag.ErrorMessage = $"Course with ID = {model.CourseId} was not found";
                return View("NotFound");
            }

            var student = await _userManager.FindByIdAsync(model.StudentId);

            if (student == null)
            {
                ViewBag.ErrorMessage = $"Student with ID = {model.StudentId} was not found";
                return View("NotFound");
            }

            var finalNote = new StudentCourses()
            {
                StudentId = student.Id,
                CourseId = course.Id,
                FinalNote = model.Note
            };

            var copies = _repository.StudentCourses.Where(sc => sc.CourseId == course.Id && sc.StudentId == student.Id);
            if (copies != null)
                foreach (var copy in copies)
                    _repository.Delete(copy);

            var result = _repository.Add(finalNote);

            if (result != null)
                return RedirectToAction("Index", "Teacher");

            ModelState.AddModelError("", "Could not add final note for specified course/student");

            return View(model);
        }
        #endregion

        [HttpGet]
        public async Task<IActionResult> Download(string filename)
        {
            if (filename == null)
                return Content("Filename not present");

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files", filename);

            var memory = new MemoryStream();

            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));
        }

        #region Methods
        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }

        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt","text/plain" },
                {".pdf","application/pdf" },
                {".doc","application/vnd.ms-word" },
                {".docx","application/vnd.ms-word" },
                {".xls","application/vnd.ms-excel" },
                {".xlsx","application/vnd.openxmlformats officedocument.spreadsheetml.sheet" },
                {".png","image/png" },
                {".jpg","image/jpeg" },
                {".jpeg","image/jpeg" },
                {".gif","image/gif" },
                {".csv","text/csv" }
            };
        }
        #endregion
    }
}
