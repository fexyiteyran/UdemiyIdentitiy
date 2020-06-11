using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UdemiyIdentitiy.Context;

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

        public IActionResult Index()
        {
            return View();
        }
        //herkes erişsin istiyorsak bunu yazarız
        [AllowAnonymous]
        public IActionResult Herkeserisin()
        {
            return View();
        }
    }
}