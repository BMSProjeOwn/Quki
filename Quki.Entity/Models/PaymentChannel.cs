using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quki.Entity.Models
{
    public class PaymentChannel
    {
        [Key]
        public short PaymentChannelSeqID { get; set; }

        public short? PaymentChannelID { get; set; }

        public string PaymentChannelCode { get; set; }

        public string PaymentChannellName { get; set; }

        public string PaymentChannellShrotName { get; set; }

        public int? SP_Bank_ID { get; set; }

        public string ThumpImagePath { get; set; }

        public int? LanguageID { get; set; }

        public string WebAddress { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string PostalCode { get; set; }

        public string PaymentTestAdress { get; set; }

        public string PaymentProdAdress { get; set; }

        public string EntegratedVersionNumber { get; set; }

        public Guid? UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public DateTime? CreatedOn { get; set; }

        public int? CreatedBy { get; set; }
    }
}
