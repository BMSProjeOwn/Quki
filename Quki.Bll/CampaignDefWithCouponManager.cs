using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using Quki.Bll.Base;
using Quki.Common;
using Quki.Dal.Abstract;

using Quki.Entity.DtoModels;
using Quki.Entity.Models;
using Quki.Interface;

namespace Quki.Bll
{
    public class CampaignDefWithCouponManager : BllBase<CampaignDefWithCoupon, CampaignDefWithCouponModel>, ICampaignDefWithCouponService
    {

        public readonly ICampaignDefWithCouponRepository campaignDefWithCouponRepository;
        public readonly ICampaignRepository campaignRepository;
        public CampaignDefWithCouponManager(IServiceProvider service) : base(service)
        {
            campaignDefWithCouponRepository = service.GetService<ICampaignDefWithCouponRepository>();
            campaignRepository = service.GetService<ICampaignRepository>();
        }
        public string CreateRandomCouponCode(int lenght, string Prefix, string Sufix, bool Control)
        {
            
            string couponCode = "";


            while (true)
            {
                couponCode = "";
                var rnd = new Random();


                for (int i = 0; i < lenght; i++)
                {
                    couponCode += ((char)rnd.Next('A', 'Z')).ToString();

                }
                couponCode = Prefix + couponCode + Sufix;
                CampaignDefWithCoupon couponCode1 = null;
                if (Control)
                {
                    couponCode1 = GetCuponByCode(couponCode);
                }

                if (couponCode1 == null)
                    break;
            }

            return couponCode;
        }
       
        
        public string AddCoupon(CampaignDefWithCouponModel campaignDefWithCouponModel)
        {
            var entity = new CampaignDefWithCoupon();
            string result = "";
            if (campaignDefWithCouponModel.Number == 1)
            {

                entity = new CampaignDefWithCoupon();

                entity.Prefix = campaignDefWithCouponModel.Prefix;
                entity.Sufix = campaignDefWithCouponModel.Sufix;

                /*entity.CouponDefCode = Functions
                    .CreateRandomCouponCode(6, entity.Prefix, entity.Sufix, true);*/
                //entity.CouponDefCode = entity.Prefix + entity.CouponDefCode + entity.Sufix;
                entity.CouponDefCode = entity.Prefix + entity.Sufix;
                CampaignDefWithCoupon checkDefCoupon = TGetList().Where(x => x.CouponDefCode == entity.CouponDefCode).FirstOrDefault();
                if (checkDefCoupon == null)
                {
                    entity.StartValidDatetime = campaignDefWithCouponModel.StartValidDatetime;
                    entity.EndValidDatetime = campaignDefWithCouponModel.EndValidDatetime;

                    entity.IsActive = true;
                    entity.CreatedDateTime = DateTime.Now;
                    entity.CampaignDefSeqID = campaignDefWithCouponModel.CampaignDefSeqID;



                    TAdd(entity);
                    result = entity.CouponDefCode;
                }
                else
                {
                    result = "couponusnig";
                }
            }
            else
            {
                for (int i = 0; i < campaignDefWithCouponModel.Number; i++)
                {

                    entity = new CampaignDefWithCoupon();

                    entity.Prefix = campaignDefWithCouponModel.Prefix;
                    entity.Sufix = campaignDefWithCouponModel.Sufix;

                    entity.CouponDefCode = Functions
                        .CreateRandomCouponCode(6, entity.Prefix, entity.Sufix, true);
                    //entity.CouponDefCode = entity.Prefix + entity.CouponDefCode + entity.Sufix;
                    entity.StartValidDatetime = campaignDefWithCouponModel.StartValidDatetime;
                    entity.EndValidDatetime = campaignDefWithCouponModel.EndValidDatetime;

                    entity.IsActive = true;
                    entity.CreatedDateTime = DateTime.Now;
                    entity.CampaignDefSeqID = campaignDefWithCouponModel.CampaignDefSeqID;



                    TAdd(entity);
                    result = entity.CouponDefCode;
                }

            }


            return result;
        }
        public List<CampaignDefWithCoupon> CouponList(int id)
        {
            List<CampaignDefWithCoupon> list = TGetList().Join(campaignRepository.TGetList(), CDWC => CDWC.CampaignDefSeqID, CD => CD.CampaignDefSeqID, (campaignWithCoupon, campaign) => new
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
        public CampaignDefWithCoupon GetCuponByCode(string code)
        {
            CampaignDefWithCoupon result = TGetList().
                Where(x => x.CouponDefCode == code).FirstOrDefault();
            return result;
        }
        public bool GetCuponByCode(CampaignDefWithCoupon model)
        {
            try
            {
                TUpdate(model);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
