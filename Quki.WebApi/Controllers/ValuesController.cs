using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
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
    public class ValuesController : ApiBaseController<IValueTypesService, ValueTypes, ValueTypesModel>
    {
        private readonly IProductService productService;
        private readonly IValueTypesService valueTypesService;
        private readonly IProducerTypeService producersService;
        private readonly IErrorLogService errorLogService;
        public ValuesController(IProductService productService,IValueTypesService valueTypesService, IProducerTypeService producersService, IErrorLogService errorLogService) : base(valueTypesService)
        {
            this.productService = productService;
            this.errorLogService = errorLogService;
            this.producersService = producersService;
            this.valueTypesService = valueTypesService;
        }
        [HttpPost]
        public MainMenuValues GetMainMenuValuesApi([FromBody] JsonElement JObject)
        {
            errorLogService.ErrorLogAdd("Values/GetMainMenuValuesApi  " + JObject.ToString());

            Request languages = Functions.ToObject<Request>(JObject);
            int? languageID = languages.languageId;

            AccountModel appUserModel = Functions.ToObject<AccountModel>(JObject);

            string customer_def_no = languages.customerDefNo;

            MainMenuValues values = new MainMenuValues();

            //ViewValue value1 = new ViewValue();
            //value1.GroupID = ApiMainPage.TheNewests;//1;
            //value1.Title = "En Yeniler";
            //value1.TitleImagePhat = ApiParameters.URL + "/AdminImage/ProductImg/Thump48112ff0-d6e7-45cd-8e03-c19423351cc6.jpg";
            ////value1.FliterList = product.getTheNewests(5);
            //value1.Data = product.getTheNewests(5, customer_def_no);
            //values.TheNewests = value1;

            //ViewValue value2 = new ViewValue();
            //value2.GroupID = ApiMainPage.TopRateProducts;//2;
            //value2.Title = "En Beğenilenler";
            //value2.TitleImagePhat = ApiParameters.URL + "/AdminImage/ProductImg/Thump48112ff0-d6e7-45cd-8e03-c19423351cc6.jpg";
            ////value2.FliterList = product.getTopRateProduct(5);
            //value2.Data = product.getTopRateProduct(5, customer_def_no);
            //values.TopRateProducts = value2;

            //ViewValue value6 = new ViewValue();
            //value6.GroupID = ApiMainPage.KeepListening;//3;
            //value6.Title = "Dinlemeye Devam Edin (Üye Olanlar İçin)";
            //value6.TitleImagePhat = ApiParameters.URL + "/AdminImage/ProductImg/Thump48112ff0-d6e7-45cd-8e03-c19423351cc6.jpg";
            ////value6.FliterList = product.getTheNewests(5);
            //value6.Data = product.getTheNewests(5, customer_def_no);
            //if (customer_def_no != "" && customer_def_no != null && value6.Data != null)
            //{
            //    if (value6.Data.Count > 0)
            //        values.KeepListening = value6;
            //}

            //ViewValue value3 = new ViewValue();
            //value3.GroupID = ApiMainPage.PopularAudioTheaterProducts;//4;
            //value3.Title = "Bilindik Sesli Tiyatrolar";
            //value3.TitleImagePhat = ApiParameters.URL + "/AdminImage/ProductImg/Thump48112ff0-d6e7-45cd-8e03-c19423351cc6.jpg";
            ////value3.FliterList = product.getPopularAudioTheaters(5);
            //value3.Data = product.getPopularAudioTheaters(5, customer_def_no);
            //values.PopularAudioTheaterProducts = value3;

            //ViewValue value4 = new ViewValue();
            //value4.GroupID = ApiMainPage.ByAgeRrangeProducts;//5;
            //value4.Title = "Yaş Aralığına Göre";
            //value4.TitleImagePhat = ApiParameters.URL + "/AdminImage/ProductImg/Thump48112ff0-d6e7-45cd-8e03-c19423351cc6.jpg";
            //value4.FliterList = category.GetAllCategoriForApi();
            //value4.Data = product.ByAageRrangeProducts(5, customer_def_no);
            //values.ByAgeRrangeProducts = value4;

            //ViewValue value5 = new ViewValue();
            //value5.GroupID = ApiMainPage.Producers;//6;
            //value5.Title = "Seslendirenler";
            //value5.TitleImagePhat = ApiParameters.URL + "/AdminImage/ProductImg/Thump48112ff0-d6e7-45cd-8e03-c19423351cc6.jpg";
            ////value5.FliterList = producers.getProducersLitMainMenu(5);
            //value5.Data = producers.getProducersLitMainMenu(5, customer_def_no);
            //values.Producers = value5;

            values.TheNewests = productService.GetGroupAllProductsApi(ApiMainPageGroupID.TheNewests, customer_def_no, 5);
            values.TopRateProducts = productService.GetGroupAllProductsApi(ApiMainPageGroupID.TopRateProducts, customer_def_no, 5);
            if (customer_def_no != "" && customer_def_no != null)
                values.KeepListening = productService.GetGroupAllProductsApi(ApiMainPageGroupID.KeepListening, customer_def_no, 5);
            values.PopularAudioTheaterProducts = productService.GetGroupAllProductsApi(ApiMainPageGroupID.PopularAudioTheaterProducts, customer_def_no, 5);
            values.ByAgeRrangeProducts = productService.GetGroupAllProductsApi(ApiMainPageGroupID.ByAgeRrangeProducts, customer_def_no, 5);
            values.Producers = productService.GetGroupAllProductsApi(ApiMainPageGroupID.Producers, customer_def_no, 5);



            values.Result = true;
            values.ResultCode = 1;
            values.ResultMessage = "İşlem Başarılı.";
            return values;
        }
        [NonAction]
        public object ExecuteCommand(string function_name, string function_category, object[] parameters)
        {

            object result = null;
            MethodInfo[] methods = this.GetType().GetMethods();
            MethodInfo CalledMethod = null;

            foreach (MethodInfo method in methods)
            {
                if (method.Name == function_name)
                {
                    CalledMethod = method;
                    break;
                }
            }
            if (CalledMethod != null)
                result = CalledMethod.Invoke(this, parameters);


            return result;

        }
    }
}
