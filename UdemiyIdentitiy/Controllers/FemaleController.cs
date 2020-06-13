﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UdemiyIdentitiy.Context;

namespace UdemiyIdentitiy.Controllers
{
    public class FemaleController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        public FemaleController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [Authorize(Policy = "FemaliPoliciy")]
        public IActionResult Index()
        {

            return View();
        }

        public async Task<IActionResult> AddClaim(int id)
        {
            var user = _userManager.Users.FirstOrDefault(I => I.Id == id);

            if ((await _userManager.GetClaimsAsync(user)).Count == 0)
            {
            Claim claim = new Claim("gender", "female");
            await _userManager.AddClaimAsync(user,claim);
            }

          

            return RedirectToAction("UserList", "Rol");
        }



    }
}