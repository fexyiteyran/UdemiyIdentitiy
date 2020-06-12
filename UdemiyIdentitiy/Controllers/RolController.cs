﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UdemiyIdentitiy.Context;
using UdemiyIdentitiy.Models;

namespace UdemiyIdentitiy.Controllers
{

    [Authorize]
    public class RolController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        public RolController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
               _roleManager=roleManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {

            return View(_roleManager.Roles.ToList());
        }

        public IActionResult AddRole()
        {

            return View(new RoleViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(RoleViewModel model)
        {

            if (ModelState.IsValid)
            {
                AppRole role = new AppRole
                {
                    Name = model.Name
                };
                var identityResult = await _roleManager.CreateAsync(role);
                if (identityResult.Succeeded)
                {
                    return RedirectToAction("Index");
                }

                foreach (var error in identityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }


            }

            return View(model);
        }

       public async  Task<IActionResult> UpdateRole(int id)
        {
          var rol=  _roleManager.Roles.FirstOrDefault(o=>o.Id==id);


            RoleUpdateViewModel model = new RoleUpdateViewModel
            {
                Id=rol.Id,
                Name=rol.Name
            };

            return View(model);
        }

        [HttpPost]

        public async Task<IActionResult> UpdateRole(RoleUpdateViewModel model)
        {
            var tobeUpdateRole = _roleManager.Roles.FirstOrDefault(I=>I.Id== model.Id);
            tobeUpdateRole.Name = model.Name;
             var identityResult=  await _roleManager.UpdateAsync(tobeUpdateRole);
            if (identityResult.Succeeded)
            {
                return RedirectToAction("Index");
            }

            foreach (var error in identityResult.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(model);
        
        }


        public async Task<IActionResult> DeleteRole(int id)
        {
            var tobeDeleteeRole = _roleManager.Roles.FirstOrDefault(I => I.Id == id);
           var identitiyResult=   await _roleManager.DeleteAsync(tobeDeleteeRole);
            if (identitiyResult.Succeeded)
            {
                return RedirectToAction("Index");
            }
            TempData["Errors"] = identitiyResult.Errors;
            return View(tobeDeleteeRole);
        }


        

             public async Task<IActionResult> UserList(int id)
           {
            
            return View(_userManager.Users.ToList());
          }


    }
}