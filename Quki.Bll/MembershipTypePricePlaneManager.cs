
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using Quki.Bll.Base;
using Quki.Common;
using Quki.Dal.Abstract;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;
using Quki.Entity.Parameters;
using Quki.Interface;

namespace Quki.Bll
{
    public class MembershipTypePricePlaneManager : BllBase<MembershipTypePricePlane,MembershipTypePricePlaneModel >, IMembershipTypePricePlaneService
    {
        public readonly IMembershipTypePricePlaneRepository repo;
        public readonly IMemberShipPaymentPlanWithPaymentChannelRepository memberShipPaymentPlanWithPaymentChannelRepository;
        public readonly IMemberShipTypesWithPaymentChanelsRepository memberShipTypesWithPaymentChanelsRepository;
        public readonly IMembershipTypePricePlaneRepository membershipTypePricePlaneRepository;
        public readonly IPaymentPeriodDefRepository paymentPeriodDefRepository;
        public readonly IMemberShipTypeWithCustomerRepository membershipTypeWithCustomerRepository;
        public MembershipTypePricePlaneManager(IServiceProvider service) : base(service)
        {
            repo = service.GetService<IMembershipTypePricePlaneRepository>();
            memberShipPaymentPlanWithPaymentChannelRepository = service.GetService<IMemberShipPaymentPlanWithPaymentChannelRepository>();
            membershipTypePricePlaneRepository = service.GetService<IMembershipTypePricePlaneRepository>();
            paymentPeriodDefRepository = service.GetService<IPaymentPeriodDefRepository>();
            membershipTypeWithCustomerRepository = service.GetService<IMemberShipTypeWithCustomerRepository>();
            memberShipTypesWithPaymentChanelsRepository= service.GetService<IMemberShipTypesWithPaymentChanelsRepository>();
        }
        public List<MembershipTypePricePlane> GetMembershipTypePricePlaneByMemberShipTypeID(int MemberShipTypeSeqID)
        {

            return TGetList(p => p.MemberShipTypeSeqID == MemberShipTypeSeqID && p.Status == true).ToList();
        }

        public MembershipTypePricePlane SelectByID(int MemberShipTypePricePlaneSeqID)
        {

            return TGetList(p => p.MemberShipTypePricePlaneSeqID == MemberShipTypePricePlaneSeqID).FirstOrDefault();
        }

        public MembershipTypePricePlane GetWithID(int id)
        {

            return TGetList(p => p.MemberShipTypePricePlaneSeqID == id && p.Status == true).FirstOrDefault();
        }

