using Microsoft.Extensions.DependencyInjection;
using System;
using Quki.Bll.Base;
using Quki.Dal.Abstract;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;
using Quki.Interface;

namespace Quki.Bll
{
    public class MemberShipWithCampaignDefCouponManager : BllBase<MemberShipWithCampaignDefCoupon, MemberShipWithCampaignDefCouponModel>, IMemberShipWithCampaignDefCouponService
    {
        public readonly IMemberShipWithCampaignDefCouponRepository repo;
        public MemberShipWithCampaignDefCouponManager(IServiceProvider service) : base(service)
        {
            repo = service.GetService<IMemberShipWithCampaignDefCouponRepository>();
        }
        public bool Update(MemberShipWithCampaignDefCoupon model)
        {
            TUpdate(model);
            return true;
        }
        public bool AddNew(MemberShipWithCampaignDefCoupon model)
        {
            TAdd(model);
            return true;
        }

    }
}
