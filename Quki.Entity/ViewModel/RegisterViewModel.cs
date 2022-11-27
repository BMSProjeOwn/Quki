using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Entity.ViewModel
{
    public class RegisterViewModel
    {


        [Required(ErrorMessage = "Lütfen eposta adresinizi yazın")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Lütfen şifrenizi yazın.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Girdiğiniz şifreler birbiriyle uyuşmamaktadır.")]
        public string ConfirmPassword { get; set; }
        public List<ProtoectInformationGetModel> ProtoectInformationGetModels { get; set; }


    }

}
