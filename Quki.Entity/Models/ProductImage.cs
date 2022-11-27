using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Quki.Entity.Base;

namespace Quki.Entity.Models
{
    public class ProductImage:EntityBase
    {
        [Key]
        public int ProductImageSeqID { get; set; }
        public int ProductSeqID { get; set; }
        public Products Products { get; set; }
        public string ImagePath { get; set; }
        public string ImageThumbPath { get; set; }
        public string Remark { get; set; }
        public Int16 DisplayOrderNumber { get; set; }
        [MaxLength(200)]
        public string ImageName { get; set; }
        public int? MediaTypeId { get; set; }
        [MaxLength(200)]
        public string GroupValue { get; set; }
        public int? GroupId { get; set; }
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
    }
}
