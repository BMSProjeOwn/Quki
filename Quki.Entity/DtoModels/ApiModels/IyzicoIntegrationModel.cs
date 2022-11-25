using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Entity.DtoModels.ApiModels
{
    public class IyzicoIntegrationModel
    {
    }

    public class PaymentEventModel
    {
        public string orderReferenceCode { get; set; }
        public string customerReferenceCode { get; set; }
        public string subscriptionReferenceCode { get; set; }
        public string iyziReferenceCode { get; set; }
        public string iyziEventType { get; set; }
        public long iyziEventTime { get; set; }
    }
}
