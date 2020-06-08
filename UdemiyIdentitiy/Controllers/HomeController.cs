using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UdemiyIdentitiy.Models;

namespace UdemiyIdentitiy.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(new UserSignInViewModel());
        }


        public IActionResult KayitOl()
        {
            return View(new UserSignUpViewModel());
        }





    }
}