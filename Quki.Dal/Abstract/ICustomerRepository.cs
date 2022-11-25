using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Quki.Entity.Models;

namespace Quki.Dal.Abstract
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        //public bool CustomerAddNewCustomer(CustomerAddModel customerAddModel);
        //public long MemberShipTypeWithCustomersAdd(SubscriptionInitializeModel subscriptionInitializeModel, string id, out string izicoResult);
        //public bool CanceCustomer(string id, out string ErrorMessage);
        //public List<Customer> CustomerGetAll();
        //public string GetCustomerStatus(string Status);
        //public List<SubscriptionOrder> GetCustemerInformationWithIzico(string id);
        //public void UpdateCustomerApi(UserUpdate customer);
        //public List<GetCustomersModel> GetCustomers();
        //public Customer CustomerGetByUserID(string userID);
        public List<SelectListItem> GetAllCustomers();


    }
}
