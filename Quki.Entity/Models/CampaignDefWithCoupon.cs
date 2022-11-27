using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Base;

namespace Quki.Entity.Models
{
    public class CampaignDefWithCoupon:EntityBase
    {
        [Key]
        public int CampaignDefWithCouponSeqID { get; set; }

        public int? CampaignDefSeqID { get; set; }

        public string CoupondefName { get; set; }

        public string CouponDefCode { get; set; }

        public string Barcode { get; set; }

        public string CouponDefDescription { get; set; }

        public string CouponDefImagePath { get; set; }

        public int? LanguageID { get; set; }

        public bool? IsActive { get; set; }

        public DateTime? StartValidDatetime { get; set; }

        public DateTime? EndValidDatetime { get; set; }

        public DateTime? CreatedDateTime { get; set; }

        public Guid? CreatedBy { get; set; }

        public Guid? UpdatedBy { get; set; }

        public DateTime? UpdateDateTime { get; set; }

        public string Prefix { get; set; }
        public string Sufix { get; set; }
    }
}
