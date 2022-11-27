using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Entity.Models
{
    public class GetUserProfiles
    {
        [Key]
        public string profileUserID { get; set; }
        public string userID { get; set; }
        public string name { get; set; }
        public string iconPhat { get; set; }
        public bool isActive { get; set; }
        public bool isThisTheLastDeviceLoggedIn { get; set; }
    }
}
