using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Quki.Dal.Abstract;
using Quki.Entity.Models;

namespace Quki.Dal.Concrete.Entityframework.Repostories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DbContext context) : base(context)
        {

        }



        public List<SelectListItem> GetAllCustomers()
        {
            var result = context.Set<Customer>().GroupBy(g => new { g.UserID, g.customer_def_name, g.customer_def_surname })
                .Select(s => new SelectListItem
                {
                    Value = s.Key.UserID,
                    Text = s.Key.customer_def_name + " " + s.Key.customer_def_surname
                }).ToList();
            return result;
        }
        //public bool CustomerAddNewCustomer(CustomerAddModel customerAddModel)
        //{
        //    bool result = false;
        //    Customer customer = new Customer();
        //    customer.isUser = true;
        //    customer.CustomerTypeID = 1;
        //    customer.customer_def_name = customerAddModel.customer_def_name;
        //    customer.customer_def_surname = customerAddModel.customer_def_surname;
        //    customer.customer_VknTckn = "11111111111";
        //    customer.email = customerAddModel.email;
        //    customer.UserID = customerAddModel.UserID;
        //    customer.CreatedBy = customerAddModel.UserID;
        //    customer.UpdatedBy = customerAddModel.UserID;
        //    customer.CreatedOn = DateTime.Now;
        //    customer.UpdatedOn = DateTime.Now;
        //    TAdd(customer);
        //    return result;
        //}
        //public Customer CustomerGetByUserID(string userID)
        //{
        //    return dbset.Where(i => i.UserID == userID).FirstOrDefault();
        //}
        //public UserProfile UserProfilesGetByUserID(string userID)
        //{
        //    return context.Set<UserProfile>().Where(i => i.Id == userID).FirstOrDefault();
        //}

        //public long MemberShipTypeWithCustomersAdd(SubscriptionInitializeModel subscriptionInitializeModel, string id, out string izicoResult)
        //{
        //    long result = 0;
        //    izicoResult = "";

        //    string[] array = id.Split('&');
        //    string userID = array[0].ToString();
        //    string planID = array[1].ToString();

        //    if (Parameters.isHasIzicoo)
        //    {
        //        MemberShipTypeRepository memberShipTypeRepository = new MemberShipTypeRepository(context);
        //        Customer customer = CustomerGetByUserID(userID);
        //        UserProfile userProfile = UserProfilesGetByUserID(userID);
        //        if (userProfile.MobPhone != null && userProfile.MobPhone != "")
        //        {
        //            userProfile.MobPhone = Functions.ControlMobilPhone(userProfile.MobPhone);
        //        }
        //        MemberShipPaymentPlanWithPaymentChannel Plan = memberShipTypeRepository.GetMemberShipPricePlanByMemberShipTypePricePlaneSeqID(Convert.ToInt32(planID));

        //        subscriptionInitializeModel.Customer.Email = customer.email;
        //        subscriptionInitializeModel.Customer.IdentityNumber = customer.customer_VknTckn;
        //        subscriptionInitializeModel.Customer.Name = customer.customer_def_name;
        //        subscriptionInitializeModel.Customer.Surname = customer.customer_def_surname;
        //        subscriptionInitializeModel.Customer.GsmNumber = userProfile.MobPhone;
        //        subscriptionInitializeModel.Customer.BillingAddress.City = userProfile.City;
        //        subscriptionInitializeModel.Customer.BillingAddress.ContactName = customer.customer_def_name;
        //        subscriptionInitializeModel.Customer.BillingAddress.Country = userProfile.Country;
        //        subscriptionInitializeModel.Customer.BillingAddress.Description = userProfile.Address1;
        //        subscriptionInitializeModel.Customer.BillingAddress.ZipCode = userProfile.PostalCode;
        //        subscriptionInitializeModel.PricingPlanReferenceCode = Plan.ReferenceCode;

        //        string CustemerRefCode = "";
        //        string ErrorCode = "";
        //        MemberShipTypeWithCustomerRepository membershipTypePricePlaneRepository = new MemberShipTypeWithCustomerRepository(context);
        //        if (membershipTypePricePlaneRepository.getMemberShipTypeWithCustomers(subscriptionInitializeModel.UserID) != null)
        //        {
        //            izicoResult = "Daha Önce Aktif Bir Aboneliğiniz bulunmaktadır";
        //            return 0;
        //        }
        //        MemberShipTypeWithCustomerRepository dd = new MemberShipTypeWithCustomerRepository(context);
        //        //dd.AddMemberShipMemberShipTypeWithCustomer(userID, CustemerRefCode, Plan);
        //        result = 0;
        //        izicoResult = "Kayıt Başarısız";
        //        bool SubscriberResult = IyzipayEntegration.CreateSubscription(subscriptionInitializeModel, out CustemerRefCode, out ErrorCode);

        //        if (SubscriberResult)
        //        {
        //            result = dd.AddMemberShipMemberShipTypeWithCustomer(userID, CustemerRefCode, Plan);
        //            //dd.UpdateMemberShipMemberShipTypeWithCustomer(userID, CustemerRefCode, Plan);
        //            Common.Functions.SubscribePaymentControl(CustemerRefCode);
        //            izicoResult = "Kayıt Başarılı";


        //        }
        //        else
        //        {
        //            //dd.MemberShipTypeWithCustomersDelete(userID);
        //            result = 0;
        //            izicoResult = ErrorCode;
        //        }
        //    }
        //    return result;
        //}
        ////public bool CanceCustomer(string id, out string ErrorMessage)  //Önder Özbek 05.05.2020 memberShipTypeWithCustomer null değilse koşulu eklendi. 
        ////{
        //    ErrorMessage = "";
        //    MemberShipTypeWithCustomerRepository memberShipTypeWithCustomerRepository = new MemberShipTypeWithCustomerRepository(context);

        //    if (Parameters.isHasIzicoo)
        //    {
        //        MemberShipTypeWithCustomer memberShipTypeWithCustomer = memberShipTypeWithCustomerRepository.getMemberShipTypeWithCustomers(id);
        //        if (memberShipTypeWithCustomer != null)
        //        {

        //            var memberShipTypeWithCustomersPaymentChanel = context.Set<MemberShipTypeWithCustomersPaymentChanel>().Where(i => i.MemberShipTypeWithCustomerSeqID == memberShipTypeWithCustomer.MemberShipTypeWithCustomerSeqID).FirstOrDefault();

        //            string CustemerRefCode = memberShipTypeWithCustomersPaymentChanel.ReferenceCode;
        //            string ErrorCode = "";

        //            bool SubscriberResult = IyzipayEntegration.CancelSubscription(CustemerRefCode, out ErrorCode);

        //            if (SubscriberResult)// abonelik iptal edilirse müşterinin Customer with MemberShip Tablosunda activliği iptal edilir.
        //            {
        //                //memberShipTypeWithCustomerRepository.MemberShipTypeWithCustomersDelete(id);
        //                memberShipTypeWithCustomerRepository.UpdateEndDateTime(id, -1);
        //                return true;
        //            }
        //            else
        //            {
        //                ErrorMessage = ErrorCode;
        //                return false;
        //            }
        //        }
        //        else
        //        {
        //            ErrorMessage = "Abone Değil!";
        //            return false;
        //        }
        //    }
        //    else
        //    {
        //        memberShipTypeWithCustomerRepository.MemberShipTypeWithCustomersDelete(id);// abonelik iptal edilirse müşterinin Customer with MemberShip Tablosunda activliği iptal edilir.
        //        return true;
        //    }
        //}
        ////public List<Customer> CustomerGetAll()
        //{
        //    return TGetList();
        //}

        //public string GetCustomerStatus(string Status)
        //{
        //    string result = "";
        //    switch (Status)
        //    {
        //        case "SUCCESS":
        //            result = "BAŞARILI";
        //            break;
        //        case "FAILED":
        //            result = "HATALI";
        //            break;
        //        case "WAITING":
        //            result = "BEKLEMEDE";
        //            break;
        //        case "PROCESSING":
        //            result = "İŞLEMDE";
        //            break;
        //        case "SUBSCRIPTION_UPGRADED":
        //            result = "ABONELİK GÜNCELENDİ";
        //            break;
        //        case "SUBSCRIPTION_CANCELED":
        //            result = "ABONELİK İPTAL EDİLDİ";
        //            break;
        //        case "QUEUED":
        //            result = "SIRADA";
        //            break;
        //        case "MERCHANT_SUSPENDED":
        //            result = "ASKIYA ALINDI";
        //            break;
        //        default:
        //            result = Status;
        //            break;
        //    }
        //    return result;

        ////}
        //public List<SubscriptionOrder> GetCustemerInformationWithIzico(string id) //Önder Özbek 05.05.2020 memberShipTypeWithCustomer null değilse koşulu eklendi. 
        //{
        //    List<SubscriptionOrder> SubscriptionOrderList = new List<SubscriptionOrder>();
        //    MemberShipTypeWithCustomerRepository memberShipTypeWithCustomerRepository = new MemberShipTypeWithCustomerRepository(context);

        //    if (Parameters.isHasIzicoo)
        //    {
        //        MemberShipTypeWithCustomer memberShipTypeWithCustomer = memberShipTypeWithCustomerRepository.getMemberShipTypeWithCustomers(id);

        //        if (memberShipTypeWithCustomer != null)
        //        {

        //            var memberShipTypeWithCustomersPaymentChanel = context.Set<MemberShipTypeWithCustomersPaymentChanel>().Where(i => i.MemberShipTypeWithCustomerSeqID == memberShipTypeWithCustomer.MemberShipTypeWithCustomerSeqID).FirstOrDefault();
        //            var memberShipTypesWithPaymentChanels = context.Set<MemberShipTypesWithPaymentChanel>().Where(i => i.MemberShipTypeSeqID == memberShipTypeWithCustomer.MemberShipTypeSeqID).FirstOrDefault();

        //            string CustemerRefCode = memberShipTypeWithCustomersPaymentChanel.ReferenceCode;
        //            string PlanCustemerRefCode = memberShipTypesWithPaymentChanels.ReferenceCode;
        //            string ErrorCode = "";
        //            List<Iyzipay.Model.V2.Subscription.SubscriptionOrder> iySubscriptionOrderList = new List<Iyzipay.Model.V2.Subscription.SubscriptionOrder>();
        //            try { iySubscriptionOrderList = IyzipayEntegration.SubscriptionReturnOrder(CustemerRefCode).Data.SubscriptionOrders; } catch { }
        //            if (iySubscriptionOrderList != null && iySubscriptionOrderList.Count > 0)
        //            {
        //                foreach (var item in iySubscriptionOrderList)
        //                {
        //                    SubscriptionOrder newItem = new SubscriptionOrder();
        //                    newItem.CurrencyCode = item.CurrencyCode;
        //                    newItem.EndPeriod = Utility.UnixTimeStampToDateTime(item.EndPeriod).ToString();

        //                    newItem.OrderStatus = GetCustomerStatus(item.OrderStatus);
        //                    newItem.Price = Utility.StringToMoney(item.Price);
        //                    newItem.StartPeriod = Utility.UnixTimeStampToDateTime(item.StartPeriod).ToString(); ;
        //                    SubscriptionOrderList.Add(newItem);
        //                }
        //            }


        //            //if (SubscriberResult)// abonelik iptal edilirse müşterinin Customer with MemberShip Tablosunda activliği iptal edilir.
        //            //{
        //            //    memberShipTypeWithCustomerRepository.MemberShipTypeWithCustomersDelete(id);
        //            //    return true;
        //            //}
        //            //else
        //            //{

        //            //    ErrorMessage = ErrorCode;
        //            //    return false;
        //            //}
        //        }
        //        else
        //        {

        //        }
        //    }
        //    else
        //    {
        //        memberShipTypeWithCustomerRepository.MemberShipTypeWithCustomersDelete(id);// abonelik iptal edilirse müşterinin Customer with MemberShip Tablosunda activliği iptal edilir.
        //        //return true;
        //    }
        //    return SubscriptionOrderList;
        //}

        //public void UpdateCustomerApi(UserUpdate customer)
        //{
        //    var value = dbset.Where(W => W.UserID == customer.customerDefNo).ToList();
        //    foreach (var item in value)
        //    {
        //        item.customer_def_name = customer.name;
        //        item.customer_def_surname = customer.surname;
        //        TUpdate(item);
        //    }
        //}


        //public List<GetCustomersModel> GetCustomers()
        //{
        //    return dbset.Join(context.Set<MemberShipTypeWithCustomer>(), Customers => Customers.UserID, MemberShipTypeWithCustomers => MemberShipTypeWithCustomers.Id, (C, M) => new
        //    {
        //        Customers = C,
        //        MemberShipTypeWithCustomers = M
        //    }).Select(I => new GetCustomersModel
        //    {
        //        customer_def_name = I.Customers.customer_def_name,
        //        customer_def_surname = I.Customers.customer_def_surname,
        //        email = I.Customers.email,
        //        customer_def_Description = I.Customers.customer_def_Description,
        //        IsActive = I.MemberShipTypeWithCustomers.IsActive,
        //        customer_def_seq = I.Customers.customer_def_seq

        //    }).OrderByDescending(I => I.customer_def_seq).ToList();
        ////}

    }
}
