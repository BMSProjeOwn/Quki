using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Quki.Entity.Models
{
    public class AppUser : IdentityUser
    {
        [MaxLength(250)]
        public string Name { get; set; }
        [MaxLength(250)]
        public string SurName { get; set; }


    }
}
