
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Quki.Dal.Abstract;
using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Entity.Models;

namespace Quki.Dal.Concrete.Entityframework.Repostories
{
    public class MemberShipPaymentPlanWithPaymentChannelRepository : GenericRepository<MemberShipPaymentPlanWithPaymentChannel>, IMemberShipPaymentPlanWithPaymentChannelRepository
    {

        public MemberShipPaymentPlanWithPaymentChannelRepository(DbContext context):base(context)
        {
            
        }

        public MemberShipPaymentPlanWithPaymentChannel GetLast()
        {
            string sql = "select top 1 * from MemberShipPaymentPlanWithPaymentChannel where MemberShipWithPaymentChannelSeqID=(select max(MemberShipWithPaymentChannelSeqID) from MemberShipPaymentPlanWithPaymentChannel)";
            var result = dbset.FromSqlRaw(sql).FirstOrDefault();

            return result;
        }
    }
}
