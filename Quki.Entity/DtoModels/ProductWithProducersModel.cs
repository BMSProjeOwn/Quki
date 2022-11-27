using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Base;

namespace Quki.Entity.DtoModels
{
    public class ProductWithProducersModel:DtoBase
    {

        public int ProductWithProducerSeqID { get; set; }
        public int ProductSeqID { get; set; }
        public int ProducerSeqID { get; set; }
        public int ProducerTypeSeqID { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
     
    }
}
