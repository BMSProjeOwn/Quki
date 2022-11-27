using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Quki.Common;
using Quki.Dal.Concrete.Entityframework.Repostories;
using Quki.Entity.DtoModels;
using Quki.Entity.DtoModels.ApiModels;
using Quki.Entity.Models;
using Quki.Interface;
using Quki.WebApi.Base;

namespace Quki.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerTrackingTypeController : ApiBaseController<ICustomerTrackingTypeService, CustomerTrackingType, AddCustomerTrackingTypeRequest>
    {
        private readonly ICustomerTrackingTypeService service;
        private readonly IErrorLogService errorLogService;
        private readonly IMemberShipTypeWithPropertiesService memberShipTypeWithPropertiesService;
        private readonly IProductService productsService;
        public CustomerTrackingTypeController(ICustomerTrackingTypeService service, IErrorLogService errorLogService, IMemberShipTypeWithPropertiesService memberShipTypeWithPropertiesService, IProductService productsService) : base(service)
        {
            this.service = service;
            this.errorLogService = errorLogService;
            this.memberShipTypeWithPropertiesService = memberShipTypeWithPropertiesService;
            this.productsService = productsService;
        }
        
        [HttpPost]
        public GetCustomerTrackingTypeResponse GetCustomerTrackingTypeApi([FromBody] JsonElement JObject)
        {
            errorLogService.ErrorLogAdd("CustomerTrackingType/GetCustomerTrackingTypeApi  " + JObject.ToString());
            Request languages = Functions.ToObject<Request>(JObject);
            int languageID = languages.languageId;

            AccountModel appUserModel = Functions.ToObject<AccountModel>(JObject);

            string customer_def_no = languages.customerDefNo;

            GetCustomerTrackingTypeResponse res = new GetCustomerTrackingTypeResponse();
            try
            {
                res.Result = true;
                res.ResultCode = 1;
                res.ResultMessage = "İşlem Başarılı.";
                res.product = service.GetCustomerTrackingTypeSP(1, customer_def_no, languageID).FirstOrDefault();
                if (res.product == null)
                {
                    //res.product = customerTrackingTypeRepostories.GetCustomerTrackingTypeApi(1, "").FirstOrDefault();
                    if (res.product == null)
                    {
                        res.product = productsService.GetHomeProductDetailForMobile(1, customer_def_no, languageID, 0).FirstOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return res;
        }
        [HttpPost]
        public Response AddCustomerTrackingTypeApi([FromBody] JsonElement JObject)
        {
            errorLogService.ErrorLogAdd("CustomerTrackingType/AddCustomerTrackingTypeApi  " + JObject.ToString());
            AddCustomerTrackingTypeRequest req = Functions.ToObject<AddCustomerTrackingTypeRequest>(JObject);
            req.TrackingTypeSeqID = 100;

            service.AddCustomerTrackingTypeApi(req);
            //customerTrackingTypeRepostories.UpdateListenTimeApi(req);
            Response res = new Response();
            res.Result = true;
            res.ResultCode = 1;
            res.ResultMessage = "İşlem Başarılı.";
            return res;
        }

        [HttpPost]
        public Response AddCustomerListenTimeApi([FromBody] JsonElement JObject)
        {
            errorLogService.ErrorLogAdd("CustomerTrackingType/AddCustomerListenTimeApi  " + JObject.ToString());
            AddCustomerTrackingTypeRequest req = Functions.ToObject<AddCustomerTrackingTypeRequest>(JObject);
            req.TrackingTypeSeqID = 101;

            service.AddCustomerTrackingTypeApi(req);
            service.UpdateListenTimeApi(req);
            Response res = new Response();
            res.Result = true;
            res.ResultCode = 1;
            res.ResultMessage = "İşlem Başarılı.";
            return res;
        }

        [HttpPost]
        public Response AddCustomerProductClickApi([FromBody] JsonElement JObject)
        {
            errorLogService.ErrorLogAdd("CustomerTrackingType/AddCustomerProductClickApi  " + JObject.ToString());
            AddCustomerTrackingTypeRequest req = Functions.ToObject<AddCustomerTrackingTypeRequest>(JObject);
            req.TrackingTypeSeqID = 102;
            req.Second = 0;
            service.AddCustomerTrackingTypeApi(req);
            Response res = new Response();
            res.Result = true;
            res.ResultCode = 1;
            res.ResultMessage = "İşlem Başarılı.";
            return res;
        }



        [HttpPost]
        public Response CustomerStopListen([FromBody] JsonElement JObject)
        {
            errorLogService.ErrorLogAdd("CustomerTrackingType/CustomerStopListen  " + JObject.ToString());
            AddCustomerTrackingTypeRequest req = Functions.ToObject<AddCustomerTrackingTypeRequest>(JObject);
            req.TrackingTypeSeqID = 100;

            service.AddCustomerTrackingTypeApi(req);
            service.UpdateListenTimeApi(req);
            Response res = new Response();
            res.Result = true;
            res.ResultCode = 1;
            res.ResultMessage = "İşlem Başarılı.";
            return res;
        }


        [HttpPost]
        public Response CustomerStartListen([FromBody] JsonElement JObject)
        {
            errorLogService.ErrorLogAdd("CustomerTrackingType/CustomerStartListen  " + JObject.ToString());
            CustomerStartListenModel req = Functions.ToObject<CustomerStartListenModel>(JObject);
            errorLogService.ErrorLogAdd("Header1: device-id:" + Request.Headers["device-id"].ToString()
                    + " device-type: " + Request.Headers["device-type"].ToString()
                     + " app-version: " + Request.Headers["app-version"].ToString());
            var membershipStatus = memberShipTypeWithPropertiesService.ListenPermissionControlSP(req.customerDefNo, req.languageId);
            Response res = new Response();

            if (membershipStatus.Result)
            {
                AddCustomerTrackingTypeRequest addCustomerTrackingTypeRequest = new AddCustomerTrackingTypeRequest();
                addCustomerTrackingTypeRequest.TrackingTypeSeqID = 101;
                addCustomerTrackingTypeRequest.customerDefNo = req.customerDefNo;
                addCustomerTrackingTypeRequest.ProductSeqID = req.ProductSeqID;
                addCustomerTrackingTypeRequest.Second = req.Second;
                //customerTrackingTypeRepostories.UpdateListenTimeApi(addCustomerTrackingTypeRequest);
                service.AddCustomerTrackingTypeApi(addCustomerTrackingTypeRequest);
                res.Result = true;
                res.ResultCode = 1;
                res.ResultMessage = "İşlem Başarılı.";
            }
            else
            {
                res.Result = false;
                res.ResultCode = -1;
                res.ResultMessage = membershipStatus.ResultMessage;
            }
            return res;
        }
    }
}
