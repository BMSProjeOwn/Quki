using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Quki.Dal.Abstract;
using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Entity.Models;
using Quki.Entity.Parameters;

namespace Quki.Dal.Concrete.Entityframework.Repostories
{
    public class MemberShipTypeWithCustomerRepository : GenericRepository<MemberShipTypeWithCustomer>, IMemberShipTypeWithCustomerRepository
    {
        public MemberShipTypeWithCustomerRepository(DbContext context) : base(context)
        {
            
        }
        public long AddMemberShipMemberShipTypeWithCustomer(string id, string ReferenceCode, MemberShipPaymentPlanWithPaymentChannel plan)
        {
            MemberShipTypeWithCustomer memberShipTypeWithCustomer = new MemberShipTypeWithCustomer();
            memberShipTypeWithCustomer.Id = id;
            memberShipTypeWithCustomer.StartDateTime = DateTime.Now;
            MembershipTypePricePlane membershipTypePricePlaneInfo = new MembershipTypePricePlane();
            MembershipTypePricePlaneRepository membershipTypePricePlaneRepository = new MembershipTypePricePlaneRepository(context);
            membershipTypePricePlaneInfo = membershipTypePricePlaneRepository.TGetList(p => p.MemberShipTypePricePlaneSeqID == plan.MemberShipTypePricePlaneSeqID && p.Status == true).FirstOrDefault();
            if (membershipTypePricePlaneInfo.PaymentPeriod == (int)PaymentPeriyod.AYLIK)
            {
                memberShipTypeWithCustomer.EndDateTime = DateTime.Now.AddMonths(membershipTypePricePlaneInfo.AutoRenewalCount.Value);
            }
            if (membershipTypePricePlaneInfo.PaymentPeriod == (int)PaymentPeriyod.HAFTALIK)
            {
                memberShipTypeWithCustomer.EndDateTime = DateTime.Now.AddDays(membershipTypePricePlaneInfo.AutoRenewalCount.Value * 7);
            }
            if (membershipTypePricePlaneInfo.PaymentPeriod == (int)PaymentPeriyod.YILLIK)
            {
                memberShipTypeWithCustomer.EndDateTime = DateTime.Now.AddYears(membershipTypePricePlaneInfo.AutoRenewalCount.Value);
            }
            memberShipTypeWithCustomer.IsActive = true;
            memberShipTypeWithCustomer.CurrencySeqID = 1;
            memberShipTypeWithCustomer.MemberShipTypeSeqID = plan.MemberShipTypeSeqID;
            memberShipTypeWithCustomer.MemberShipTypePricePlaneSeqID = plan.MemberShipTypePricePlaneSeqID;
            TAdd(memberShipTypeWithCustomer);
            var cc = context.Set<MemberShipTypeWithCustomer>().OrderByDescending(u => u.MemberShipTypeWithCustomerSeqID).FirstOrDefault();

            MemberShipTypeWithCustomersPaymentChanel me = new MemberShipTypeWithCustomersPaymentChanel();
            me.MemberShipTypeWithCustomerSeqID = cc.MemberShipTypeWithCustomerSeqID;
            me.MemberShipWithPamentChannelSeqID = PamentChannel.PamentChannelIzicoo;
            me.ReferenceCode = ReferenceCode;
            context.Set<MemberShipTypeWithCustomersPaymentChanel>().Add(me);
            context.SaveChanges();
            return memberShipTypeWithCustomer.MemberShipTypeWithCustomerSeqID;
            //TAdd(me);
        }
        //public void UpdateMemberShipMemberShipTypeWithCustomer(string id, string ReferenceCode, MemberShipPaymentPlanWithPaymentChannel plan)
        //{
        //    string[] array = id.Split('&');
        //    string userID = array[0].ToString();

