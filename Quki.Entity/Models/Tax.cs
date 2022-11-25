using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Entity.Models
{
    public class Tax
    {
        [Key]
        public int TaxSeqID { get; set; }

        public int TaxID { get; set; }

        public int? LanguageID { get; set; }

        public string TaxType { get; set; }

        public decimal TaxPercentage { get; set; }

        public bool IsIncludedTax { get; set; }

        public bool? Status { get; set; }

        public short? DisplayOrderNumber { get; set; }

        public DateTime? CreatedOn { get; set; }

        public int? CreatedBy { get; set; }
    }
}
