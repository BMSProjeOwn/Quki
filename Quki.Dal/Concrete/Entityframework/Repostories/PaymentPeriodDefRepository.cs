using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Quki.Dal.Abstract;
using Quki.Entity.Models;
using Quki.Entity.Parameters;

namespace Quki.Dal.Concrete.Entityframework.Repostories
{
    public class PaymentPeriodDefRepository : GenericRepository<PaymentPeriodDef>, IPaymentPeriodDefRepository
    {
        public PaymentPeriodDefRepository(DbContext context) : base(context)
        {
            
        }
       
    }
}
