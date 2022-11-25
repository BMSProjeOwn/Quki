using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Models;

namespace Quki.Entity.DtoModels
{
    public class SelectMemberShipPricePlaneWithCampaignCodeModel
    {
        public SelectMemberShipPricePlaneWithCampaignCode CampingMemberShipType { get; set; }
        public string UserId { get; set; }
        public List<MembershipProperties> MembershipProperties { get; set; } = new List<MembershipProperties>();
        public List<CampaignDefWithCampaignPropertiesDef> CampingProperties { get; set; } = new List<CampaignDefWithCampaignPropertiesDef>();
        public string CampingCode { get; set; }
    }
}
