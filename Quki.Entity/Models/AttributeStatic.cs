using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Quki.Entity.Base;

namespace Quki.Entity.Models
{
    public class AttributeStatic : EntityBase
    {
        [Key]
        public int AttributeStaticSeqID { get; set; }
        public int? AttributeStaticID { get; set; }
        public int LanguageID { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }
        public int? Type { get; set; }
        public int? ParentID { get; set; }
        public string ImageThumpPath { get; set; }
        public bool Status { get; set; }

        public DateTime? UpdatedOn { get; set; }
        [MaxLength(450)]
        public string UpdatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        [MaxLength(450)]
        public string CreatedBy { get; set; }
        [Required(ErrorMessage = "Sıralama alanı gereklidir.")]
        [Range(1, int.MaxValue, ErrorMessage = "Sıralama 1 den büyük olmalıdır.")]
        public Int16 DisplayOrderNumber { get; set; }
 
        public List<AttributeStaticValue> AttributeStaticValue { get; set; }

    }
}
