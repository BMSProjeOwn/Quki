using Quki.Entity.DtoModels;
using Quki.Entity.Models;

namespace Quki.Interface
{
    public interface IMemberShipWithCampaignDefCouponService : IGenericService<MemberShipWithCampaignDefCoupon, MemberShipWithCampaignDefCouponModel>
    {

        public bool Update(MemberShipWithCampaignDefCoupon model);


        public bool AddNew(MemberShipWithCampaignDefCoupon model);
        
    }
}
