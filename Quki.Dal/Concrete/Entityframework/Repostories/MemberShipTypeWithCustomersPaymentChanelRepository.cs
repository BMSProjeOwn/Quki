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
    public class MemberShipTypeWithCustomersPaymentChanelRepository : GenericRepository<MemberShipTypeWithCustomersPaymentChanel>, IMemberShipTypeWithCustomersPaymentChanelRepository
    {
        public MemberShipTypeWithCustomersPaymentChanelRepository(DbContext context) : base(context)
        {
            
        }
        
    }
}
