using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Base;

namespace Quki.Entity.DtoModels.ApiModels
{
    public class CustomerTrackingTypeModelApi
    {
    }

    public class GetCustomerTrackingTypeResponse : Response
    {
        public Product product { get; set; }
    }

    public class AddCustomerTrackingTypeRequest : DtoBase
    {
        public int TrackingTypeSeqID { get; set; }
        public string customerDefNo { get; set; }
        public int ProductSeqID { get; set; }
        public int Second { get; set; }
        public int counrtyId { get; set; }
    }


    public class CustomerStartListenModel
    {
        public int languageId { get; set; }
        public string customerDefNo { get; set; }
        public int ProductSeqID { get; set; }
        public int Second { get; set; }
        public int counrtyId { get; set; }
        public int TrackingTypeSeqID { get; set; }
    }
}
