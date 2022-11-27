using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Models;

namespace Quki.Entity.ViewModel
{
    public class ProductDetailModel
    {
        public ProductDetailModel()
        {
            VisitorComments = new VisitorCommentsModel();
        }
        public int ProductSeqID { get; set; }

        public string ProductName { get; set; }
        public string SecondName { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public string ThumpImagePath { get; set; }
        public string ProductSEOData { get; set; }

        public string ProductSEOMetaDescription { get; set; }
        public bool AllowCustomerReviews { get; set; }
        public bool AllowCustomerRating { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public List<ProductAttiributeValueList> ProductAttiributeValueList { get; set; }
        public VisitorCommentsModel VisitorComments { get; set; }

        public List<ProductImage> ProductImage { get; set; }


    }

    public class ProductAttiributeValueList
    {
        public int ProductWithAttributeStaticValueSeqID { get; set; }
        public int AttributeStaticValueSeqID { get; set; }
        public int ProductSeqID { get; set; }

        public string ValueName { get; set; }
        public bool IsDynamic { get; set; }
        public string Value { get; set; }
    }
}
