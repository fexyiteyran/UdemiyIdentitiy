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
        private readonly SignInManager<AppUser> _signInManager;
        public HomeController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;

        }


        public IActionResult Index()
        {
            return View(new UserSignInViewModel());
        }
        public async Task< IActionResult> GirisYap(UserSignInViewModel model)
        {

            if (ModelState.IsValid)
            {

                //identityResult.IsLockedOut;
                //identityResult.IsNotAllowed(ikiadılıdoğrulamada kullanılır) gibi durumlar dönebilri
                var identityResult=   await _signInManager.PasswordSignInAsync(model.UserName,model.Password,model.RememberMe,true);

                if (identityResult.IsLockedOut)
                {
                    ModelState.AddModelError("","Beş kere yanlış girdiğiniz için hesaabınız kilitlenmiştir");
                    return View("Index",model);
;                }


                if (identityResult.Succeeded)
                {
                    return RedirectToAction("Index","Panel");
                }

                var yanlisGirilmeSayisi = await _userManager.GetAccessFailedCountAsync(await _userManager.FindByNameAsync(model.UserName) );

                ModelState.AddModelError("",$"Kullanıcı adı veya şifre {5-yanlisGirilmeSayisi} kadar yanlis gireseniz şifreniz kilitlenir");

                


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