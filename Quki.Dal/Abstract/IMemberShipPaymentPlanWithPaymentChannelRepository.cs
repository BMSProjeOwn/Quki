
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Entity.Models;

namespace Quki.Dal.Abstract
{
    public interface IMemberShipPaymentPlanWithPaymentChannelRepository : IGenericRepository<MemberShipPaymentPlanWithPaymentChannel>
    {
        public MemberShipPaymentPlanWithPaymentChannel GetLast();
    }
}
