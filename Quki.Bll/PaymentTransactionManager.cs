using Microsoft.Extensions.DependencyInjection;
using System;
using Quki.Bll.Base;
using Quki.Dal.Abstract;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;
using Quki.Interface;

namespace Quki.Bll
{
    public class PaymentTransactionManager : BllBase<MemberShipWithCampaignDefCoupon, MemberShipWithCampaignDefCouponModel>, IPaymentTransactionService
    {
        public readonly IPaymentTransactionRepository repo;
        public PaymentTransactionManager(IServiceProvider service) : base(service)
        {
            repo = service.GetService<IPaymentTransactionRepository>();
        }

    }
}
