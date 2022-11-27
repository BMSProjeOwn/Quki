using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Entity.Models
{
    public class PaymentsTypes
    {
        public short PaymentTypesSeqID { get; set; }

        public short? PaymenTypesNumber { get; set; }

        public string PaymentTypesName { get; set; }

        public string PaymentTypesIconPath { get; set; }

        public short? PaymentsTypeID { get; set; }

        public short? PaymentChannelTypeSeqID { get; set; }

        public long? FunctionSeqID { get; set; }

        public short? DisplayOrderNumber { get; set; }

        public short? DisplayGroupOrderNumber { get; set; }

        public short? PaymentTypesCategoryID { get; set; }

        public int? PaymentTypesLanuageID { get; set; }

        public bool? IsFree { get; set; }

        public bool? IsCredit { get; set; }

        public Guid? UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public DateTime? CreatedOn { get; set; }

        public DateTime? CreatedBy { get; set; }

    }
}
