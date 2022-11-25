using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Base;
using Quki.Entity.DtoModels;

namespace Quki.Entity.Models
{
    public class Category:EntityBase
    {
        [Key]
        public int CategorySeqID { get; set; }
        public int? CategoryID { get; set; }
        public int? LanguageID { get; set; }
        public int? ParentCategoriesID { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string ImagePath { get; set; }

        public Int16? DisplayOrderNumber { get; set; }
        [MaxLength(1000)]
        public string Description { get; set; }

        public bool Status { get; set; }
        public DateTime? UpdatedOn { get; set; }
        [MaxLength(450)]
        public string UpdatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        [MaxLength(450)]
        public string CreatedBy { get; set; }
        public int DepartmanSeqID { get; set; }
        public TDepart Depart { get; set; }
        public List<ProductWithCategory> ProductWithCategories { get; set; }
    }
}
