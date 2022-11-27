using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Entity.ViewModel
{
    public class MemberShipPricePlanGetModel
    {
        public int MemberShipTypeSeqID { get; set; }
        public int MemberShipTypePricePlaneSeqID { get; set; }
        public string Name { get; set; }
        public string UserID { get; set; }
        public string PlaneName { get; set; }
        public decimal Price { get; set; }
        public int PaymentPeriod { get; set; }
        public string PaymentPeriodName { get; set; }
        public int? AutoRenewalCount { get; set; }
        public int? TrailPeriodDay { get; set; }
        public string Remark { get; set; }
        public string CurrenyName { get; set; }

    }
}
