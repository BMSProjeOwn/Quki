using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Quki.Entity.DtoModels
{
    public class ActivationCodeModel
    {
        [MaxLength(250)]
        [Required]
        public string Email { get; set; }
        [MaxLength(250)]
        public string ActivationCode { get; set; }


    }
}
