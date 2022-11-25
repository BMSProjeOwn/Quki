using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quki.Entity.Base;

namespace Quki.Entity.DtoModels.ApiModels
{
    public class MembershipTypePricePlanApiModel
    {
        public int pricePlaneId { get; set; }
        public int memberShipTypeId { get; set; }
        public string pricePlaneName { get; set; }
        public decimal price { get; set; }
        public string priceText { get; set; }
        public int autoRenewalCount { get; set; }
        public int PaymentPeriod { get; set; }
        public string paymentPeriodName { get; set; }
        public string pricePlaneReferansCode { get; set; }
        public int freeDay { get; set; }
        public string currencyName { get; set; }
        public string CurrencyBaseSymbol { get; set; }
        public DateTime startDate { get; set; }
        public DateTime? endDate { get; set; }
    }
}
