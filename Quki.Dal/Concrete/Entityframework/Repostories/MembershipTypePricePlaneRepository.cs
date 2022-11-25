
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Quki.Dal.Abstract;

using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;
using Quki.Entity.Parameters;

namespace Quki.Dal.Concrete.Entityframework.Repostories
{
    public class MembershipTypePricePlaneRepository : GenericRepository<MembershipTypePricePlane>, IMembershipTypePricePlaneRepository
    {
        public MembershipTypePricePlaneRepository(DbContext context) : base(context)
        {

        }
        //public List<MembershipTypePricePlane> GetMembershipTypePricePlaneByMemberShipTypeID(int MemberShipTypeSeqID)
        //{

        //    return dbset.Where(p => p.MemberShipTypeSeqID == MemberShipTypeSeqID && p.Status == true).ToList();
        //}

        //public MembershipTypePricePlane SelectByID(int MemberShipTypePricePlaneSeqID)
        //{

        //    return dbset.Where(p => p.MemberShipTypePricePlaneSeqID == MemberShipTypePricePlaneSeqID).FirstOrDefault();
        //}

        //public MembershipTypePricePlane GetWithID(int id)
        //{

        //    return dbset.Where(p => p.MemberShipTypePricePlaneSeqID == id && p.Status == true).FirstOrDefault();
        //}

        //public bool AddNeWPricePlan(MembershipTypePricePlaneModel model)
        //{
        //    bool returnvalue = false;
        //    int _memberShipTypeSeqID = (int)model.MemberShipTypeSeqID;
        //    string PlanRefNo = "";
        //    MembershipTypePricePlane MembershipTypePricePlane = new MembershipTypePricePlane();
        //    MembershipTypePricePlane.PlaneName = model.PlaneName;
        //    MembershipTypePricePlane.MemberShipTypeSeqID = model.MemberShipTypeSeqID;
        //    MembershipTypePricePlane.Price = model.Price;
        //    MembershipTypePricePlane.PaymentPeriod = model.PaymentPeriod;
        //    MembershipTypePricePlane.TrailPeriodDay = model.TrailPeriodDay;
        //    MembershipTypePricePlane.AutoRenewalCount = model.AutoRenewalCount;
        //    MembershipTypePricePlane.Status = model.Status;
        //    MembershipTypePricePlane.CreatedOn = DateTime.Now;
        //    MembershipTypePricePlane.UpdatedOn = DateTime.Now;
        //    MembershipTypePricePlane.CurrencyID = model.CurrencyID;
        //    //TAdd(MembershipTypePricePlane);
        //    if (Parameters.isHasIzicoo)
        //    {

        //        MemberShipPaymentPlanWithPaymentChannel memberShipPaymentPlanWithPayment = new MemberShipPaymentPlanWithPaymentChannel();
        //        memberShipPaymentPlanWithPayment.MemberShipTypeSeqID = model.MemberShipTypeSeqID;
        //        var ff = context.Set<MemberShipTypesWithPaymentChanel>().Where(p => p.MemberShipTypeSeqID == _memberShipTypeSeqID).FirstOrDefault();
        //        var membershipTypePricePlane = context.Set<MembershipTypePricePlane>().Where(p => p.MemberShipTypeSeqID == _memberShipTypeSeqID).FirstOrDefault();
        //        var pertod = context.Set<PaymentPeriodDef>().Where(p => p.PaymentPeriodDefId == model.PaymentPeriod).FirstOrDefault();
        //        var rezult = IyzipayEntegration.CreateProductPlan(model, ff.ReferenceCode, pertod.Value.ToString().Trim(), out PlanRefNo);
        //        if (rezult)
        //        {
        //            TAdd(MembershipTypePricePlane);
        //            memberShipPaymentPlanWithPayment.MemberShipTypePricePlaneSeqID = MembershipTypePricePlane.MemberShipTypePricePlaneSeqID;//membershipTypePricePlane.MemberShipTypePricePlaneSeqID;
        //            memberShipPaymentPlanWithPayment.MemberShipTypeSeqID = model.MemberShipTypeSeqID;
        //            memberShipPaymentPlanWithPayment.PamentChannelSeqID = PamentChannel.PamentChannelIzicoo;

