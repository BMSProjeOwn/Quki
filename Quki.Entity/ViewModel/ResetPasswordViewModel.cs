using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Entity.ViewModel
{
    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name ="Şifre tekrarı")]
        [Compare("Password", ErrorMessage = "Şifre  ve  Şifre tekrarı aynı olmalıdır")]
        public string ConfirmPassword { get; set; }
        public string Token { get; set; }

    }
}
