using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Quki.Common;
using Quki.Dal.Concrete.Entityframework.Repostories;
using Quki.Entity.DtoModels.ApiModels;
using Quki.Entity.Models;
using Quki.Entity.ViewModel;
using Quki.Interface;
using Quki.WebApi.Base;

namespace Quki.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerFavoriListController : ApiBaseController<ICustomerFovoriListService, CustomerFavoritesList, CustomerFovoriListApiModel>
    {
        private readonly ICustomerFovoriListService service;
        private readonly IErrorLogService errorLogService;
        public CustomerFavoriListController(ICustomerFovoriListService service, IErrorLogService errorLogService) : base(service)
        {
            this.service = service;
            this.errorLogService = errorLogService;
        }
        [HttpPost("AddCustomerFavoriListApi")]
        public Response AddCustomerFavoriListApi([FromBody] JsonElement JObject)
        {
            errorLogService.ErrorLogAdd("CustomerFavoriList/AddCustomerFavoriListApi  " + JObject.ToString());
            CustomerFovoriListApiModel model = Functions.ToObject<CustomerFovoriListApiModel>(JObject);
            model.GroupID = 1;
            model.FavoritesListDefSeqID = 1;
            service.AddCustomerFavoriList(model);
            Response model1 = new Response();
            //model1.CustomerFavoritesList = CustomerFovoriList.getCustomerFovoriListApi(model.customerDefNo);
            model1.Result = true;
            model1.ResultCode = 1;
            model1.ResultMessage = "İşlem Başarılı";
            return model1;
        }

        [HttpPost("DeleteCustomerFavoriListApi")]
        public Response DeleteCustomerFavoriListApi([FromBody] JsonElement JObject)
        {
            errorLogService.ErrorLogAdd("CustomerFavoriList/DeleteCustomerFavoriListApi  " + JObject.ToString());
            CustomerFovoriListApiModel model = Functions.ToObject<CustomerFovoriListApiModel>(JObject);
            model.GroupID = 1;
            model.FavoritesListDefSeqID = 1;
            service.DeleteCustomerFavoriList(model);
            Response model1 = new Response();
            //model1.CustomerFavoritesList = CustomerFovoriList.getCustomerFovoriListApi(model.customerDefNo);
            model1.Result = true;
            model1.ResultCode = 1;
            model1.ResultMessage = "İşlem Başarılı";
            return model1;
        }

        [HttpPost("DeleteListOfCustomerFavoriListApi")]
        public Response DeleteListOfCustomerFavoriListApi([FromBody] JsonElement JObject)
        {
            errorLogService.ErrorLogAdd("CustomerFavoriList/DeleteListOfCustomerFavoriListApi  " + JObject.ToString());
            Request languages = Functions.ToObject<Request>(JObject);
            service.DeleteListOfCustomerFavoriList(languages.customerDefNo);
            Response model1 = new Response();
            model1.Result = true;
            model1.ResultCode = 1;
            model1.ResultMessage = "İşlem Başarılı";
            return model1;
        }

        [HttpPost("GetCustomerFovoriListApi")]
        public CustomerFavoritesListApiModel GetCustomerFovoriListApi([FromBody] JsonElement JObject)
        {
            errorLogService.ErrorLogAdd("CustomerFavoriList/GetCustomerFovoriListApi  " + JObject.ToString());
            Request languages = Functions.ToObject<Request>(JObject);
            CustomerFavoritesListApiModel model1 = new CustomerFavoritesListApiModel();
            model1.CustomerFavoritesList = service.GetCustomerFavoriListFromSP(languages.customerDefNo, languages.languageId);
            model1.Result = true;
            model1.ResultCode = 1;
            model1.ResultMessage = "İşlem Başarılı";
            return model1;
        }
    }
}
