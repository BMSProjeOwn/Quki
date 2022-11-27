using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json;
using Quki.Common;
using Quki.Entity.DtoModels;
using Quki.Entity.DtoModels.ApiModels;
using Quki.Entity.Models;
using Quki.Interface;
using Quki.WebApi.Base;

namespace Quki.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class IyzicoController : ApiBaseController<IPaymentsService, Payments, PaymentsModel>
    {
        private readonly IPaymentsService service;
        private readonly IErrorLogService errorLogService;
        public IyzicoController(IPaymentsService service, IErrorLogService errorLogService, IPlayListDetailService playListDetailService) : base(service)
        {
            this.service = service;
            this.errorLogService = errorLogService;
        }
        [HttpPost]
        public void GetPaymentEvent([FromBody] JsonElement JObject)
        {
            errorLogService.ErrorLogAdd("public void GetPaymentEvent([FromBody] JsonElement JObject)           " + JObject.ToString());

            PaymentEventModel response = Functions.ToObject<PaymentEventModel>(JObject);

            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);

            Common.Functions.SubscribePaymentControl(response.subscriptionReferenceCode);

            //var orderResponse = IyzipayEntegration.SubscriptionReturnOrder(response.subscriptionReferenceCode);

            //if (orderResponse.Status != null)
            //{

            //    if (orderResponse.Status.ToString() == Status.SUCCESS.ToString())
            //    {


            //        if (orderResponse.Data.SubscriptionStatus == SubscriptionStatus.ACTIVE.ToString())
            //        {

            //            for (int i = 0; i < orderResponse.Data.SubscriptionOrders.Count; i++)
            //            {

            //                using var contex = new Contexts.ProjeDBContext();

            //                var pay = contex.Payments
            //                    .Where(w => w.OrderReferenceCode == orderResponse.Data.SubscriptionOrders[i].ReferenceCode).FirstOrDefault();

            //                if (pay == null)
            //                {
            //                    Payments payments = new Payments();

            //                    var princPlane = contex.MembershipTypePricePlane
            //                        .Join(contex.MemberShipPaymentPlanWithPaymentChannel, mpp => mpp.MemberShipTypePricePlaneSeqID,
            //                        mpc => mpc.MemberShipTypePricePlaneSeqID
            //                        , (MembershipTypePricePlane, memberShipPaymentPlanWithPaymentChannel) => new
            //                        {
            //                            MembershipTypePricePlane = MembershipTypePricePlane,
            //                            MemberShipPaymentPlanWithPaymentChannel = memberShipPaymentPlanWithPaymentChannel
            //                        }).Where(w => w.MemberShipPaymentPlanWithPaymentChannel.ReferenceCode == orderResponse.Data.PricingPlanReferenceCode)
            //                        .FirstOrDefault();

            //                    var
            //                        meberShipWithCustomer = contex.MemberShipTypeWithCustomersPaymentChanel
            //                               .Where(w => w.ReferenceCode == orderResponse.Data.ReferenceCode).FirstOrDefault();



            //                    payments.CustomerReferenceCode = response.subscriptionReferenceCode;
            //                    payments.OrderReferenceCode = orderResponse.Data.SubscriptionOrders[i].ReferenceCode;
            //                    payments.PaymentAmount = Convert.ToDecimal(orderResponse.Data.SubscriptionOrders[i].Price.Replace('.', ','));
            //                    payments.PaymentChannelSeqID = 1;
            //                    payments.PaymentChannelReferenceCode = response.iyziReferenceCode;

            //                    if (orderResponse.Data.SubscriptionOrders[i].CurrencyCode == CurrencyEnum.TRY.ToString())
            //                        payments.PaymentCurrencyTypeSeqID = (int)CurrencyEnum.TRY;
            //                    else if (orderResponse.Data.SubscriptionOrders[i].CurrencyCode == CurrencyEnum.EUR.ToString())
            //                        payments.PaymentCurrencyTypeSeqID = (int)CurrencyEnum.EUR;
            //                    else if (orderResponse.Data.SubscriptionOrders[i].CurrencyCode == CurrencyEnum.USD.ToString())
            //                        payments.PaymentCurrencyTypeSeqID = (int)CurrencyEnum.USD;
            //                    else
            //                        payments.PaymentCurrencyTypeSeqID = 0;
            //                    try { payments.MemberShipTypePricePlaneSeqID = princPlane.MembershipTypePricePlane.MemberShipTypePricePlaneSeqID; }
            //                    catch { payments.MemberShipTypePricePlaneSeqID = 0; }
            //                    try { payments.MemberShipTypeWithCustomerSeqID = meberShipWithCustomer.MemberShipTypeWithCustomerSeqID; }
            //                    catch { payments.MemberShipTypeWithCustomerSeqID = 0; }
            //                    payments.EventTime = response.iyziEventTime;

            //                    if (orderResponse.Data.SubscriptionOrders[i].OrderStatus == "SUCCESS")
            //                        payments.Status = 1;
            //                    else
            //                        payments.Status = 2;
            //                    payments.Remark = "";
            //                    payments.ReturnMessage = "";
            //                    payments.PeriodNumber = 0;
            //                    payments.Type = 0;
            //                    payments.CreatedDate = DateTime.Now;
            //                    paymentsRepository.TAdd(payments);

            //                    var mwcustomer = contex.MemberShipTypeWithCustomers
            //                        .Where(w => w.MemberShipTypeWithCustomerSeqID == meberShipWithCustomer.MemberShipTypeWithCustomerSeqID).FirstOrDefault();

            //                    SendInvoice(mwcustomer, princPlane.MembershipTypePricePlane);
            //                    Thread t = new Thread(new ThreadStart(ThreadInvoceControl));
            //                    t.Start();
            //                }
            //                else
            //                {
            //                    short? st = 0;
            //                    if (orderResponse.Data.SubscriptionOrders[i].OrderStatus == "SUCCESS")
            //                        st = 1;
            //                    else
            //                        st = 2;
            //                    if (pay.Status != st)
            //                    {
            //                        pay.UpdateDate = DateTime.Now;
            //                        pay.Status = st;
            //                        paymentsRepository.TUpdate(pay);
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}
            if (response.iyziEventType != "subscription.order.success")
            {
                IyzipayEntegration.Retry(response.orderReferenceCode);
            }
        }
    }
}
