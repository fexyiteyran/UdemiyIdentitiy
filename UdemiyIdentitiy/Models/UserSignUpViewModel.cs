﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UdemiyIdentitiy.Models
{
    public class UserSignUpViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
       
    }
}
