using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using Quki.Bll.Base;
using Quki.Dal.Abstract;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;
using Quki.Interface;

namespace Quki.Bll
{
    public class PaymentPeriodDefManager : BllBase<PaymentPeriodDef, PaymentPeriodDefModel>, IPaymentPeriodDefService
    {
        public readonly IPaymentPeriodDefRepository repo;
        public PaymentPeriodDefManager(IServiceProvider service) : base(service)
        {
            repo = service.GetService<IPaymentPeriodDefRepository>();
        }
        
      
    }
}
