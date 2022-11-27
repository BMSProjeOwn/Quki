using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Base;
using Quki.Entity.Models;

namespace Quki.Entity.DtoModels
{
    public class AddMemberShipwithCancelReasonModel:DtoBase
    {
        public int? MemberShipTypePricePlaneSeqId { get; set; }
        public Guid? UserID { get; set; }
        public List<CancelReasonInfo> cancelReasonInfo { get; set; }

        public bool ShowAlternativeOption { get; set; }
        public string AlternativeOption { get; set; }
        public string AlternativeOptionPrice { get; set; }
        public bool isSelectedOptions { get; set; }
        public List<MembershipProperties> MembershipProperties { get; set; } = new List<MembershipProperties>();
        public string MemberShipTypeName { get; set; }
    }
    public class CancelReasonInfo
    {
        public short? CancelReasonID { get; set; }
        public string? CancelReasonName { get; set; }
        public string? CancelReasonRemark { get; set; }
        public bool Status { get; set; }
    }
}
