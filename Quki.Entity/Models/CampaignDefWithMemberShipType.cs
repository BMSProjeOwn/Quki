using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Base;

namespace Quki.Entity.Models
{
    public class CampaignDefWithMemberShipType : EntityBase
    {
        [Key]
        public int CampaignDefWithMemberShipTypeSeqID { get; set; }

        public int CampaignDefSeqID { get; set; }

        public int MemberShipTypeSeqID { get; set; }

        public bool? isActive { get; set; }

        public DateTime? CreatedDateTime { get; set; }

        public Guid? CreatedBy { get; set; }

        public Guid? UpdatedBy { get; set; }

        public DateTime? UpdateDateTime { get; set; }
    }
}
