using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

            List<TeacherFinalNote> finalNotes = new List<TeacherFinalNote>();
            List<CourseProjectsList> courseProjects = new List<CourseProjectsList>();

            if (courses.Any())
            {
                foreach (var course in courses)
                {
                    //Final Notes
                    var courseStudents = _repository.StudentCourses.Where(sc => sc.CourseId == course.Id);
                    foreach(var studentId in courseStudents.Select(sc => sc.StudentId))
                    {
                        var student = await _userManager.FindByIdAsync(studentId);
                        if (student == null)
                            continue;
                        var finalNote = courseStudents.Where(sc => sc.StudentId == studentId).FirstOrDefault().FinalNote;
                        finalNotes.Add(new TeacherFinalNote()
                        {
                            CourseName = course.Name,
                            Student = student.UserName,
                            FinalNote = finalNote
                        });
                    }


                    //Course Projects
                    var projects = _repository.Projects.Where(p => p.CourseId == course.Id);

                    List<ProjectPresentation> projectPresentations = new List<ProjectPresentation>();

                    foreach (var project in projects)
                    {
                        List<string> students = new List<string>();
                        var studentIds = _repository.ProjectStudents.Where(ps => ps.ProjectId == project.Id);
                        foreach(var studentId in studentIds.Select(ps => ps.StudentId))
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
                        CourseName = course.Name,
                        Projects = projectPresentations
                    });
                }

            }

            TeacherViewModel model = new TeacherViewModel()
            {
                Theses = _repository.Theses.Where(t => t.PromoterId == teacher.Id || t.ReviewerId == teacher.Id),
                FinalNotes = finalNotes,
                Courses = courseProjects
            };

            return View(model);
        }
        #endregion
    }
}
