﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WD.Web.ViewModels;

namespace WD.Web.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdministrationController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AdministrationController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
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

        [HttpGet]
        public IActionResult Roles()
        {
            var roles = _roleManager.Roles;
            return View(roles);
        }

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

        #region Edit Role Users
        [HttpGet]
        public async Task<IActionResult> EditRoleUsers(string roleId)
        {
            ViewBag.roleID = roleId;

            var role = await _roleManager.FindByIdAsync(roleId);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with ID = {roleId} was not found";
                return View("NotFound");
            }

            var model = new List<RoleUserViewModel>();

            foreach (var user in _userManager.Users)
            {
                var roleUser = new RoleUserViewModel()
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
        public async Task<IActionResult> EditRoleUsers(List<RoleUserViewModel> model, string roleID)
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
    }
}