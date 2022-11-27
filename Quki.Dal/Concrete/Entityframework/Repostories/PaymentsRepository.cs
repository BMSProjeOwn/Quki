using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Quki.Dal.Abstract;
using Quki.Entity.Models;
using Quki.Entity.Parameters;

namespace Quki.Dal.Concrete.Entityframework.Repostories
{
    public class PaymentsRepository : GenericRepository<Payments>, IPaymentsRepository
    {
        public PaymentsRepository(DbContext context) : base(context)
        {
            
        }
        //public List<Payments> GetCustomerPaymentTransaction(int MemberShipTypePricePlaneSeqID, int MemberShipTypeWithCustomerSeqID)
        //{
        //    var result =dbset
        //        .Where(w => w.Status == 1
        //            && w.MemberShipTypePricePlaneSeqID == MemberShipTypePricePlaneSeqID
        //            && w.MemberShipTypeWithCustomerSeqID == MemberShipTypeWithCustomerSeqID)
        //        .ToList();
        //    return result;
        //}

        //public void LoadAllPaymnets()
        //{
        //    var result = context.Set<MemberShipTypeWithCustomersPaymentChanel>().Select(s => s.ReferenceCode).ToList();
        //    if (result != null)
        //    {
        //        for (int m = 0; m < result.Count; m++)
        //        {
        //            try
        //            {
        //                var orderResponse = IyzipayEntegration.SubscriptionReturnOrder(result[m]);
        //                for (int i = 0; i < orderResponse.Data.SubscriptionOrders.Count; i++)
        //                {
        //                    var pay = dbset
        //                           .Where(w => w.OrderReferenceCode == orderResponse.Data.SubscriptionOrders[i].ReferenceCode).FirstOrDefault();

        //                    if (pay == null)
        //                    {

        //                        var princPlane = context.Set<MembershipTypePricePlane>()
        //                            .Join(context.Set<MemberShipPaymentPlanWithPaymentChannel>(), mpp => mpp.MemberShipTypePricePlaneSeqID,
        //                            mpc => mpc.MemberShipTypePricePlaneSeqID
        //                            , (MembershipTypePricePlane, memberShipPaymentPlanWithPaymentChannel) => new
        //                            {
        //                                MembershipTypePricePlane = MembershipTypePricePlane,
        //                                MemberShipPaymentPlanWithPaymentChannel = memberShipPaymentPlanWithPaymentChannel
        //                            }).Where(w => w.MemberShipPaymentPlanWithPaymentChannel.ReferenceCode == orderResponse.Data.PricingPlanReferenceCode)
        //                            .FirstOrDefault();


        //                        var meberShipWithCustomer = context.Set<MemberShipTypeWithCustomersPaymentChanel>()
        //                            .Where(w => w.ReferenceCode == orderResponse.Data.CustomerReferenceCode).FirstOrDefault();


        //                        Payments payments = new Payments();
        //                        //payments.PaymentTypesSeqID = 0;
        //                        payments.CustomerReferenceCode = result[m];
        //                        payments.OrderReferenceCode = orderResponse.Data.SubscriptionOrders[i].ReferenceCode;
        //                        //payments.OrdersSeqID = 0;
        //                        payments.PaymentAmount = Convert.ToDecimal(orderResponse.Data.SubscriptionOrders[i].Price.Replace('.', ','));
        //                        payments.PaymentChannelSeqID = 1;
        //                        //payments.PaymentChannelReferenceCode = response.iyziReferenceCode;

        //                        if (orderResponse.Data.SubscriptionOrders[i].CurrencyCode == CurrencyEnum.TRY.ToString())
        //                            payments.PaymentCurrencyTypeSeqID = (int)CurrencyEnum.TRY;
        //                        else if (orderResponse.Data.SubscriptionOrders[i].CurrencyCode == CurrencyEnum.EUR.ToString())
        //                            payments.PaymentCurrencyTypeSeqID = (int)CurrencyEnum.EUR;
        //                        else if (orderResponse.Data.SubscriptionOrders[i].CurrencyCode == CurrencyEnum.USD.ToString())
        //                            payments.PaymentCurrencyTypeSeqID = (int)CurrencyEnum.USD;
        //                        else
        //                            payments.PaymentCurrencyTypeSeqID = 0;
        //                        try { payments.MemberShipTypePricePlaneSeqID = princPlane.MembershipTypePricePlane.MemberShipTypePricePlaneSeqID; } catch { }
        //                        try { payments.MemberShipTypeWithCustomerSeqID = meberShipWithCustomer.MemberShipTypeWithCustomerSeqID; } catch { }
        //                        //payments.StartPaymentPeriod = 0;
        //                        //payments.EndPaymentPeriod = 0;
        //                        //payments.EventTime = response.iyziEventTime;

        //                        if (orderResponse.Data.SubscriptionOrders[i].OrderStatus == "SUCCESS")
        //                            payments.Status = 1;
        //                        else
        //                            payments.Status = 2;
        //                        payments.Remark = "";
        //                        payments.ReturnMessage = "";
        //                        payments.PeriodNumber = 0;
        //                        payments.Type = 0;
        //                        //payments.CreatedBy = 0;
        //                        payments.CreatedDate = DateTime.Now;
        //                        TAdd(payments);
        //                    }
        //                    else
        //                    {

        //                        short? st = 0;
        //                        if (orderResponse.Data.SubscriptionOrders[i].OrderStatus == "SUCCESS")
        //                            st = 1;
        //                        else
        //                            st = 2;
        //                        if (pay.Status != st)
        //                        {
        //                            pay.UpdateDate = DateTime.Now;
        //                            pay.Status = st;
        //                            TUpdate(pay);
        //                        }
        //                    }
        //                }
        //            }
        //            catch { }
        //        }
        //    }
        //}

    }
}
