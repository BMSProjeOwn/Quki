using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using Quki.Bll.Base;
using Quki.Dal.Abstract;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;
using Quki.Interface;

namespace Quki.Bll
{
    public class MemberShipWithCancelReasonManager : BllBase<MemberShipWithCancelReason, MemberShipWithCancelReasonModel>, IMemberShipWithCancelReasonService
    {
        public readonly IMemberShipWithCancelReasonRepository repo;
        public MemberShipWithCancelReasonManager(IServiceProvider service) : base(service)
        {
            repo = service.GetService<IMemberShipWithCancelReasonRepository>();
        }
        public List<MemberShipWithCancelReason> GetUserCancelReasonsLastMonth(Guid UserId)
        {
            var list = TGetList(x => x.IsActive == true && x.UserId == UserId && x.CreatedOn > DateTime.Now.AddMonths(-1)).ToList();
            return list;
        }
    }
}
