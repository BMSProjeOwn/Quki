using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Entity.DtoModels.ApiModels
{
    public class ProducersApiModel : Response
    {
        public List<ProducersModel> ProducersList { get; set; }
    }

    public class ProducersApiDetailModel : Response
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public List<ProductDetailForMobile> ProductDetailList { get; set; }
    }
}
