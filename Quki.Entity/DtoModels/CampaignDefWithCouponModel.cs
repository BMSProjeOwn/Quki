using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Base;

namespace Quki.Entity.DtoModels
{
    public class CodeInformationViewModel : DtoBase
    {
        public int CampaignDefWithCouponSeqID { get; set; }

        public int CampaignDefSeqID { get; set; }

        public string CoupondefName { get; set; }
        public string SendMail { get; set; }
        public string CouponDefCode { get; set; }
        public double CanUseDate;
        public DateTime StartValidDatetime { get; set; }

        public DateTime? EndValidDatetime { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public Guid CreatedBy { get; set; }

        public Guid UpdatedBy { get; set; }

        public DateTime UpdateDateTime { get; set; }
        public int pricePlaneSeqId;
    }
}
