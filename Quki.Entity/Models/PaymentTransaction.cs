using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Base;

namespace Quki.Entity.Models
{
    public class PaymentTransaction:EntityBase
    {
        [Key]
        public long PaymentTransectionSeqId { get; set; }

        public int MemberShipTypePricePlaneSeqID { get; set; }

        public int MemberShipTypeWithCustomerSeqID { get; set; }

        public string customerReferenceCode { get; set; }

        public long ParentSeqId { get; set; }

        public decimal Amount { get; set; }

        public DateTime PaymentDatetime { get; set; }
        public long EventTime { get; set; }

        public int CurrencyID { get; set; }

        public string ReferansCode { get; set; }

        public bool Status { get; set; }

        public DateTime UpdatedOn { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CreatedBy { get; set; }
    }
}
