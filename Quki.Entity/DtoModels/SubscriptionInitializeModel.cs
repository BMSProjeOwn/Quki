using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Entity.DtoModels
{
    public class SubscriptionInitializeForGiftModel
    {
        public SubscriptionInitializeForGiftModel() {
            Customer = new CheckoutCustomer();
            PaymentCard = new SubscriptionCardInfo();
        }
        public string UserID { get; set; }
        public string PricingPlanReferenceCode { get; set; }
        public string PricingPlanName { get; set; }
        public string SubscriptionInitialStatus { get; set; }
        public string Period { get; set; }
        public decimal Price { get; set; }
        public string Currncy { get; set; }
        public int campaignDefId { get; set; }
        public CheckoutCustomer Customer { get; set; }
        public SubscriptionCardInfo PaymentCard { get; set; }
    }
    



}
