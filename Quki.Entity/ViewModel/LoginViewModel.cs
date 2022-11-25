using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Entity.ViewModel
{
    public class LoginViewModel
    {

        [EmailAddress]
        [Required(ErrorMessage = "Lütfen eposta adresinizi yazın")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Lütfen şifrenizi girin")]
        public string Password { get; set; }
        [Display(Name = "Beni Hatırla")]
        public bool RemmemberMe { get; set; }
    }
}
