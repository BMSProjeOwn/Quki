using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quki.Dal.Abstract;
using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Entity.Models;

namespace Quki.Dal.Concrete.Entityframework.Repostories
{
    public class MemberShipWithCampaignDefCouponRepository : GenericRepository<MemberShipWithCampaignDefCoupon>, IMemberShipWithCampaignDefCouponRepository
    {
        public MemberShipWithCampaignDefCouponRepository(DbContext context) : base(context)
        {
            
        }
        //public bool Update(MemberShipWithCampaignDefCoupon model)
        //{
        //    TUpdate(model);
        //    return true;
        //}
        //public bool AddNew(MemberShipWithCampaignDefCoupon model)
        //{
        //    TAdd(model);
        //    return true;
        //}
    }
}
