using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Base;

namespace Quki.Entity.DtoModels
{
    public class MemberShipWithCampaignDefCouponModel:DtoBase
    {
        [Key]
        public int MemberShipWithCampaignDefCouponSeq { get; set; }

        public long? MemberShipTypeWithCustomer { get; set; }

        public int? CampaignDefWithCouponSeqID { get; set; }
        public int MemberShipTypePricePlaneSeqID { get; set; }
        public decimal DiscountRate { get; set; }
        public short Status { get; set; }
        public DateTime? UsingDatetime { get; set; }

        public DateTime? CreatedDateTime { get; set; }

        public Guid? CreatedBy { get; set; }

        public Guid? UpdatedBy { get; set; }

        public DateTime? UpdateDateTime { get; set; }
    }
}