        //            memberShipPaymentPlanWithPayment.ReferenceCode = PlanRefNo;
        //            memberShipPaymentPlanWithPayment.DisplayOrderNumber = 1;
        //            memberShipPaymentPlanWithPayment.CreatedOn = DateTime.Now;
        //            memberShipPaymentPlanWithPayment.UpdatedOn = DateTime.Now;
        //            context.Set<MemberShipPaymentPlanWithPaymentChannel>().Add(memberShipPaymentPlanWithPayment);
        //            int resultSave = context.SaveChanges();
        //            if (resultSave > 0)
        //            {
        //                returnvalue = true;
        //            }
        //        }
        //    }
        //    return returnvalue;
        //}

        //public List<SelectListItem> GetPaymentPeriodDefListForDropdown()
        //{

        //    List<SelectListItem> list = (from x in context.Set<PaymentPeriodDef>().ToList()
        //                                 select new SelectListItem
        //                                 {
        //                                     Text = x.Name,
        //                                     Value = x.PaymentPeriodDefId.ToString()
        //                                 }).ToList();
        //    return list;
        //}

        //public bool Delete(int id)
        //{
        //    var value = dbset.Where(w => w.MemberShipTypePricePlaneSeqID == id).FirstOrDefault();
        //    value.Status = false;

        //    value.UpdatedOn = DateTime.Now;
        //    var priceinfo = context.Set<MemberShipPaymentPlanWithPaymentChannel>().Where(x => x.MemberShipTypePricePlaneSeqID.Equals(id)).FirstOrDefault();
        //    if (context.Set<MemberShipTypeWithCustomer>().Any(x => x.MemberShipTypePricePlaneSeqID == id && x.IsActive.Equals(true)))
        //    {
        //        return false;
        //    }
        //    TUpdate(value);
        //    return true;
        //}

        //public bool Update(MembershipTypePricePlaneModel model)
        //{
        //    var value = context.Set<MembershipTypePricePlane>().Where(w => w.MemberShipTypePricePlaneSeqID == model.MemberShipTypePricePlaneSeqID).FirstOrDefault();
        //    MemberShipTypeWithCustomerRepository memberShipTypeWithCustomerRepository = new MemberShipTypeWithCustomerRepository(context);
        //    var priceinfo = context.Set<MemberShipPaymentPlanWithPaymentChannel>().Where(x => x.MemberShipTypePricePlaneSeqID.Equals(model.MemberShipTypePricePlaneSeqID)).FirstOrDefault();
        //    if (context.Set<MemberShipTypeWithCustomer>().Any(x => x.MemberShipTypePricePlaneSeqID == model.MemberShipTypePricePlaneSeqID && x.IsActive.Equals(true)))
        //    {
        //        return false;
        //    }
        //    bool result=IyzipayEntegration.DeleteProductPlan(priceinfo.ReferenceCode);
        //    result = AddNeWPricePlan(model);
        //    if (result)
        //    {
        //        value.PlaneName = model.PlaneName;
        //        value.MemberShipTypeSeqID = model.MemberShipTypeSeqID;
        //        value.Price = model.Price;
        //        value.PaymentPeriod = model.PaymentPeriod;
        //        value.TrailPeriodDay = model.TrailPeriodDay;
        //        value.AutoRenewalCount = model.AutoRenewalCount;
        //        value.CurrencyID = model.CurrencyID;
        //        value.Status = false;
        //        value.CreatedOn = DateTime.Now;
        //        value.UpdatedOn = DateTime.Now;
        //        TUpdate(value);
        //        return true;
        //    }
        //    return false;
        //}

