using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Entity.Models
{
    public class OrdersStatus
    {
        [Key]
        public int OrdersStatusSeqID { get; set; }
        public int? OrdersStatusID { get; set; }
        public int? LanguageID { get; set; }
        [MaxLength(500)]
        public int? Name { get; set; }
        public int? DislpayOrderNumber { get; set; }
    }
}
