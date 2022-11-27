using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Entity.Models
{
    public class OrderAudit
    {
        [Key]
        public int AuditSeqID { get; set; }
        public int OrdersSeqID { get; set; }
        public virtual Order Order { get; set; }
        public DateTime DateStamp { get; set; }
        [MaxLength(500)]
        public string Message { get; set; }
        public int MessageNumber { get; set; }
    }
}