        //public MembershipTypePricePlane GetWithUserID(string UserID)
        //{
        //    MemberShipTypeWithCustomerRepository memberShipTypeWithCustomerRepository = new MemberShipTypeWithCustomerRepository(context);
        //    var memberShipPricePlanInfo = memberShipTypeWithCustomerRepository.getMemberShipTypeWithCustomers(UserID);
        //    var result = dbset.Find(memberShipPricePlanInfo.MemberShipTypePricePlaneSeqID);
        //    return result;
        //}
        //public List<MembershipTypePricePlane> GetAllActivePricePlane()
        //{
        //    var result = dbset.Where(x=>x.Status.Equals(true)).ToList();
        //    return result;
        //}
        public MembershipTypePricePlane GetLast()
        {
            string sql = "select top 1 * from MembershipTypePricePlane where MemberShipTypePricePlaneSeqID=(select max(MemberShipTypePricePlaneSeqID) from MembershipTypePricePlane)";
            var result = dbset.FromSqlRaw(sql).FirstOrDefault();

            return result;
        }


        //public bool AddNeWPricePlanForAlternativeOfCancle(MembershipTypePricePlaneModel model)//Önder Özbek
        //{
        //    bool returnvalue = true;
        //    int _memberShipTypeSeqID = (int)model.MemberShipTypeSeqID;
        //    string PlanRefNo = "";
        //    MembershipTypePricePlane MembershipTypePricePlane = new MembershipTypePricePlane();
        //    MembershipTypePricePlane.PlaneName = model.PlaneName;
        //    MembershipTypePricePlane.MemberShipTypeSeqID = model.MemberShipTypeSeqID;
        //    MembershipTypePricePlane.Price = model.Price;
        //    MembershipTypePricePlane.PaymentPeriod = model.PaymentPeriod;
        //    MembershipTypePricePlane.TrailPeriodDay = model.TrailPeriodDay;
        //    MembershipTypePricePlane.AutoRenewalCount = model.AutoRenewalCount;
        //    MembershipTypePricePlane.Status = model.Status;
        //    MembershipTypePricePlane.CreatedOn = DateTime.Now;
        //    MembershipTypePricePlane.UpdatedOn = DateTime.Now;
        //    MembershipTypePricePlane.CurrencyID = model.CurrencyID;

        //    if (Parameters.isHasIzicoo)
        //    {
        //        MemberShipPaymentPlanWithPaymentChannel memberShipPaymentPlanWithPayment = new MemberShipPaymentPlanWithPaymentChannel();
        //        memberShipPaymentPlanWithPayment.MemberShipTypeSeqID = model.MemberShipTypeSeqID;
        //        var ff = context.Set<MemberShipTypesWithPaymentChanel>().Where(p => p.MemberShipTypeSeqID == _memberShipTypeSeqID).FirstOrDefault();
        //        var pertod = context.Set<PaymentPeriodDef>().Where(p => p.PaymentPeriodDefId == model.PaymentPeriod).FirstOrDefault();
        //        bool rezult = IyzipayEntegration.CreateProductPlanForAlternativeOfCancle(model, ff.ReferenceCode, pertod.Value.ToString().Trim(), out PlanRefNo);
        //        if (rezult)
        //        {
        //            TAdd(MembershipTypePricePlane);

        //            var membershipTypePricePlane = context.Set<MembershipTypePricePlane>().Where(p => p.MemberShipTypeSeqID == _memberShipTypeSeqID).FirstOrDefault();
        //            memberShipPaymentPlanWithPayment.MemberShipTypePricePlaneSeqID = MembershipTypePricePlane.MemberShipTypePricePlaneSeqID;//membershipTypePricePlane.MemberShipTypePricePlaneSeqID;
        //            memberShipPaymentPlanWithPayment.MemberShipTypeSeqID = model.MemberShipTypeSeqID;
        //            memberShipPaymentPlanWithPayment.PamentChannelSeqID = PamentChannel.PamentChannelIzicoo;

        //            memberShipPaymentPlanWithPayment.ReferenceCode = PlanRefNo;
        //            memberShipPaymentPlanWithPayment.DisplayOrderNumber = 1;
        //            memberShipPaymentPlanWithPayment.CreatedOn = DateTime.Now;
        //            memberShipPaymentPlanWithPayment.UpdatedOn = DateTime.Now;
        //            context.Set<MemberShipPaymentPlanWithPaymentChannel>().Add(memberShipPaymentPlanWithPayment);
        //            context.SaveChanges();
        //        }
        //        else
        //        {
        //            returnvalue = false;
        //        }
        //    }
        //    return returnvalue;
        //}

    }
}
