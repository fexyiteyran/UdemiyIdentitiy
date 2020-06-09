using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UdemiyIdentitiy.Models
{
    public class UserSignInViewModel
    {
        [Display(Name ="Kullanıcı Adı")]
        [Required(ErrorMessage ="kullanıcı aı boş geçemez")]
        public string UserName { get; set; }
        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Şifre alanı boş geçemez")]
        public string Password { get; set; }
    }
}
