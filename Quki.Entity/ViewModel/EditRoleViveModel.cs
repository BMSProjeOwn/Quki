using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Entity.ViewModel
{
    public class EditRoleViveModel
    {

        public string Id { get; set; }
        [Required(ErrorMessage ="Rol adı zorunlu")]
        public string RoleName { get; set; }
        public List<UserRoleViewModel> userRoleViewModel { get; set; }
    }
}
