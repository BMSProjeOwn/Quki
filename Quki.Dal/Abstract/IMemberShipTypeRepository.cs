using System.Collections.Generic;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;

namespace Quki.Dal.Abstract
{
    public interface IMemberShipTypeRepository: IGenericRepository<MemberShipType>
    {
        public List<GetAllPricePlaneSP> MembershipTypewithPricePlanWithPropertiesListForApi(string CountryCode, string deviceType, int subribitionTypeStatus);
        public string GetEmailByUserId(string userID);
        //public bool MemberShipTypeAddNew(MemberShipTypeMergeModel Item);
        //public bool MemberShipTypeUpdate(MemberShipTypeMergeModel Item);
        //public bool MemberShipTypeDelete(int id);
        //public MemberShipTypeMergeModel MemberShipTypeGetUpdateValue(int id);
        //public MemberShipType getLastMemberShipType();
        //public List<MembershipProperties> GetPropertiesByMemberShipType(int MemberShipTypeSeqID);
        //public MembershipTypePricePlane GetMemberShipPriceBymembershipTypeSeq(int membershipTypeSeq);
        //public List<MembershipProperties> GetMembershipProperties(int id);
        //public List<MemberShipTypewithPrice> getMembershipTypewithPriceList();
        //public List<MemberShipPricePlanGetModel> MembershipTypewithPricePlanList();
        //public List<MemberShipTypePricePlaneWithPropertiesModel> MembershipTypewithPricePlanWithPropertiesList(int CountrySeqID);
        public MemberShipPaymentPlanWithPaymentChannel GetMemberShipPricePlanByMemberShipTypePricePlaneSeqID(int MemberShipTypePricePlaneSeqID);
        //public MemberShipType GetMemberShipTypeByMemberShipTypePricePlaneSeqID(int MemberShipTypePricePlaneSeqID);
        //public List<SelectListItem> GetAllMemberShipType();
        public List<MemberShipTypeCampaignModel> MembershipTypewithPricePlanWithPropertiesList();
        //public List<MemberShipTypeCampaignModel> MembershipTypewithPricePlanWithPropertiesListByCouponCode(string code);

    }
}
