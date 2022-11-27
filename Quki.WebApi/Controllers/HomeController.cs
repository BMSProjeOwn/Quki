using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Quki.Common;
using Quki.Dal.Concrete.Entityframework.Repostories;
using Quki.Entity.DtoModels;
using Quki.Entity.DtoModels.ApiModels;
using Quki.Entity.Models;
using Quki.Entity.Parameters;
using Quki.Interface;
using Quki.WebApi.Base;

namespace Quki.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ApiBaseController<ICategoryService, Category, CategoryAddModel>
    {
        private readonly ICategoryService service;
        private readonly IErrorLogService errorLogService;
        private readonly IProducersService producersService;
        private readonly IProductService productsService;
        public HomeController(ICategoryService service, IErrorLogService errorLogService, IProducersService producersService, IProductService productsService) : base(service)
        {
            this.service = service;
            this.errorLogService = errorLogService;
            this.producersService = producersService;
            this.productsService = productsService;
        }
        [HttpPost]
        public HomeResource HomeResourceApi([FromBody] JsonElement JObject)
        {
            errorLogService.ErrorLogAdd("Home/HomeResourceApi  " + JObject.ToString());
            HomeResourceRequest req =Functions.ToObject<HomeResourceRequest>(JObject);
            string customer_def_no = req.customerDefNo;

            HomeResource res = new HomeResource();

            res.newest = productsService.GetHomeProductsApi(ApiMainPageGroupID.TheNewests, customer_def_no, 5, req.languageId);
            res.topRated = productsService.GetHomeProductsApi(ApiMainPageGroupID.TopRateProducts, customer_def_no, 5, req.languageId);
            if (customer_def_no != "" && customer_def_no != null)
                res.keepListening = productsService.GetHomeProductsApi(ApiMainPageGroupID.KeepListening, customer_def_no, 5, req.languageId);
            res.popular = productsService.GetHomeProductsApi(ApiMainPageGroupID.PopularAudioTheaterProducts, customer_def_no, 5, req.languageId);
            res.byAge = productsService.GetHomeProductsApi(ApiMainPageGroupID.ByAgeRrangeProducts, customer_def_no, 5, req.languageId);
            res.performers = producersService.GetHomeProducerGroupApi(ApiMainPageGroupID.Producers, customer_def_no, 5, req.languageId);



            res.result = true;
            res.resultCode = 1;
            res.resultMessage = "İşlem Başarılı.";
            return res;
        }

    }
}
