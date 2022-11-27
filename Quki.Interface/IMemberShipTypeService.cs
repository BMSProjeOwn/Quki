
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Quki.Entity.DtoModels;
using Quki.Entity.DtoModels.ApiModels;
using Quki.Entity.Models;
using Quki.Entity.ViewModel;

namespace Quki.Interface
{
    public interface IMemberShipTypeService : IGenericService<MemberShipType, MemberShipTypeModel>
    {
        public List<GetAllMemberShipTypeModel> MembershipTypewithPricePlanWithPropertiesListForApi(string currencyName, string deviceType, int subribitionTypeStatus, int languageId);
        public bool MemberShipTypeAddNew(MemberShipTypeMergeModel Item);
        public bool MemberShipTypeUpdate(MemberShipTypeMergeModel Item);
        public bool MemberShipTypeDelete(int id);
        public MemberShipType getLastMemberShipType();
        public MemberShipTypeMergeModel MemberShipTypeGetUpdateValue(int id);
        public List<MembershipProperties> GetPropertiesByMemberShipType(int MemberShipTypeSeqID);
        public MembershipTypePricePlane GetMemberShipPriceBymembershipTypeSeq(int membershipTypeSeq);
        public List<MembershipProperties> GetMembershipProperties(int id);
        public List<MemberShipTypewithPrice> getMembershipTypewithPriceList();
        public List<MemberShipPricePlanGetModel> MembershipTypewithPricePlanList();
        public List<MemberShipTypePricePlaneWithPropertiesModel> MembershipTypewithPricePlanWithPropertiesList(int CountrySeqID,int pricePlaneTypeId,int languageID);
        public MemberShipTypeInfoApiModel SubcriptionInfoByProfilId(string ProfilId,int languageId);
        public MemberShipPaymentPlanWithPaymentChannel GetMemberShipPricePlanByMemberShipTypePricePlaneSeqID(int MemberShipTypePricePlaneSeqID);
        public MemberShipType GetMemberShipTypeByMemberShipTypePricePlaneSeqID(int MemberShipTypePricePlaneSeqID);
        public List<SelectListItem> GetAllMemberShipType();
        public List<MemberShipTypeCampaignModel> MembershipTypewithPricePlanWithPropertiesList();
        public List<MemberShipTypeCampaignModel> MembershipTypewithPricePlanWithPropertiesListByCouponCode(string code);
        public List<MemberShipTypePricePlaneWithPropertiesForGiftModel> MembershipTypewithPricePlanWithPropertiesForGiftList(int CountrySeqID, int pricePlaneTypeId);
        public List<GetAllMemberShipTypeReferansCodeModel> MembershipTypewithPricePlanReferancCodeListForApi(string deviceType);

    }
}
