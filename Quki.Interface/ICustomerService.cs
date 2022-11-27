using System.Collections.Generic;
using Quki.Entity.DtoModels;
using Quki.Entity.DtoModels.ApiModels;
using Quki.Entity.Models;
using Quki.Entity.ViewModel;

namespace Quki.Interface
{
    public interface ICustomerService : IGenericService<Customer, CustomerAddModel>
    {
        public bool CustomerAddNewCustomer(CustomerAddModel CustomerAddModel);
        public long MemberShipTypeWithCustomersAdd(SubscriptionInitializeModel subscriptionInitializeModel, string id, out string izicoResult);
        public bool CanceCustomer(string id,out string ErrorMessage);
        public bool CancelCustomerApi(string id,out bool resultCancel,out bool result ,out string ErrorMessage);
        public List<Customer> CustomerGetAll();
        public string GetCustomerStatus(string Status);
        public List<SubscriptionOrder> GetCustemerInformationWithIzico(string id);
        public void UpdateCustomerApi(UserUpdate customer);
        public List<GetCustomersModel> GetCustomers();
        public Customer CustomerGetByUserID(string userID);
        public UserProfile UserProfilesGetByUserID(string userID);
        public long MemberShipTypeWithCustomersAddApi(string userID, string planID, int paymentChanel, string CustemerRefCode,string PurchaseToken, out string Message);
        }
}