        public bool AddNeWPricePlan(MembershipTypePricePlaneModel model)
        {
            bool returnvalue = false;
            int _memberShipTypeSeqID = (int)model.MemberShipTypeSeqID;
            string PlanRefNo = "";
            MembershipTypePricePlane MembershipTypePricePlane = new MembershipTypePricePlane();
            MembershipTypePricePlane.PlaneName = model.PlaneName;
            MembershipTypePricePlane.MemberShipTypeSeqID = model.MemberShipTypeSeqID;
            MembershipTypePricePlane.Price = model.Price;
            MembershipTypePricePlane.PaymentPeriod = model.PaymentPeriod;
            MembershipTypePricePlane.TrailPeriodDay = model.TrailPeriodDay;
            MembershipTypePricePlane.AutoRenewalCount = model.AutoRenewalCount;
            MembershipTypePricePlane.Status = model.Status;
            MembershipTypePricePlane.CreatedOn = DateTime.Now;
            MembershipTypePricePlane.UpdatedOn = DateTime.Now;
            MembershipTypePricePlane.CurrencyID = model.CurrencyID;
            MembershipTypePricePlane.ShowCustomers = true;
            //TAdd(MembershipTypePricePlane);
            if (Parameters.isHasIzicoo)
            {

                MemberShipPaymentPlanWithPaymentChannel memberShipPaymentPlanWithPayment = new MemberShipPaymentPlanWithPaymentChannel();
                memberShipPaymentPlanWithPayment.MemberShipTypeSeqID = model.MemberShipTypeSeqID;
                var ff = memberShipTypesWithPaymentChanelsRepository.TGetList(p => p.MemberShipTypeSeqID == _memberShipTypeSeqID).FirstOrDefault();
                var membershipTypePricePlane = membershipTypePricePlaneRepository.TGetList(p => p.MemberShipTypeSeqID == _memberShipTypeSeqID).FirstOrDefault();
                var pertod = paymentPeriodDefRepository.TGetList(p => p.PaymentPeriodDefId == model.PaymentPeriod).FirstOrDefault();
               // var rezult = IyzipayEntegration.CreateProductPlan(model, ff.ReferenceCode, pertod.Value.ToString().Trim(), out PlanRefNo);
                //if (rezult)
                //{
                //    TAdd(MembershipTypePricePlane);
                //    memberShipPaymentPlanWithPayment.MemberShipTypePricePlaneSeqID = MembershipTypePricePlane.MemberShipTypePricePlaneSeqID;//membershipTypePricePlane.MemberShipTypePricePlaneSeqID;
                //    memberShipPaymentPlanWithPayment.MemberShipTypeSeqID = model.MemberShipTypeSeqID;
                //    memberShipPaymentPlanWithPayment.PamentChannelSeqID = PamentChannel.PamentChannelIzicoo;

                //    memberShipPaymentPlanWithPayment.ReferenceCode = PlanRefNo;
                //    memberShipPaymentPlanWithPayment.DisplayOrderNumber = 1;
                //    memberShipPaymentPlanWithPayment.CreatedOn = DateTime.Now;
                //    memberShipPaymentPlanWithPayment.UpdatedOn = DateTime.Now;
                //    memberShipPaymentPlanWithPaymentChannelRepository.TAdd(memberShipPaymentPlanWithPayment);
                    
                //        returnvalue = true;
                //}
            }
            return returnvalue;
        }

        public List<SelectListItem> GetPaymentPeriodDefListForDropdown()
        {

            List<SelectListItem> list = (from x in paymentPeriodDefRepository.TGetList()
                                         select new SelectListItem
                                         {
                                             Text = x.Name,
                                             Value = x.PaymentPeriodDefId.ToString()
                                         }).ToList();
            return list;
        }

        public bool Delete(int id)
        {
            var value = TGetList(w => w.MemberShipTypePricePlaneSeqID == id).FirstOrDefault();
            value.Status = false;

            value.UpdatedOn = DateTime.Now;
            var priceinfo = memberShipPaymentPlanWithPaymentChannelRepository.TGetList(x => x.MemberShipTypePricePlaneSeqID.Equals(id)).FirstOrDefault();
            if (membershipTypeWithCustomerRepository.TGetList().Any(x => x.MemberShipTypePricePlaneSeqID == id && x.IsActive.Equals(true)))
            {
                return false;
            }
            TUpdate(value);
            return true;
        }

        public bool Update(MembershipTypePricePlaneModel model)
        {
            var value = TGetList(w => w.MemberShipTypePricePlaneSeqID == model.MemberShipTypePricePlaneSeqID).FirstOrDefault();
            var priceinfo = memberShipPaymentPlanWithPaymentChannelRepository.TGetList(x => x.MemberShipTypePricePlaneSeqID.Equals(model.MemberShipTypePricePlaneSeqID)).FirstOrDefault();
            if (membershipTypeWithCustomerRepository.TGetList().Any(x => x.MemberShipTypePricePlaneSeqID == model.MemberShipTypePricePlaneSeqID && x.IsActive.Equals(true)))
            {
                return false;
            }
           // bool result = IyzipayEntegration.DeleteProductPlan(priceinfo.ReferenceCode);
            //result = AddNeWPricePlan(model);
            //if (result)
            //{
            //    value.PlaneName = model.PlaneName;
            //    value.MemberShipTypeSeqID = model.MemberShipTypeSeqID;
            //    value.Price = model.Price;
            //    value.PaymentPeriod = model.PaymentPeriod;
            //    value.TrailPeriodDay = model.TrailPeriodDay;
            //    value.AutoRenewalCount = model.AutoRenewalCount;
            //    value.CurrencyID = model.CurrencyID;
            //    value.Status = false;
            //    value.CreatedOn = DateTime.Now;
            //    value.UpdatedOn = DateTime.Now;
            //    TUpdate(value);
            //    return true;
            //}
            return false;
        }

