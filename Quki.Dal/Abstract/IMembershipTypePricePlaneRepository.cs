
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;

namespace Quki.Dal.Abstract
{
    public interface IMembershipTypePricePlaneRepository : IGenericRepository<MembershipTypePricePlane>
    {

        //public List<MembershipTypePricePlane> GetMembershipTypePricePlaneByMemberShipTypeID(int MemberShipTypeSeqID);
        //public MembershipTypePricePlane SelectByID(int MemberShipTypePricePlaneSeqID);
        //public MembershipTypePricePlane GetWithID(int id);
        //public bool AddNeWPricePlan(MembershipTypePricePlaneModel model);
        //public List<SelectListItem> GetPaymentPeriodDefListForDropdown();
        //public bool Delete(int id);
        //public bool Update(MembershipTypePricePlaneModel model);
        //public MembershipTypePricePlane GetWithUserID(string UserID);
        public MembershipTypePricePlane GetLast();
        //public bool AddNeWPricePlanForAlternativeOfCancle(MembershipTypePricePlaneModel model);
    }
}
