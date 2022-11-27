using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Base;

namespace Quki.Entity.Models
{
    public class Payments:EntityBase
    {
        [Key]
        public long PaymentsSeqID { get; set; }

        public short? PaymentTypesSeqID { get; set; }

        public string CustomerReferenceCode { get; set; }
        public string OrderReferenceCode { get; set; }
        public long? OrdersSeqID { get; set; }

        public decimal PaymentAmount { get; set; }

        public long? PaymentChannelSeqID { get; set; }

        public string PaymentChannelReferenceCode { get; set; }

        public short? PaymentCurrencyTypeSeqID { get; set; }

        public long? MemberShipTypePricePlaneSeqID { get; set; }

        public long? MemberShipTypeWithCustomerSeqID { get; set; }

        public DateTime? StartPaymentPeriod { get; set; }

        public DateTime? EndPaymentPeriod { get; set; }

        public long EventTime { get; set; }

        public short? Status { get; set; }

        public string Remark { get; set; }

        public string ReturnMessage { get; set; }

        public short? PeriodNumber { get; set; }

        public short? Type { get; set; }

        public string UpdateBy { get; set; }

        public DateTime? UpdateDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }
        

    }
}
