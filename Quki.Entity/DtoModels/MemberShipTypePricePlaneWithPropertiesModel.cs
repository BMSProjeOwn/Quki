using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Models;
using Quki.Entity.ViewModel;

namespace Quki.Entity.DtoModels
{
    public class MemberShipTypePricePlaneWithPropertiesForGiftModel
    {
        public MembershipTypePricePlane MembershipTypePricePlane { get; set; }
        public List<MembershipProperties> MembershipProperties { get; set; } = new List<MembershipProperties>();
        public string MemberShipTypeName { get; set; }
        public string MemberShipTypeRemark { get; set; }
        public string UserId { get; set; }
        public string PaymentPeriodName { get; set; }
        public string CurrencyName { get; set; }
        public int CampaignDefId { get; set; }
    }

    public class SubscribetionTypeModelForGift
    {
        public List<MemberShipTypePricePlaneWithPropertiesForGiftModel> Model { get; set; }
        public string CampingCode { get; set; }
        public LoginViewModel LoginViewModel =new LoginViewModel();
    }
}
