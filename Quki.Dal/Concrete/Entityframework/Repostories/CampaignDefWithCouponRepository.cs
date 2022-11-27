using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Quki.Dal.Abstract;

using Quki.Entity.DtoModels;
using Quki.Entity.Models;

namespace Quki.Dal.Concrete.Entityframework.Repostories
{
    public class CampaignDefWithCouponRepository : GenericRepository<CampaignDefWithCoupon>, ICampaignDefWithCouponRepository
    {
        public CampaignDefWithCouponRepository(DbContext context) : base(context)
        {
        }
        //public string AddCoupon(CampaignDefWithCouponModel campaignDefWithCouponModel)
        //{
        //    var entity = new CampaignDefWithCoupon();
        //    string result = "";

        //    for (int i = 0; i < campaignDefWithCouponModel.Number; i++)
        //    {

        //        entity = new CampaignDefWithCoupon();

        //        entity.Prefix = campaignDefWithCouponModel.Prefix;
        //        entity.Sufix = campaignDefWithCouponModel.Sufix;

        //        entity.CouponDefCode = Functions
        //            .CreateRandomCouponCode(6, entity.Prefix, entity.Sufix, true);
        //        //entity.CouponDefCode = entity.Prefix + entity.CouponDefCode + entity.Sufix;
        //        entity.StartValidDatetime = campaignDefWithCouponModel.StartValidDatetime;
        //        entity.EndValidDatetime = campaignDefWithCouponModel.EndValidDatetime;

        //        entity.IsActive = true;
        //        entity.CreatedDateTime = DateTime.Now;
        //        entity.CampaignDefSeqID = campaignDefWithCouponModel.CampaignDefSeqID;



        //        TAdd(entity);
        //        result = entity.CouponDefCode;
        //    }
        //    return result;
        //}
        public List<CampaignDefWithCoupon> CouponList(int id)
        {
            List<CampaignDefWithCoupon> list = dbset.Join(context.Set<CampaignDef>(), CDWC => CDWC.CampaignDefSeqID, CD => CD.CampaignDefSeqID, (campaignWithCoupon, campaign) => new
            {
                CampaignDef = campaign,
                CampaignDefWithCoupon = campaignWithCoupon
            }).Select(I => new CampaignDefWithCoupon
            {
                CouponDefCode = I.CampaignDefWithCoupon.CouponDefCode,
                CampaignDefWithCouponSeqID = I.CampaignDefWithCoupon.CampaignDefWithCouponSeqID,
                IsActive = I.CampaignDefWithCoupon.IsActive,
                CampaignDefSeqID = I.CampaignDef.CampaignDefSeqID

            }).Where(x => x.CampaignDefSeqID == id).OrderByDescending(I => I.CampaignDefWithCouponSeqID).ToList();

            return list;
        }
        //public CampaignDefWithCoupon GetCuponByCode(string code)
        //{
        //    CampaignDefWithCoupon result = dbset.
        //        Where(x => x.CouponDefCode == code).FirstOrDefault();
        //    return result;
        //}
        //public bool GetCuponByCode(CampaignDefWithCoupon model)
        //{
        //    TUpdate(model);
        //    return true;
        //}

    }
}
