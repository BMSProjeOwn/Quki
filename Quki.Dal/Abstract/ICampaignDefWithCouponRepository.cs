using System;
using System.Collections.Generic;
using System.Linq;

using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;

namespace Quki.Dal.Abstract
{
    public interface ICampaignDefWithCouponRepository
    {

        //public string AddCoupon(CampaignDefWithCouponModel campaignDefWithCouponModel);
        //public List<CampaignDefWithCoupon> CouponList(int id);
        //public CampaignDefWithCoupon GetCuponByCode(string code);
        //public bool GetCuponByCode(CampaignDefWithCoupon model);
        public List<CampaignDefWithCoupon> CouponList(int id);
    }
}
