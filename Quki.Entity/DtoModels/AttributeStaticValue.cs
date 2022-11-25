using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Base;
using Quki.Entity.Models;

namespace Quki.Entity.DtoModels
{
    public class AttributeStaticValueModel : DtoBase
    {
        [Key]
        public int AttributeStaticValueSeqID { get; set; }
        public int? AttributeStaticValueID { get; set; }
        public int AttributeStaticSeqID { get; set; }
        public int LanguageID { get; set; }
        [MaxLength(100)]
        public string ValueName { get; set; }
        //public string value { get; set; }
        public string Remark { get; set; }
        public string ShowComment { get; set; }
        public string ImageThumpPath { get; set; }
        public bool IsDynamic { get; set; }

        public Int16 ValueTypeSeqID { get; set; }
        public int? PriceNumber { get; set; }
        public int? GroupNumber { get; set; }
        public Int16 DisplayOrderNumber { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        public virtual AttributeStatic AttributeStatic { get; set; }
        public List<ProductWithAttributeStaticValue> ProductWithAttributeStaticValues { get; set; }
    }
}
