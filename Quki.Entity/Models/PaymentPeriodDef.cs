using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Base;

namespace Quki.Entity.Models
{
    public class PaymentPeriodDef : EntityBase
    {
        [Key]
        public int PaymentPeriodDefSeq { get; set; }
        public int PaymentPeriodDefId { get; set; } // diğer Tablolarla ilişkilerde kullanılacak
       [MaxLength(250)]
        public string Name { get; set; }
        [MaxLength(250)]
        public string Value { get; set; }
        public int? DisplayOrderNumber { get; set; }
        public bool Status { get; set; }



    }
}
