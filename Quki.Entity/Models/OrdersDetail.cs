using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Entity.Models
{
    public class OrdersDetail
    {
        [Key]
        public int OrdersDetailSeqID { get; set; }
        public int OrdersSeqID { get; set; }
        public virtual Order Order { get; set; }
        public int ProductID { get; set; }
        [MaxLength(500)]
        public string ProductName { get; set; }
        public int Ouantity { get; set; }
        public decimal UnitCost { get; set; }
        public int PaymentStatusID { get; set; }
        public int PaymentMethod { get; set; }
        public decimal? AdditionalTax { get; set; }
        public decimal? TaxTotal { get; set; }
        public decimal? SubDiscount { get; set; }
        public decimal? SubTotalWithCustomerCurrency { get; set; }
        public int? CustomerCurrencyID { get; set; }
        public float? Weight { get; set; }
        public int OrderStatusID { get; set; }
 
        
    }
}
