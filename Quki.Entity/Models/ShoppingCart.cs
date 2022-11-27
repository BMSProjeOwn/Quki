using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Entity.Models
{
    public class ShoppingCart
    {
        [Key]
        public int ShoppingCartSeqID { get; set; }
        [MaxLength(450)]
        public string ShoppingCartGUID { get; set; }
        [MaxLength(450)]
        public string UserID { get; set; }
        public int ProductSeqID { get; set; }
        [MaxLength(250)]
        public string ProductName { get; set; }
        [MaxLength(250)]
        public string ProductRefCode { get; set; }
        public int? Quantity { get; set; }
        [MaxLength(250)]
        public int GrettingWords { get; set; }
        public DateTime? UpdatedOn { get; set; }
        [MaxLength(450)]
        public string UpdatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        [MaxLength(450)]
        public string CreatedBy { get; set; }
    }
}
