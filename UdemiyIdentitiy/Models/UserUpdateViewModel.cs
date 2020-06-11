using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UdemiyIdentitiy.Models
{
    public class UserUpdateViewModel
    {
        [Display(Name="Email")]
        [Required(ErrorMessage ="Email alanı gereklidir")]
        [EmailAddress(ErrorMessage ="Lütfen geçerli bir email adresini giriniz")]
        public string Email { get; set; }


        [Display(Name = "Telefon:")]
        public string PhoneNumber { get; set; }

        public string PuctureUrl { get; set; }
        public IFormFile Picture { get; set; }
       
        [Display(Name = "Adı:")]
        [Required(ErrorMessage = "Name alanı gereklidir")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Surname alanı gereklidir")]
        [Display(Name = "Soyisim:")]
        public string SurName { get; set; }
    }
}
