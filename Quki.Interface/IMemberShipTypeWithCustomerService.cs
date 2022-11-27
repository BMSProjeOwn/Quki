using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;

namespace Quki.Interface
{
    public interface IMemberShipTypeWithCustomerService : IGenericService<MemberShipTypeWithCustomer, MemberShipTypeWithCustomerModel>
    {

        public long AddMemberShipMemberShipTypeWithCustomer(string id, string ReferenceCode, MemberShipPaymentPlanWithPaymentChannel plan);
        public void UpdateMemberShipMemberShipTypeWithCustomer(string id, string ReferenceCode, MemberShipPaymentPlanWithPaymentChannel plan);
        public MemberShipTypeWithCustomer getMemberShipTypeWithCustomers(string id);
        public bool MemberShipTypeWithCustomersDelete(string id);
        public MemberShipTypeWithCustomersPaymentChanel getMemberShipTypeWithCustomersPaymentChanel(string id);
        public void AddMemberShipMemberShipTypeWithCustomerPaymentChanel(string id, string ReferenceCode, int status, MemberShipPaymentPlanWithPaymentChannel plan, DateTime endDate);
        public List<SelectListItem> GetAllCustomers();
        public bool UpdateEndDateTime(string id, int MembershipStatus);
    }
}
