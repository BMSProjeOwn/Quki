using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quki.Entity.Models
{
    public class GetAllPricePlaneSP
    {
        [Key]
        public string ID { get; set; }
        public int MemberShipTypeSeqID { get; set; }
        public string Name { get; set; }
        public int MemberShipTypePricePlaneSeqID { get; set; }
        public string PlaneName { get; set; }
        public decimal Price { get; set; }
        public string PaymentPeriodName { get; set; }
        public int PaymentPeriod { get; set; }
        public int AutoRenewalCount { get; set; }
        public int FreeDay { get; set; }
        public string CurrenyName { get; set; }
        public string pricePlaneReferansCode { get; set; }
    }
}
