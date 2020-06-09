using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UdemiyIdentitiy.Models
{
    public class UserSignUpViewModel
    {
        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "kullanıcı aı boş geçemez")]

        public string UserName { get; set; }

        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Şifre tekrarı boş geçemez")]


        public string Password { get; set; }

        [Display(Name = "Şifre Tekrarı")]
        [Compare("Password", ErrorMessage = "parolalar eşleşmiyor")]

        public string ConfirmPassword { get; set; }

        [Display(Name = "Ad:")]
        [Required(ErrorMessage = "Ad boş geçilemez")]

        public string Name { get; set; }

        [Display(Name = "Soyad")]
        [Required(ErrorMessage = "Soyad boş geçemez")]

        public string SurName { get; set; }


        [Display(Name = "Email:")]
        [Required(ErrorMessage = "Email boşgeçilemez")]

        public string Email { get; set; }

    }
}
