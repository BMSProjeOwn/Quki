using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Entity.DtoModels
{
    public class ProductAttirubuteStaticValueAtaModel
    {
        public int AttributeStaticSeqID { get; set; }
        public int AttributeStaticValueSeqID { get; set; }
        public string ValueName { get; set; }
        public bool IsDynamic { get; set; }
        public bool isHas { get; set; }
        public string Value { get; set; }
    }
}
