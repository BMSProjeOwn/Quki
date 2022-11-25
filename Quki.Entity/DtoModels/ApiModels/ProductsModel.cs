using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Models;

namespace Quki.Entity.DtoModels.ApiModels
{
    public class ProductsModel : Response
    {
        public List<Products> Products { get; set; }
    }

    public class ApiProductWithCategoryModel : Response
    {
        public List<ProductWithCategoryModel> Categories { get; set; }
    }

    public class ProductsSearchApi : Response
    {
        public List<Product> Products { get; set; }
    }

    public class GetGroupAllProductsApiRequest
    {
        public int languageId { get; set; }
        public int GroupID { get; set; }
        public string customer_def_no { get; set; }
    }


    public class ProductListResourceRequest
    {
        public int languageId { get; set; }
        public string customerDefNo { get; set; }
        public int id { get; set; }
    }

    public class ProductListResource
    {
        public List<Product> productList { get; set; }
        public bool result { get; set; }
        public int resultCode { get; set; }
        public string resultMessage { get; set; }
    }

    public class SearchProductRequest
    {
        public int languageId { get; set; }
        public string customerDefNo { get; set; }
        public string productName { get; set; }
    }

    public class ProductAddPointRequest
    {
        public string customerDefNo { get; set; }
        public int languageId { get; set; }
        public int productId { get; set; }
        public int point { get; set; }
    }
}
