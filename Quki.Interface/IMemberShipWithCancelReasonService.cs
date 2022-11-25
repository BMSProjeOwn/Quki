using System;
using System.Collections.Generic;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;

namespace Quki.Interface
{
    public interface IMemberShipWithCancelReasonService : IGenericService<MemberShipWithCancelReason, MemberShipWithCancelReasonModel>
    {
       
        public List<MemberShipWithCancelReason> GetUserCancelReasonsLastMonth(Guid UserId);
        
    }
}
