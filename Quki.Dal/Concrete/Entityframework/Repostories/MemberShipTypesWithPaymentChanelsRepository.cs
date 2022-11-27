using Microsoft.EntityFrameworkCore;
using Quki.Dal.Abstract;
using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Entity.Models;

namespace Quki.Dal.Concrete.Entityframework.Repostories
{
    public class MemberShipTypesWithPaymentChanelsRepository : GenericRepository<MemberShipTypesWithPaymentChanel>, IMemberShipTypesWithPaymentChanelsRepository
    {
        public MemberShipTypesWithPaymentChanelsRepository(DbContext context) :base(context)
        {
           
        }
    }
}
