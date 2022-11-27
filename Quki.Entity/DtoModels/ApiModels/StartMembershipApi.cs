using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quki.Entity.DtoModels.ApiModels
{
    public class StartMembershipApi
    {
    }
    public class DeleteMembershipApi
    {
        public string customerDefNo { get; set; }
    }

    public class StartMembershipApiRequest
    {
        public string customerDefNo { get; set; }
        public int pricePlaneId { get; set; }
        public int paymentChaneId { get; set; }
        public string custemerRefCode { get; set; }
        public string purchaseToken { get; set; }
    }
}
