using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Entity.DtoModels
{
    public class SubscriptionCardInfo
    {
        public string CardHolderName { get; set; }
        public string CardNumber1 { get; set; }
        public string CardNumber2 { get; set; }
        public string CardNumber3 { get; set; }
        public string CardNumber4 { get; set; }
        public int? ExpireYear { get; set; }
        public int? ExpireMonth { get; set; }
        public string Cvc { get; set; }
        public bool RegisterConsumerCard { get; set; }
        public string UcsToken { get; set; }
        public string CardToken { get; set; }
        public string ConsumerToken { get; set; }
    }
}
