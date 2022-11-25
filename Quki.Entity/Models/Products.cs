using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Base;

namespace Quki.Entity.Models
{
    public class Products : EntityBase
    {
        [Key]
        public int ProductSeqID { get; set; }
        public int ProductID { get; set; }
        public int LanguageID { get; set; }
        public int TaxRateSeqId { get; set; }
        [MaxLength(150)]
        public string ProductName { get; set; }
        [MaxLength(150)]
        public string SecondName { get; set; }
        public string Description { get; set; }
        [MaxLength(50)]
        public string BaseSKU { get; set; }
        [MaxLength(50)]
        public string BackOfficeCode { get; set; }
        [MaxLength(50)]
        public string QRCode { get; set; }
        public decimal RetailPrice { get; set; }
        public decimal PurchasePrice { get; set; }

        [MaxLength(250)]
        public string ImagePath { get; set; }
        [MaxLength(250)]
        public string ImageThumbPath { get; set; }
        public string ShowComment { get; set; }
        public string AdminComment { get; set; }
        public bool? PromoteFront { get; set; }
        public bool? PromoteDeptarment { get; set; }

        public int? UnitSeqId { get; set; }
        public bool? IsDeleted { get; set; }
        public int? ProductTemplateID { get; set; }
        public bool? IsFeaturedProduct { get; set; }
        public int? ProductTypeSeqID { get; set; }
        public bool AllowCustomerReviews { get; set; }
        public bool AllowCustomerRating { get; set; }
        public bool ShowOnHomePage { get; set; }
        public bool? AllowNegativeInventories { get; set; }
        [MaxLength(100)]
        public string ShippingEstimateDate { get; set; }
        public int? LevelGroup { get; set; }
        public int? SortOrder { get; set; }
        public int? BaseCurrencySeqID { get; set; }
        [MaxLength(500)]
        public string ProductSEOData { get; set; }

        public string ProductSEOMetaDescription { get; set; }

        public bool Status { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public DateTime? ReleaseDateLast { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        public Int16 DisplayOrderNumber { get; set; }
        public List<ProductWithCategory> ProductWithCategories { get; set; }
        public List<ProductWithAttributeStaticValue> ProductWithAttributeStaticValues { get; set; }
        public List<ProductImage> ProductImages { get; set; }
    }
}

