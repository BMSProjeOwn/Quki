using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quki.Dal.Abstract;
using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Entity.Models;
using Quki.Interface;

namespace Quki.Dal.Concrete.Entityframework.Repostories
{
    public class PaymentChanelWithDeviceTypeManager : GenericRepository<PaymentChanelWithDeviceType>,IPaymentChanelWithDeviceTypeService
    {
        public PaymentChanelWithDeviceTypeManager(DbContext context) : base(context)
        {
        }
        public List<PaymentChannel> GetPaymentChanelListByDeviceTypeAndPricePlane(int pricePalneSeqId, string deviceType)
        {
            var paymentChael = context.Set<PaymentChannel>()
                .Join(
                    context.Set<PaymentChanelWithDeviceType>().ToList()
                    , PaymentChannel => PaymentChannel.PaymentChannelSeqID
                    , PaymentChanelWithDeviceType => PaymentChanelWithDeviceType.PaymentChanelSeqID
                    , (PaymentChanne, PaymentChanelWithDeviceTypel) => new
                    {
                        PaymentChanne = PaymentChanne,
                        PaymentChanelWithDeviceTypel = PaymentChanelWithDeviceTypel
                    })
                .Join(
                    context.Set<DeviceType>().ToList()
                    , PaymentChanelWithDeviceType => PaymentChanelWithDeviceType.PaymentChanelWithDeviceTypel.DeviceTypeSeqID
                    , DeviceType => DeviceType.DeviceTypeSeqID
                    , (PaymentChanelWithDeviceType, DeviceType) => new
                    {
                        PaymentChanelWithDeviceType = PaymentChanelWithDeviceType,
                        DeviceType = DeviceType
                    })
                .Join(
                    context.Set<MemberShipPaymentPlanWithPaymentChannel>().ToList()
                    , PaymentChanelWithDeviceType => PaymentChanelWithDeviceType.PaymentChanelWithDeviceType.PaymentChanelWithDeviceTypel.PaymentChanelSeqID
                    , MemberShipPaymentPlanWithPaymentChannel => MemberShipPaymentPlanWithPaymentChannel.PamentChannelSeqID
                    , (PaymentChanelWithDeviceType, MemberShipPaymentPlanWithPaymentChannel) => new
                    {
                        PaymentChanelWithDeviceType = PaymentChanelWithDeviceType,
                        MemberShipPaymentPlanWithPaymentChannel = MemberShipPaymentPlanWithPaymentChannel
                    })
                .Where(I =>
                    I.MemberShipPaymentPlanWithPaymentChannel.MemberShipTypePricePlaneSeqID == pricePalneSeqId
                    && I.PaymentChanelWithDeviceType.DeviceType.DeviceTypeName == deviceType)
                .Select(I => I.PaymentChanelWithDeviceType.PaymentChanelWithDeviceType.PaymentChanne)
                .ToList();
            return paymentChael;
        }
    }
}
