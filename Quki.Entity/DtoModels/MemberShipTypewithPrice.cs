using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Entity.DtoModels
{
    public class MemberShipTypewithPrice
    {
        public int MemberShipTypeSeqID { get; set; }
 
       public string Name { get; set; }
        public decimal Price { get; set; }
        public int PaymentPeriod { get; set; }
        public decimal BaseCurrencyPrice { get; set; }
        public string ImageThumpPath { get; set; }


    }
}
