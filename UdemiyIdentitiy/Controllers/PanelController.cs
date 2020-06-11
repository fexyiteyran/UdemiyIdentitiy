using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using UdemiyIdentitiy.Context;
using UdemiyIdentitiy.Models;

namespace UdemiyIdentitiy.Controllers
{

      [Authorize]
    public class PanelController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        public PanelController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task< IActionResult> Index()
        {

           var user=await  _userManager.FindByNameAsync(User.Identity.Name);
            return View(user);
        }

        public async Task<IActionResult> UpdateUser()
        {

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            UserUpdateViewModel model = new UserUpdateViewModel
            {
                Email=user.Email,
                Name=user.Name,
                SurName = user.SurName,
               PhoneNumber=user.PhoneNumber,
               PuctureUrl=user.PictureUrl
            };
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> UpdateUser(UserUpdateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                if (model.Picture !=null)
                {
                    var uygulamaninCalistigiYer = Directory.GetCurrentDirectory();
                    var uzanti = Path.GetExtension(model.Picture.FileName);
                    var resimad = Guid.NewGuid() + uzanti;
                    var kaydedilecekYer = uygulamaninCalistigiYer + "/wwwroot/img/" + resimad;
                    using var stream = new FileStream(kaydedilecekYer, FileMode.Create);
                    await model.Picture.CopyToAsync(stream);
                    user.PictureUrl = resimad;
                    

                }

                user.Name = model.Name;
                user.SurName = model.SurName;
                user.Email = model.Email;
                user.PhoneNumber = model.PhoneNumber;
               
               var result= await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View(model);
        }


        //herkes erişsin istiyorsak bunu yazarız
        [AllowAnonymous]
        public IActionResult Herkeserisin()
        {
            return View();
        }
    }
}