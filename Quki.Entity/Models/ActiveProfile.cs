using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Base;

namespace Quki.Entity.Models
{
    public class ActiveProfile : EntityBase
    {
        [Key]
        public string ProfileUserID { get; set; }
        public DateTime? LastActiveDate { get; set; }
        public string DeviceID { get; set; }
        public string DeviceType { get; set; }
        public string Version { get; set; }
    }
}