        //    MemberShipTypeWithCustomer cc = new MemberShipTypeWithCustomer();
        //    MemberShipTypeWithCustomersPaymentChanel mstcpEntity = new MemberShipTypeWithCustomersPaymentChanel();
        //    try { cc = dbset.Where(u => u.Id == userID && u.IsActive == true).FirstOrDefault(); } catch { }
        //    try { mstcpEntity = context.Set<MemberShipTypeWithCustomersPaymentChanel>().Where(u => u.MemberShipTypeWithCustomerSeqID == cc.MemberShipTypeWithCustomerSeqID).FirstOrDefault(); } catch { }
        //    mstcpEntity.ReferenceCode = ReferenceCode;
        //    context.Set<MemberShipTypeWithCustomersPaymentChanel>().Update(mstcpEntity);
        //    context.SaveChanges();
        //}
        public MemberShipTypeWithCustomer getMemberShipTypeWithCustomers(string id)
        {
            string[] array = id.Split('&');
            string userID = array[0].ToString();

            MemberShipTypeWithCustomer cc = new MemberShipTypeWithCustomer();
            try { cc = dbset.Where(u => u.Id == userID && u.IsActive == true).FirstOrDefault(); } catch { }
            return cc;
            //TAdd(me);
        }



        public bool MemberShipTypeWithCustomersDelete(string id)
        {
            var cc = dbset.Where(u => u.Id == id && u.IsActive == true).FirstOrDefault();
            cc.IsActive = false;
            cc.UpdatedOn = DateTime.Now;
            try
            {
                TUpdate(cc);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            //TAdd(me);
        }

        //public MemberShipTypeWithCustomersPaymentChanel getMemberShipTypeWithCustomersPaymentChanel(string id)
        //{
        //    var cc = dbset.Where(u => u.Id == id && u.IsActive == true).FirstOrDefault();
        //    var memberShipTypeWithCustomersPaymentChanel = context.Set<MemberShipTypeWithCustomersPaymentChanel>().Where(u => u.MemberShipTypeWithCustomerSeqID == cc.MemberShipTypeWithCustomerSeqID).FirstOrDefault();
        //    return memberShipTypeWithCustomersPaymentChanel;
        //    //TAdd(me);
        //}

        //public void AddMemberShipMemberShipTypeWithCustomerPaymentChanel(string id, string ReferenceCode, int status, MemberShipPaymentPlanWithPaymentChannel plan, DateTime endDate)//Önder Özbek
        //{
        //    MemberShipTypeWithCustomer memberShipTypeWithCustomer = new MemberShipTypeWithCustomer();
        //    memberShipTypeWithCustomer.Id = id;
        //    memberShipTypeWithCustomer.StartDateTime = DateTime.Now;
        //    memberShipTypeWithCustomer.EndDateTime = endDate;
        //    memberShipTypeWithCustomer.IsActive = true;
        //    memberShipTypeWithCustomer.MembershipStatus = status;
        //    memberShipTypeWithCustomer.CurrencySeqID = 1;
        //    memberShipTypeWithCustomer.MemberShipTypeSeqID = plan.MemberShipTypeSeqID;
        //    memberShipTypeWithCustomer.MemberShipTypePricePlaneSeqID = plan.MemberShipTypePricePlaneSeqID;
        //    TAdd(memberShipTypeWithCustomer);
        //    var cc = dbset.OrderByDescending(u => u.MemberShipTypeWithCustomerSeqID).FirstOrDefault();

        //    MemberShipTypeWithCustomersPaymentChanel me = new MemberShipTypeWithCustomersPaymentChanel();
        //    me.MemberShipTypeWithCustomerSeqID = cc.MemberShipTypeWithCustomerSeqID;
        //    me.MemberShipWithPamentChannelSeqID = PamentChannel.PamentChannelIzicoo;
        //    me.MemberShipWithPamentChannelSeqID = PamentChannel.PamentChannelIzicoo;
        //    me.ReferenceCode = ReferenceCode;
        //    context.Set<MemberShipTypeWithCustomersPaymentChanel>().Add(me);
        //    context.SaveChanges();
        //    //TAdd(me);
        //}




        //public List<SelectListItem> GetAllCustomers()
        //{
        //    return dbset
        //    .Where(w => w.IsActive == true).Join(context.Set<UserProfile>(), M => M.Id, U => U.Id, (MemberShipTypeWithCustomers, UserProfiles) => new
        //    {
        //        M = MemberShipTypeWithCustomers,
        //        U = UserProfiles
        //    }).Select(s => new SelectListItem
        //    {
        //        Value = s.M.MemberShipTypeWithCustomerSeqID.ToString(),
        //        Text = s.U.Name + " " + s.U.Surname
        //    }
        //        ).ToList();
        //    // contex.MemberShipTypeWithCustomers.Where(w => w.IsActive == true).Select(s => new SelectListItem
        //    //{
        //    //    Value = s.MemberShipTypeWithCustomerSeqID.ToString(),
        //    //    Text = s.Id
        //    //}).ToList();

        //}

        public long AddMemberShipMemberShipTypeWithCustomerApi(string id, string ReferenceCode, MemberShipPaymentPlanWithPaymentChannel plan, string purchaseToken ,int paymentChanel)
        {
            MemberShipTypeWithCustomer memberShipTypeWithCustomer = new MemberShipTypeWithCustomer();
            memberShipTypeWithCustomer.Id = id;
            memberShipTypeWithCustomer.StartDateTime = DateTime.Now;
            MembershipTypePricePlane membershipTypePricePlaneInfo = new MembershipTypePricePlane();
            membershipTypePricePlaneInfo = context.Set<MembershipTypePricePlane>().Where(x=>x.MemberShipTypePricePlaneSeqID.Equals(plan.MemberShipTypePricePlaneSeqID)).FirstOrDefault();
            if (membershipTypePricePlaneInfo.PaymentPeriod == (int)PaymentPeriyod.AYLIK)
            {
                memberShipTypeWithCustomer.EndDateTime = DateTime.Now.AddMonths(membershipTypePricePlaneInfo.AutoRenewalCount.Value);
            }
            if (membershipTypePricePlaneInfo.PaymentPeriod == (int)PaymentPeriyod.HAFTALIK)
            {
                memberShipTypeWithCustomer.EndDateTime = DateTime.Now.AddDays(membershipTypePricePlaneInfo.AutoRenewalCount.Value * 7);
            }
            if (membershipTypePricePlaneInfo.PaymentPeriod == (int)PaymentPeriyod.YILLIK)
            {
                memberShipTypeWithCustomer.EndDateTime = DateTime.Now.AddYears(membershipTypePricePlaneInfo.AutoRenewalCount.Value);
            }
            memberShipTypeWithCustomer.IsActive = true;
            memberShipTypeWithCustomer.CurrencySeqID = 1;
            memberShipTypeWithCustomer.MemberShipTypeSeqID = plan.MemberShipTypeSeqID;
            memberShipTypeWithCustomer.MemberShipTypePricePlaneSeqID = plan.MemberShipTypePricePlaneSeqID;
            TAdd(memberShipTypeWithCustomer);
            var cc = context.Set<MemberShipTypeWithCustomer>().OrderByDescending(u => u.MemberShipTypeWithCustomerSeqID).FirstOrDefault();

            MemberShipTypeWithCustomersPaymentChanel me = new MemberShipTypeWithCustomersPaymentChanel();
            me.MemberShipTypeWithCustomerSeqID = cc.MemberShipTypeWithCustomerSeqID;
            me.MemberShipWithPamentChannelSeqID = paymentChanel;
            me.ReferenceCode = ReferenceCode;
            me.ReferenceStatus = purchaseToken;
            context.Set<MemberShipTypeWithCustomersPaymentChanel>().Add(me);
            context.SaveChanges();
            return memberShipTypeWithCustomer.MemberShipTypeWithCustomerSeqID;
            //TAdd(me);
        }

        public bool UpdateEndDateTime(string id, int MembershipStatus)
        {
            var cc = dbset.Where(u => u.Id == id && u.IsActive == true).FirstOrDefault();

            int dayOfToday = DateTime.Now.Day;
            int dayOfEndDate = Convert.ToInt32(cc.EndDateTime.ToString("dd"));

            bool createNewDate = false;
            var pay = context.Set<Payments>().Where(w => w.MemberShipTypeWithCustomerSeqID == cc.MemberShipTypeWithCustomerSeqID && w.Status == 1 && cc.CreatedOn > DateTime.Now.AddMonths(-1)).FirstOrDefault();
            if (pay != null)
            {
                createNewDate = true;
            }

            if (createNewDate)
            {
                if (dayOfToday >= dayOfEndDate)
                {
                    cc.EndDateTime = DateTime.Now.AddMonths(1).AddDays(-(dayOfToday - dayOfEndDate));
                }
                else
                {
                    cc.EndDateTime = DateTime.Now.AddDays(dayOfEndDate - dayOfToday);
                }
            }
            else
            {
                cc.EndDateTime = DateTime.Now;
                cc.IsActive = false;
            }
            cc.UpdatedOn = DateTime.Now;
            cc.MembershipStatus = MembershipStatus;
            TUpdate(cc);
            return true;
        }

    }
}
