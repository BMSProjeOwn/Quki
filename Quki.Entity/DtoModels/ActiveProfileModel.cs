using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Base;

namespace Quki.Entity.DtoModels
{
    public class ActiveProfileModel : DtoBase
    {
        [Key]
        public string ProfileUserID { get; set; }
        public DateTime? LastActiveDate { get; set; }
    }
}
