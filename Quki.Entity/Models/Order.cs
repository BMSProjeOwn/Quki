using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Base;

namespace Quki.Entity.Models
{
    public class Order:EntityBase
    {
        [Key]
        public int OrdersSeqID { get; set; }
        [MaxLength(450)]
        public string OrdersGUID { get; set; }
        [MaxLength(450)]
        public string UserID { get; set; }
        [MaxLength(50)]
        public string AuthCode { get; set; }
        [MaxLength(250)]
        public string Reference { get; set; }

        public int? TaxSeqID { get; set; }
        public int? ShippingSeqID { get; set; }
        public int Verified { get; set; }
        public int Status { get; set; }
        public bool Completed { get; set; }
        public bool Canceled { get; set; }
        [MaxLength(450)]
        public string Comments { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string ShippingAdress { get; set; }
        public DateTime? ShippedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<OrdersDetail> OrdersDetails { get; set; }
        public List<OrderAudit> OrderAudits { get; set; }
    }
}