        public MembershipTypePricePlane GetWithUserID(string UserID)
        {
            var memberShipPricePlanInfo = membershipTypeWithCustomerRepository.getMemberShipTypeWithCustomers(UserID);
            var result = TgetItemByID(memberShipPricePlanInfo.MemberShipTypePricePlaneSeqID);
            return result;
        }
        public List<MembershipTypePricePlane> GetAllActivePricePlane()
        {
            var result = TGetList(x => x.Status.Equals(true)).ToList();
            return result;
        }
        public MembershipTypePricePlane GetLast()
        {
            return repo.GetLast();
        }


        public bool AddNeWPricePlanForAlternativeOfCancle(MembershipTypePricePlaneModel model)//Önder Özbek
        {
            bool returnvalue = true;
            int _memberShipTypeSeqID = (int)model.MemberShipTypeSeqID;
            string PlanRefNo = "";
            MembershipTypePricePlane MembershipTypePricePlane = new MembershipTypePricePlane();
            MembershipTypePricePlane.PlaneName = model.PlaneName;
            MembershipTypePricePlane.MemberShipTypeSeqID = model.MemberShipTypeSeqID;
            MembershipTypePricePlane.Price = model.Price;
            MembershipTypePricePlane.PaymentPeriod = model.PaymentPeriod;
            MembershipTypePricePlane.TrailPeriodDay = model.TrailPeriodDay;
            MembershipTypePricePlane.AutoRenewalCount = model.AutoRenewalCount;
            MembershipTypePricePlane.Status = model.Status;
            MembershipTypePricePlane.CreatedOn = DateTime.Now;
            MembershipTypePricePlane.UpdatedOn = DateTime.Now;
            MembershipTypePricePlane.CurrencyID = model.CurrencyID;

            if (Parameters.isHasIzicoo)
            {
                MemberShipPaymentPlanWithPaymentChannel memberShipPaymentPlanWithPayment = new MemberShipPaymentPlanWithPaymentChannel();
                memberShipPaymentPlanWithPayment.MemberShipTypeSeqID = model.MemberShipTypeSeqID;
                var ff = memberShipPaymentPlanWithPaymentChannelRepository.TGetList(p => p.MemberShipTypeSeqID == _memberShipTypeSeqID).FirstOrDefault();
                var pertod = paymentPeriodDefRepository.TGetList(p => p.PaymentPeriodDefId == model.PaymentPeriod).FirstOrDefault();
                //bool rezult = IyzipayEntegration.CreateProductPlanForAlternativeOfCancle(model, ff.ReferenceCode, pertod.Value.ToString().Trim(), out PlanRefNo);
                //if (rezult)
                //{
                //    TAdd(MembershipTypePricePlane);

                //    var membershipTypePricePlane = membershipTypePricePlaneRepository.TGetList(p => p.MemberShipTypeSeqID == _memberShipTypeSeqID).FirstOrDefault();
                //    memberShipPaymentPlanWithPayment.MemberShipTypePricePlaneSeqID = MembershipTypePricePlane.MemberShipTypePricePlaneSeqID;//membershipTypePricePlane.MemberShipTypePricePlaneSeqID;
                //    memberShipPaymentPlanWithPayment.MemberShipTypeSeqID = model.MemberShipTypeSeqID;
                //    memberShipPaymentPlanWithPayment.PamentChannelSeqID = PamentChannel.PamentChannelIzicoo;

                //    memberShipPaymentPlanWithPayment.ReferenceCode = PlanRefNo;
                //    memberShipPaymentPlanWithPayment.DisplayOrderNumber = 1;
                //    memberShipPaymentPlanWithPayment.CreatedOn = DateTime.Now;
                //    memberShipPaymentPlanWithPayment.UpdatedOn = DateTime.Now;
                //    memberShipPaymentPlanWithPaymentChannelRepository.TAdd(memberShipPaymentPlanWithPayment);
                //}
                //else
                //{
                //    returnvalue = false;
                //}
            }
            return returnvalue;
        }

    }
}
