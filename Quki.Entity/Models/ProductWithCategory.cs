using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Base;

namespace Quki.Entity.Models
{
    public class ProductWithCategory:EntityBase
    {
        [Key]
        public int ProductWithCategorySeqID { get; set; }
        public int ProductSeqID { get; set; }
        public Products Products { get; set; }
        public int CategorySeqID { get; set; }
        public Category Category { get; set; }

    }
}
