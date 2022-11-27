using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quki.Dal.Abstract;
using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Entity.Models;

namespace Quki.Dal.Concrete.Entityframework.Repostories
{
    public class MemberShipWithCancelReasonRepository : GenericRepository<MemberShipWithCancelReason>, IMemberShipWithCancelReasonRepository
    {
        public MemberShipWithCancelReasonRepository(DbContext context) : base(context)
        {
            
        }
        //public List<MemberShipWithCancelReason> GetUserCancelReasonsLastMonth(Guid UserId)
        //{
        //    var list = dbset.Where(x => x.IsActive == true && x.UserId == UserId && x.CreatedOn > DateTime.Now.AddMonths(-1)).ToList();
        //    return list;
        //}
    }
}
