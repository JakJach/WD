using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WD.Data.Models;
using WD.Web.Models;
using WD.Web.ViewModels;

namespace WD.Web.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdministrationController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<AdministrationController> _logger;
        private readonly IWDWebRepository _repository;

        public AdministrationController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager,
                                        ILogger<AdministrationController> logger, IWDWebRepository repository)
        {
            _roleManager = roleManager;
            _userManager = userManager;

            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Roles()
        {
            var roles = _roleManager.Roles;
            return View(roles);
        }

        #region Create Role
        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole { Name = model.RoleName };

                IdentityResult result = await _roleManager.CreateAsync(role);

                if (result.Succeeded)
                    return RedirectToAction("Roles", "Administration");

                foreach (var error in result.Errors)
                    ModelState.AddModelError("", error.Description);
            }

            return View(model);
        }
        #endregion

        #region Edit Role
        [HttpGet]
        public async Task<IActionResult> EditRole(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with ID = {id} was not found";
                return View("NotFound");
            }

            var model = new EditRoleViewModel()
            {
                ID = role.Id,
                Name = role.Name,
            };

            foreach (var user in _userManager.Users)
            {
                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    model.Users.Add(user.UserName);
                }
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditRole(EditRoleViewModel model)
        {
            var role = await _roleManager.FindByIdAsync(model.ID);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with ID = {model.ID} was not found";
                return View("NotFound");
            }
            else
            {
                role.Name = model.Name;
                var result = await _roleManager.UpdateAsync(role);

                if (result.Succeeded)
                {
                    return RedirectToAction("Roles");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }
        #endregion

        #region Delete Role
        [HttpPost]
        public async Task<IActionResult> DeleteRole(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with ID = {id} was not found";
                return View("NotFound");
            }
            else
            {
                try
                {
                    var result = await _roleManager.DeleteAsync(role);

                    if (result.Succeeded)
                        return RedirectToAction("Roles", "Administration");

                    foreach (var error in result.Errors)
                        ModelState.AddModelError("", error.Description);

                    return View("Roles");
                }
                catch (DbUpdateException ex)
                {
                    _logger.LogError($"Error occured while deleting role  {ex.Message}");
                    ViewBag.ErrorTitle = $"{role.Name} role is in use.";
                    ViewBag.ErrorMessage = $"{role.Name} role cannot be deleted as there are users in this role." +
                        $"If you want to delete this role, please remove the users from the role and then try to delete";
                    return View("Error");
                }
            }
        }
        #endregion

        #region Manage Role Users
        [HttpGet]
        public async Task<IActionResult> ManageRoleUsers(string roleId)
        {
            ViewBag.roleID = roleId;

            var role = await _roleManager.FindByIdAsync(roleId);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with ID = {roleId} was not found";
                return View("NotFound");
            }

            var model = new List<ManageUsersViewModel>();

            foreach (var user in _userManager.Users)
            {
                var roleUser = new ManageUsersViewModel()
                {
                    UserID = user.Id,
                    UserName = user.UserName
                };

                if (await _userManager.IsInRoleAsync(user, role.Name))
                    roleUser.IsSelected = true;
                else
                    roleUser.IsSelected = false;

                model.Add(roleUser);
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ManageRoleUsers(List<ManageUsersViewModel> model, string roleID)
        {
            var role = await _roleManager.FindByIdAsync(roleID);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with ID = {roleID} was not found";
                return View("NotFound");
            }

            foreach (var roleUser in model)
            {
                var user = await _userManager.FindByIdAsync(roleUser.UserID);

                IdentityResult result = null;

                if (roleUser.IsSelected && !await _userManager.IsInRoleAsync(user, role.Name))
                    result = await _userManager.AddToRoleAsync(user, role.Name);
                else if (!roleUser.IsSelected && await _userManager.IsInRoleAsync(user, role.Name))
                    result = await _userManager.RemoveFromRoleAsync(user, role.Name);
                else
                    continue;

                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                        ModelState.AddModelError("", error.Description);
                }
            }

            return RedirectToAction("EditRole", "Administration", new { Id = roleID });
        }
        #endregion

        [HttpGet]
        public IActionResult Users()
        {
            var users = _userManager.Users;
            return View(users);
        }

        #region Edit User
        [HttpGet]
        public async Task<IActionResult> EditUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with ID = {id} was not found";
                return View("NotFound");
            }

            var userRoles = await _userManager.GetRolesAsync(user);
            var userClaims = await _userManager.GetClaimsAsync(user);

            var model = new EditUserViewModel()
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Roles = (List<string>)userRoles,
                Claims = userClaims.Select(c => c.Value).ToList()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(EditUserViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.Id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with ID = {model.Id} was not found";
                return View("NotFound");
            }
            else
            {
                user.Email = model.Email;
                user.UserName = model.UserName;

                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                    return RedirectToAction("Users", "Administration");

                foreach (var error in result.Errors)
                    ModelState.AddModelError("", error.Description);

                return View(model);
            }
        }
        #endregion

        #region Delete User
        [HttpPost]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with ID = {id} was not found";
                return View("NotFound");
            }
            else
            {
                var result = await _userManager.DeleteAsync(user);

                if (result.Succeeded)
                    return RedirectToAction("Users", "Administration");

                foreach (var error in result.Errors)
                    ModelState.AddModelError("", error.Description);

                return View("Users");
            }
        }
        #endregion

        #region Manage User Roles
        [HttpGet]
        public async Task<IActionResult> ManageUserRoles(string userId)
        {
            ViewBag.UserID = userId;

            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with ID = {userId} was not found";
                return View("NotFound");
            }

            var model = new List<ManageUserRolesViewModel>();

            foreach (var role in _roleManager.Roles)
            {
                var userRole = new ManageUserRolesViewModel()
                {
                    RoleId = role.Id,
                    RoleName = role.Name
                };

                if (await _userManager.IsInRoleAsync(user, role.Name))
                    userRole.IsSelected = true;
                else
                    userRole.IsSelected = false;

                model.Add(userRole);
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ManageUserRoles(List<ManageUserRolesViewModel> model, string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with ID = {userId} was not found";
                return View("NotFound");
            }

            var roles = await _userManager.GetRolesAsync(user);
            var result = await _userManager.RemoveFromRolesAsync(user, roles);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot remove this user's roles");
                return View(model);
            }

            result = await _userManager.AddToRolesAsync(user, model.Where(r => r.IsSelected).Select(r => r.RoleName));

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot add new roles to this user");
                return View(model);
            }

            return RedirectToAction("EditUser", "Administration", new { Id = userId });
        }
        #endregion

        #region Manage User Claims
        [HttpGet]
        public async Task<IActionResult> ManageUserClaims(string userId)
        {
            ViewBag.UserID = userId;

            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with ID = {userId} was not found";
                return View("NotFound");
            }

            var model = new List<ManageUserClaimsViewModel>();

            var claims = await _userManager.GetClaimsAsync(user);

            foreach (var claim in Claims.AllClaims)
            {
                var userClaim = new ManageUserClaimsViewModel()
                {
                    ClaimType = claim.Type,
                    IsSelected = claims.Any(c => c.Type == claim.Type)
                };

                model.Add(userClaim);
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ManageUserClaims(List<ManageUserClaimsViewModel> model, string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with ID = {userId} was not found";
                return View("NotFound");
            }

            var claims = await _userManager.GetClaimsAsync(user);
            var result = await _userManager.RemoveClaimsAsync(user, claims);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot remove this user's claims");
                return View(model);
            }

            var claimsToAdd = Claims.AllClaims.Where(c => model.Where(c => c.IsSelected).Select(c => c.ClaimType).ToList().Contains(c.Type));
            result = await _userManager.AddClaimsAsync(user, claimsToAdd);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot add new claims to this user");
                return View(model);
            }

            return RedirectToAction("EditUser", "Administration", new { Id = userId });
        }
        #endregion

        [HttpGet]
        public async Task<IActionResult> Courses()
        {
            var courses = new List<CourseViewModel>();

            foreach (var course in _repository.Courses)
            {
                courses.Add(new CourseViewModel()
                {
                    CourseId = course.Id,
                    Name = course.Name,
                    Teacher = course.TeacherId != null ? (await _userManager.FindByIdAsync(course.TeacherId)).UserName : "Teacher not assigned"
                });
            }

            return View(courses);
        }

        #region Create Course
        [HttpGet]
        public async Task<IActionResult> CreateCourse()
        {
            var teachers = await _userManager.GetUsersInRoleAsync("Teacher");
            List<SelectListItem> options = new List<SelectListItem>();
            foreach (var t in teachers)
            {
                options.Add(new SelectListItem(t.UserName, t.Id));
            }
            var model = new CreateCourseViewModel()
            {
                Teachers = options
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult CreateCourse(CreateCourseViewModel model)
        {
            if (ModelState.IsValid)
            {
                Course course = new Course()
                {
                    Name = model.Name,
                    TeacherId = model.SelectedTeacher
                };

                var result = _repository.Add(course);

                if (result != null)
                    return RedirectToAction("Courses", "Administration");

                ModelState.AddModelError("", "Could not create specified course");
            }

            return View(model);
        }
        #endregion

        #region Edit Course
        [HttpGet]
        public async Task<IActionResult> EditCourse(int id)
        {
            var course = _repository.Courses.Where(c => c.Id == id).FirstOrDefault();

            if (course == null)
            {
                ViewBag.ErrorMessage = $"Course with ID = {id} was not found";
                return View("NotFound");
            }

            var teacher = await _userManager.FindByIdAsync(course.TeacherId);

            var model = new EditCourseViewModel()
            {
                Id = course.Id,
                Name = course.Name,
                SelectedTeacher = teacher?.UserName,
                SelectedTeacherId = teacher?.Id
            };

            var teachers = await _userManager.GetUsersInRoleAsync("Teacher");
            foreach (var t in teachers)
            {
                model.Teachers.Add(new SelectListItem(t.UserName, t.Id));
            }

            var studentIds = _repository.StudentCourses.Where(sc => sc.CourseId == course.Id).Select(sc => sc.StudentId);

            foreach (var student in studentIds)
            {
                model.Students.Add((await _userManager.FindByIdAsync(student)).UserName);
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult EditCourse(EditCourseViewModel model)
        {
            var course = _repository.Courses.Where(c => c.Id == model.Id).FirstOrDefault();

            if (course == null)
            {
                ViewBag.ErrorMessage = $"Course with ID = {model.Id} was not found";
                return View("NotFound");
            }
            else
            {
                course.Name = model.Name;
                course.TeacherId = model.SelectedTeacherId;
                var result = _repository.Update(course);

                if (result != null)
                {
                    return RedirectToAction("Courses");
                }

                ModelState.AddModelError("", "Could not save changes for specified course");
            }

            return View(model);
        }
        #endregion

        #region Manage Course Students
        [HttpGet]
        public async Task<IActionResult> ManageCourseStudents(int id)
        {
            ViewBag.courseId = id;

            var course = _repository.Courses.Where(c => c.Id == id).FirstOrDefault();

            if (course == null)
            {
                ViewBag.ErrorMessage = $"Course with ID = {id} was not found";
                return View("NotFound");
            }

            var courseStudentIds = _repository.StudentCourses.Where(sc => sc.CourseId == id).Select(sc => sc.StudentId);

            var model = new List<ManageUsersViewModel>();

            foreach (var user in _userManager.Users)
            {
                if (await _userManager.IsInRoleAsync(user, "Student"))
                {
                    var student = new ManageUsersViewModel()
                    {
                        UserID = user.Id,
                        UserName = user.UserName
                    };

                    if (courseStudentIds.Contains(user.Id))
                        student.IsSelected = true;
                    else
                        student.IsSelected = false;

                    model.Add(student);
                }

            }

            return View(model);
        }

        [HttpPost]
        public IActionResult ManageCourseStudents(List<ManageUsersViewModel> model, int id)
        {
            var course = _repository.Courses.Where(c => c.Id == id).FirstOrDefault();

            if (course == null)
            {
                ViewBag.ErrorMessage = $"Course with ID = {id} was not found";
                return View("NotFound");
            }

            var toRemove = _repository.StudentCourses.Where(sc => sc.CourseId == id);
            if (toRemove != null)
                foreach (var item in toRemove)
                    _repository.Delete(item);

            foreach (var student in model)
            {
                StudentCourses result = null;

                if (student.IsSelected)
                {
                    result = _repository.Add(new StudentCourses() { CourseId = id, StudentId = student.UserID });
                    if (result == null)
                    {
                        ModelState.AddModelError("", $"Could not add user {student.UserName} to specified course.");
                        _logger.LogError($"Could not add user {student.UserName} to specified course.");
                    }
                }
                else
                    continue;
            }

            return RedirectToAction("EditCourse", "Administration", new { Id = id });
        }
        #endregion
    }
}
