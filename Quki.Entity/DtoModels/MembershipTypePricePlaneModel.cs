using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Base;

namespace Quki.Entity.DtoModels
{
    public class MembershipTypePricePlaneModel : DtoBase
    {
        public int MemberShipTypeSeqID { get; set; }
        public int MemberShipTypePricePlaneSeqID { get; set; }

        public int? CurrencyID { get; set; }

        public string PlaneName { get; set; }
        public decimal Price { get; set; }
        public int PaymentPeriod { get; set; }
        public int? AutoRenewalCount { get; set; }
        public int? TrailPeriodDay { get; set; }
        public decimal BaseCurrencyPrice { get; set; }
        public bool Status { get; set; }


    }
}
