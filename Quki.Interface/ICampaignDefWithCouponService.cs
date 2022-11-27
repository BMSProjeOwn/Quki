using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quki.Entity.DtoModels;
using Quki.Entity.DtoModels.ApiModels;
using Quki.Entity.Models;

namespace Quki.Interface
{
    public interface ICampaignDefWithCouponService : IGenericService<CampaignDefWithCoupon,CampaignDefWithCouponModel>
    {
        public string AddCoupon(CampaignDefWithCouponModel campaignDefWithCouponModel);
        public List<CampaignDefWithCoupon> CouponList(int id);
        public CampaignDefWithCoupon GetCuponByCode(string code);
        public bool GetCuponByCode(CampaignDefWithCoupon model);
    }
}
