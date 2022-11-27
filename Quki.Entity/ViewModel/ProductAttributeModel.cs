using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Entity.ViewModel
{
    public class ProductAttributeModel
    {
        public int ProductSeqID { get; set; }
        public int AttributeStaticValueSeqID { get; set; }
        public string ValueName { get; set; }
        public string Value { get; set; }
        public string Remark { get; set; }
        public bool isdinamic { get; set; }

        public int DisplayOrderNumber { get; set; }

    }
}
