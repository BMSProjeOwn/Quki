﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Entity.ViewModel
{
    public class SubscriptionOrder
    {
        public string ReferenceCode { get; set; }
        public string Price { get; set; }
        public string CurrencyCode { get; set; }
        public string StartPeriod { get; set; }
        public string EndPeriod { get; set; }
        public string OrderStatus { get; set; }
        public List<PaymentAttemptDto> OrderPaymentAttempts { get; set; }
    }

    public class PaymentAttemptDto
    {
        public string ConversationId { get; set; }
        public string CreatedDate { get; set; }
        public string PaymentId { get; set; }
        public string PaymentStatus { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }

}