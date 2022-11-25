using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Base;
using Quki.Entity.Models;

namespace Quki.Entity.DtoModels
{
    public class ProductWithAttributeStaticValueModel:DtoBase
    {
        [Key]
        public int ProductWithAttributeStaticValueSeqID { get; set; }
        public int ProductSeqID { get; set; }
        public Products Products { get; set; }
        public int AttributeStaticValueSeqID { get; set; }
        public AttributeStaticValue AttributeStaticValue { get; set; }
        public bool? ShowProductTable { get; set; }
        public bool? AllowFiltring { get; set; }
        public bool? IsAskUser { get; set; }
        public string UserContent { get; set; }
        public Int16 DisplayOrderNumber { get; set; }
        public decimal? ProductAttributePrice { get; set; }
        public string ProductRemark { get; set; }
        public int? Type { get; set; }
        public string Value { get; set; }


    }
}
