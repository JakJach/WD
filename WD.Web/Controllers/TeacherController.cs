using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
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
                Theses = _repository.Theses.Where(t => t.PromoterId == teacher.Id || t.ReviewerId == teacher.Id),
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
                    IsTaken = model.SelectedStudent != null,
                    ReviewerId = model.SelectedReviewer,
                    Scope = model.Scope,
                    StudentQualifications = model.StudentQualifications,
                    StudentId = model.SelectedStudent,
                    PromoterId = user.Id
                };

                var result = _repository.Add(thesis);

                if (result != null)
                    return RedirectToAction("Index", "Teacher");

                ModelState.AddModelError("", "Could not create specified thesis");
            }

            return View(model);
        }
        #endregion
    }
}
