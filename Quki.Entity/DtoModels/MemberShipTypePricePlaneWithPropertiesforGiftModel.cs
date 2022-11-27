using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Models;

namespace Quki.Entity.DtoModels
{
    public class MemberShipTypePricePlaneWithPropertiesModel
    {
        public MembershipTypePricePlane MembershipTypePricePlane { get; set; }
        public List<MembershipProperties> MembershipProperties { get; set; } = new List<MembershipProperties>();
        public string MemberShipTypeName { get; set; }
        public string MemberShipTypeRemark { get; set; }
        public string UserId { get; set; }
        public string PaymentPeriodName { get; set; }
        public string CurrencyName { get; set; }
        public CampaignDef CampaignDef { get; set; }
    }

    public class SubscribetionTypeModel
    {
        public List<MemberShipTypePricePlaneWithPropertiesModel> Model { get; set; }
        public string CampingCode { get; set; }
    }
}
