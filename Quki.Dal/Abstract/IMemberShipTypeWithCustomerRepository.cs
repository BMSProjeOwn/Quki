using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Entity.Models;
using Quki.Entity.Parameters;

namespace Quki.Dal.Abstract
{
    public interface IMemberShipTypeWithCustomerRepository : IGenericRepository<MemberShipTypeWithCustomer>
    {

        public long AddMemberShipMemberShipTypeWithCustomer(string id, string ReferenceCode, MemberShipPaymentPlanWithPaymentChannel plan);
        public long AddMemberShipMemberShipTypeWithCustomerApi(string id, string ReferenceCode, MemberShipPaymentPlanWithPaymentChannel plan, string purchaseToken,int paymentChanel);
        //public void UpdateMemberShipMemberShipTypeWithCustomer(string id, string ReferenceCode, MemberShipPaymentPlanWithPaymentChannel plan);
        public MemberShipTypeWithCustomer getMemberShipTypeWithCustomers(string id);
        public bool MemberShipTypeWithCustomersDelete(string id);
        //public MemberShipTypeWithCustomersPaymentChanel getMemberShipTypeWithCustomersPaymentChanel(string id);
        //public void AddMemberShipMemberShipTypeWithCustomerPaymentChanel(string id, string ReferenceCode, int status, MemberShipPaymentPlanWithPaymentChannel plan, DateTime endDate);
        //public List<SelectListItem> GetAllCustomers();
        public bool UpdateEndDateTime(string id, int MembershipStatus);
    }
}
