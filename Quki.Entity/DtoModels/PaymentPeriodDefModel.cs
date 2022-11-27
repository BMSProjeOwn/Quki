using System.ComponentModel.DataAnnotations;
using Quki.Entity.Base;

namespace Quki.Entity.DtoModels
{
    public class PaymentPeriodDefModel:DtoBase
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
