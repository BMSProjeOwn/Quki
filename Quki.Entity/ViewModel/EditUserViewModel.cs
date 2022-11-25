using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace Quki.Entity.ViewModel
{
    public class EditUserViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Boş geçilemez")]
        public string Name { get; set; }

        public string SurName { get; set; }

        [Required(ErrorMessage = "Boş geçilemez")]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public List<Role> Roles { get; set; }
    }
    public class Role {
        public string Id { get; set; }
        public string RoleName { get; set; }
        public bool IsSellected { get; set; }
    }
}
