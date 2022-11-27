using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Entity.Models
{
    public class PaymentReport
    {
        [Key]
        public long PaymentsSeqID { get; set; }
        public string UserName { get; set; }
        public string MembershipTypeName { get; set; }
        public string PaymentAmount { get; set; }
        public string PaymentStatus { get; set; }
        public string PaymentChannellName { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
