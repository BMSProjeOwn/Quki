using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Entity.DtoModels
{
    public class SubscriptionInitializeModel
    {
        public SubscriptionInitializeModel() {
            Customer = new CheckoutCustomer();
            PaymentCard = new SubscriptionCardInfo();
        }
        public string UserID { get; set; }
        public string PricingPlanReferenceCode { get; set; }
        public string SubscriptionInitialStatus { get; set; }
        public string Period { get; set; }
        public decimal Price { get; set; }
        public string Currncy { get; set; }
        public CheckoutCustomer Customer { get; set; }
        public SubscriptionCardInfo PaymentCard { get; set; }
    }
    public class CheckoutCustomer
    {
        public CheckoutCustomer()
        {
            BillingAddress = new AddressModel();
            ShippingAddress = new AddressModel();
        }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string GsmNumber { get; set; }
        public string IdentityNumber { get; set; }
        public AddressModel BillingAddress { get; set; }
        public AddressModel ShippingAddress { get; set; }
    }



}
