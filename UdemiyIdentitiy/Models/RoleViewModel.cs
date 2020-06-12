using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UdemiyIdentitiy.Models
{
    public class RoleViewModel
    {
        [Required(ErrorMessage ="Ad Alanı gerej-klidir")]
        [Display(Name ="Ad:")]
        public string Name { get; set; }
    }
}
