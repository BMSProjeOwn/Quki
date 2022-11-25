using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

using Microsoft.AspNetCore.StaticFiles;
using Quki.Dal.Concrete.Entityframework.Repostories;
using Quki.Entity.DtoModels.ApiModels;
using Quki.Entity.ViewModel;
using Quki.Entity.Models;

using Quki.WebApi.Base;
using Quki.Interface;
using Quki.Common;

namespace Quki.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ApiBaseController<IProductService, Products, Product>
    {
        private readonly IProductService productService;
        private readonly IProducersService producersService;
        private readonly IErrorLogService errorLogService;
        private readonly ICustomerFovoriListService customerFovoriListService;
        private readonly ICustomerRatingsService customerRatingsService;

        public ProductController(ICustomerRatingsService customerRatingsService, ICustomerFovoriListService customerFovoriListService, IProducersService producersService, IProductService productService, IErrorLogService errorLogService) : base(productService)
        {
            this.productService = productService;
            this.errorLogService = errorLogService;
            this.producersService = producersService;
            this.customerFovoriListService = customerFovoriListService;
            this.customerRatingsService = customerRatingsService;
        }
        [HttpPost]
        public ProductsModel GetAllProductsApi([FromBody] JsonElement JObject)
        {

            errorLogService.ErrorLogAdd("Product/GetAllProductsApi  " + JObject.ToString());
            Request languages = Functions.ToObject<Request>(JObject);
            int? languageID = languages.languageId;

            return productService.getProducts();
        }

        [HttpPost]
        public ApiProductWithCategoryModel getProductWithCategoryApi([FromBody] JsonElement JObject)
        {
            errorLogService.ErrorLogAdd("Product/getProductWithCategoryApi  " + JObject.ToString());
            Request languages = Functions.ToObject<Request>(JObject);
            int? languageID = languages.languageId;

            ApiProductWithCategoryModel model = new ApiProductWithCategoryModel();
            model.Result = true;
            model.ResultCode = 1;
            model.ResultMessage = "İşlem Başarılı";
            model.Categories = productService.getProductWithCategory();
            return model;
        }

        [HttpPost]
        public GetProductByIDModel GetProductByIDApi([FromBody] JsonElement JObject)
        {
            errorLogService.ErrorLogAdd("Product/GetProductByIDApi  " + JObject.ToString());
            GetProductByIDModel response = new GetProductByIDModel();
            Request languages = Functions.ToObject<Request>(JObject);
            int? languageID = languages.languageId;

            AccountModel appUserModel = Functions.ToObject<AccountModel>(JObject);
            string customer_def_no = languages.customerDefNo;

            Product products = Functions.ToObject<Product>(JObject);
            Product rProduct = productService.GetProductByIDSP(products.productId, customer_def_no, languageID);
            response.product = rProduct;
            response.Result = true;
            response.ResultCode = 1;
            response.ResultMessage = "İşlem Başarılı";
            return response;
        }

        [HttpGet]
        public async Task<ActionResult> DownloadFileApi(string id)
        {
            //Products products = Functions.ToObject<Products>(JObject);
            //string filePath = Environment.CurrentDirectory + @"\"+"wwwroot\\"+ products.ImagePath;

            string filePath = Environment.CurrentDirectory + @"\" + "wwwroot\\" + id;
            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(filePath, out var contentType))
            {
                contentType = "application/octet-stream";
            }

            var bytes = await System.IO.File.ReadAllBytesAsync(filePath);
            return File(bytes, contentType, Path.GetFileName(filePath));
        }

        [HttpPost]
        public ProductsSearchApi SeachProductApi([FromBody] JsonElement JObject)
        {
            errorLogService.ErrorLogAdd("Product/SeachProductApi  " + JObject.ToString());
            SearchProductRequest req = Functions.ToObject<SearchProductRequest>(JObject);
            int languageID = req.languageId;

            string customer_def_no = req.customerDefNo;


            return productService.SeachProductSP(req.productName, customer_def_no, languageID);
        }

        [HttpPost]
        public ViewValue GetGroupAllProductsApi([FromBody] JsonElement JObject)
        {
            errorLogService.ErrorLogAdd("Product/GetGroupAllProductsApi  " + JObject.ToString());
            GetGroupAllProductsApiRequest req = Functions.ToObject<GetGroupAllProductsApiRequest>(JObject);
            SearchProductRequest req1 = Functions.ToObject<SearchProductRequest>(JObject);
            return productService.GetGroupAllProductsApi(req.GroupID, req1.customerDefNo, 999);
        }


        [HttpPost]
        public ProductListResource ProductByGroupApi([FromBody] JsonElement JObject)
        {
            errorLogService.ErrorLogAdd("Product/ProductByGroupApi  " + JObject.ToString());
            ProductListResourceRequest req = Functions.ToObject<ProductListResourceRequest>(JObject);
            ProductListResource res = new ProductListResource();
            ProductGroup group = new ProductGroup();
            group = productService.GetHomeProductsApi(req.id, req.customerDefNo, 999, req.languageId);
            res.productList = group.productList;
            res.result = true;
            res.resultCode = 1;
            res.resultMessage = "İşlem Başarılı.";
            return res;
        }



        [HttpPost]
        public ProductListResource ProductByPerformerApi([FromBody] JsonElement JObject)
        {
            errorLogService.ErrorLogAdd("Product/ProductByPerformerApi  " + JObject.ToString());
            ProductListResourceRequest req = Functions.ToObject<ProductListResourceRequest>(JObject);
            ProductListResource res = new ProductListResource();
            res.productList = producersService.GetProductByPerformerID(req.id, req.customerDefNo, 999, req.languageId);
            res.result = true;
            res.resultCode = 1;
            res.resultMessage = "İşlem Başarılı.";
            return res;
        }




        //favorite
        [HttpPost]
        public Response AddFavorite([FromBody] JsonElement JObject)
        {
            errorLogService.ErrorLogAdd("Product/AddFavorite  " + JObject.ToString());
            CustomerFovoriListApiModel model = Functions.ToObject<CustomerFovoriListApiModel>(JObject);
            model.GroupID = 1;
            model.FavoritesListDefSeqID = 1;
            customerFovoriListService.AddCustomerFavoriList(model);
            Response model1 = new Response();
            //model1.CustomerFavoritesList = CustomerFovoriList.getCustomerFovoriListApi(model.customerDefNo);
            model1.Result = true;
            model1.ResultCode = 1;
            model1.ResultMessage = "İşlem Başarılı";
            return model1;
        }

        [HttpPost]
        public Response DeleteFavorite([FromBody] JsonElement JObject)
        {
            errorLogService.ErrorLogAdd("Product/DeleteFavorite  " + JObject.ToString());
            CustomerFovoriListApiModel model = Functions.ToObject<CustomerFovoriListApiModel>(JObject);
            model.GroupID = 1;
            model.FavoritesListDefSeqID = 1;
            customerFovoriListService.DeleteCustomerFavoriList(model);
            Response model1 = new Response();
            //model1.CustomerFavoritesList = CustomerFovoriList.getCustomerFovoriListApi(model.customerDefNo);
            model1.Result = true;
            model1.ResultCode = 1;
            model1.ResultMessage = "İşlem Başarılı";
            return model1;
        }

        [HttpPost]
        public Response DeleteListOfCustomerFavoriListApi([FromBody] JsonElement JObject)
        {
            errorLogService.ErrorLogAdd("Product/DeleteListOfCustomerFavoriListApi  " + JObject.ToString());
            SearchProductRequest req = Functions.ToObject<SearchProductRequest>(JObject);
            CustomerFavoritesList model = Functions.ToObject<CustomerFavoritesList>(JObject);
            customerFovoriListService.DeleteListOfCustomerFavoriList(req.customerDefNo);
            Response model1 = new Response();
            model1.Result = true;
            model1.ResultCode = 1;
            model1.ResultMessage = "İşlem Başarılı";
            return model1;
        }

        [HttpPost]
        public ProductListResource Favorites([FromBody] JsonElement JObject)
        {
            errorLogService.ErrorLogAdd("Product/Favorites  " + JObject.ToString());
            ProductListResourceRequest model = Functions.ToObject<ProductListResourceRequest>(JObject);
            ProductListResource model1 = new ProductListResource();
            model1.productList = customerFovoriListService.GetCustomerFavoriListFromSP(model.customerDefNo, model.languageId);
            model1.result = true;
            model1.resultCode = 1;
            model1.resultMessage = "İşlem Başarılı";
            return model1;
        }
        //favorite


        [HttpPost]
        public Response ProductAddPointApi([FromBody] JsonElement JObject)
        {
            errorLogService.ErrorLogAdd("Product/ProductAddPointApi  " + JObject.ToString());
            ProductAddPointRequest model = Functions.ToObject<ProductAddPointRequest>(JObject);
            Response model1 = new Response();
            customerRatingsService.UpdateORAddCustomerRatingsApi(model.customerDefNo, model.productId, model.point.ToString());
            model1.Result = true;
            model1.ResultCode = 1;
            model1.ResultMessage = "İşlem Başarılı";
            return model1;
        }

        [HttpPost]
        public ProductsSearchApi SuggestedProductsApi([FromBody] JsonElement JObject)
        {
            errorLogService.ErrorLogAdd("Product/SuggestedProductsApi  " + JObject.ToString());
            SearchProductRequest req = Functions.ToObject<SearchProductRequest>(JObject);

            string customer_def_no = req.customerDefNo;
            ProductsSearchApi model1 = new ProductsSearchApi();
            model1.Products = productService.GetHomeProductDetailForMobile(10, customer_def_no, req.languageId, 0);
            model1.Result = true;
            model1.ResultCode = 1;
            model1.ResultMessage = "İşlem Başarılı";
            return model1;
        }
    }


}
