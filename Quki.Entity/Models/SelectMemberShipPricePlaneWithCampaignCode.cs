using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Entity.Models
{
    public class SelectMemberShipPricePlaneWithCampaignCode
    {
        [Key]
        public string ID { get; set; }
        public int MemberShipTypeSeqID { get; set; }
        public int MemberShipTypePricePlaneSeqID { get; set; }
        public int CampaignDefSeqID { get; set; }
        public string CurrencyName { get; set; }
        public decimal Price { get; set; }
        public string PaymentPeriodName { get; set; }
        public string MemberShipTypeName { get; set; }
        public string PlaneName { get; set; }
        public string TrailPeriodDay { get; set; }
        public decimal DicountRate { get; set; }
        public int NumberOfUses { get; set; }
        public int MemberShipWithCampaignDefCouponSeq { get; set; }
    }


}
