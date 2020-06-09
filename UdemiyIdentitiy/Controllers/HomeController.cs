using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UdemiyIdentitiy.Context;
using UdemiyIdentitiy.Models;

namespace UdemiyIdentitiy.Controllers
{
    public class HomeController : Controller
    {

        private readonly UserManager<AppUser> _userManager;
       
        public HomeController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }


        public IActionResult Index()
        {
            return View(new UserSignInViewModel());
        }
        public IActionResult GirisYap(UserSignInViewModel model)
        {

            if (ModelState.IsValid)
            {

            }

            return View("Index", model);
        }

        public IActionResult KayitOl()
        {
            return View(new UserSignUpViewModel());
        }
        [HttpPost]
        


       [HttpPost]   
        public  async Task<IActionResult> KayitOl(UserSignUpViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser
                {
             
                    Name=model.Name,
                    SurName=model.SurName,
                    UserName=model.UserName,
                    Email = model.Email
                };

                var result = await _userManager.CreateAsync(user, model.Password);


                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }


            }
          


            return View(model);
        }

        public IActionResult kayit()
        {

            return View();
        }

    }
}