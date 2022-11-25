using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
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
    public class SubscriptionController : ApiBaseController<IMemberShipTypeService, MemberShipType, MemberShipTypeModel>
    {
        private readonly IMemberShipTypeService service;
        private readonly ICustomerService customerService;
        private readonly IErrorLogService errorLogService;
        private readonly ICancelReasonService cancelReasonService;
        private readonly IMemberShipTypeWithCustomerService memberShipTypeWithCustomerService;
        public SubscriptionController(IErrorLogService errorLogService, ICustomerService customerService
           ,IMemberShipTypeService service, ICancelReasonService cancelReasonService, IMemberShipTypeWithCustomerService memberShipTypeWithCustomerService) : base(service)
        {
            this.customerService = customerService;
            this.errorLogService = errorLogService;
            this.service = service;
            this.cancelReasonService = cancelReasonService;
            this.memberShipTypeWithCustomerService = memberShipTypeWithCustomerService;
        }
        [HttpPost]
        public List<CancelReasonApiModel> getCancelReason([FromBody] JsonElement JObject)
        {
            Request request = Functions.ToObject<Request>(JObject);
            int? languageID = request.languageId;
            return cancelReasonService.GetAllActiveCanselReasonApi(request.languageId);

        }
        [HttpPost]
        public CancelResponse CancelSubscription([FromBody] JsonElement JObject)
        {
            CancelResponse response = new CancelResponse();
            CancelCustomerApiModel cancelCustomerRequest = Functions.ToObject<CancelCustomerApiModel>(JObject);
            int? languageID = cancelCustomerRequest.languageId;
            bool result = false;
            string resultMessage;
            bool resultCancel=true;
            customerService.CancelCustomerApi(cancelCustomerRequest.customerDefNo, out resultCancel,out result, out resultMessage);
            response.Result = result;
            response.ResultCode = 202;
            response.ResultMessage = resultMessage;
            response.isSubscriber = resultCancel;
            return response;

        }
        [HttpPost]
        public GetAllMemberShipTypeApiResponse GetAllMembershipTypeApi([FromBody] JsonElement JObject)
        {
            errorLogService.ErrorLogAdd("Subscription/CheckDownloadAuthorization  " + JObject.ToString());
            GetAllMemberShipTypeApiRequest req = Functions.ToObject<GetAllMemberShipTypeApiRequest>(JObject);
            string countryCode = "TR";
            var header = Request.HttpContext.Connection.RemoteIpAddress;
            IpInfo ipInfo = new IpInfo();
            try
            {
                string info = new WebClient().DownloadString("http://ipinfo.io/" + header);
                ipInfo = JsonConvert.DeserializeObject<IpInfo>(info);

                countryCode = ipInfo.country;
            }
            catch (System.Exception)
            {
                countryCode = "";
            }
            errorLogService.ErrorLogAdd("Subscription/GetAllMembershipTypeApi  " + JObject.ToString()+  " " + header + " " + countryCode);

            var MemberShipTypWithProperties = service
                .MembershipTypewithPricePlanWithPropertiesListForApi(req.currencyName,req.deviceType,req.subribitionTypeStatus,req.languageId);
            GetAllMemberShipTypeApiResponse res = new GetAllMemberShipTypeApiResponse();
            res.ResultMessage = "İşlem Başarılı.";
            res.ResultCode = 1;
            res.Result = true;
            res.memberShipTypeList = MemberShipTypWithProperties;
            return res;
        }
        [HttpPost]
        public GetAllMemberShipTypeRefenransCodeApiResponse GetAllMembershipTypeReferansCodeApi([FromBody] JsonElement JObject)
        {
            errorLogService.ErrorLogAdd("Subscription/GetAllMembershipTypeReferansCodeApi  " + JObject.ToString());
            GetAllMemberShipTypeApiRequest req = Functions.ToObject<GetAllMemberShipTypeApiRequest>(JObject);
            string countryCode = "TR";
            var header = Request.HttpContext.Connection.LocalIpAddress;
            IpInfo ipInfo = new IpInfo();
            try
            {
                string info = new WebClient().DownloadString("http://ipinfo.io/" + header);
                ipInfo = JsonConvert.DeserializeObject<IpInfo>(info);

                countryCode = ipInfo.country;
            }
            catch (System.Exception)
            {
                countryCode = "";
            }
            errorLogService.ErrorLogAdd("Subscription/GetAllMembershipTypeApi  " + JObject.ToString()+  " " + header + " " + countryCode);

            var pricePlaneCodeList = service
                .MembershipTypewithPricePlanReferancCodeListForApi(req.deviceType);
            GetAllMemberShipTypeRefenransCodeApiResponse res = new GetAllMemberShipTypeRefenransCodeApiResponse();
            res.ResultMessage = "İşlem Başarılı.";
            res.ResultCode = 1;
            res.Result = true;
            res.pricePlaneCodeList = pricePlaneCodeList;
            return res;
        }

        [HttpPost]
        public Response StartMembershipApi([FromBody] JsonElement JObject)
        {
            errorLogService.ErrorLogAdd("MemberShipType/StartMembershipApi  " + JObject.ToString());
            StartMembershipApiRequest req = Functions.ToObject<StartMembershipApiRequest>(JObject);

            string message = "";
            long result = customerService
                .MemberShipTypeWithCustomersAddApi(req.customerDefNo, req.pricePlaneId.ToString(), req.paymentChaneId, req.custemerRefCode,req.purchaseToken, out message);
            Response res = new Response();
            if (result > 0)
            {
                res.ResultMessage = "İşlem Başarılı.";
                res.ResultCode = 1;
                res.Result = true;
            }
            else
            {
                if (message != null && message != "")
                    res.ResultMessage = message;
                else
                    res.ResultMessage = "İşlem Başarısız!";
                res.ResultCode = 0;
                res.Result = false;
            }
            return res;
        }
        [HttpPost]
        public Response DeleteMembershipApi([FromBody] JsonElement JObject)
        {
            Response res = new Response();

            try
            {

                errorLogService.ErrorLogAdd("MemberShipType/StartMembershipApi  " + JObject.ToString());
                DeleteMembershipApi req = Functions.ToObject<DeleteMembershipApi>(JObject);
                var member=memberShipTypeWithCustomerService.TGetList(x => x.Id == req.customerDefNo && x.IsActive==true).FirstOrDefault();
                if (member == null)
                {

                    res.ResultMessage = "Bu Abonenin abonelik bulunmamaktadır.";
                    res.ResultCode = 0;
                    res.Result = false;
                    return res;
                }
                memberShipTypeWithCustomerService.TDelete(member);

                string message = "";
                if (true)
                {
                    res.ResultMessage = "İşlem Başarılı.";
                    res.ResultCode = 1;
                    res.Result = true;
                }
                else
                {
                    if (message != null && message != "")
                        res.ResultMessage = message;
                    else
                        res.ResultMessage = "İşlem Başarısız!";
                    res.ResultCode = 0;
                    res.Result = false;
                }
                return res;
            }
            catch (System.Exception)
            {

                res.ResultMessage = "İşlem Başarısız!";
                res.ResultCode = 0;
                res.Result = false;
                return res;
            }
        }
        [HttpPost]
        public MemberShipTypeInfoApiModel GetMemberShipTypeInfo([FromBody] JsonElement JObject)
        {
            errorLogService.ErrorLogAdd("SubScription/GetMemberShipTypeInfo  " + JObject.ToString());

            RequestMemberShip request = Functions.ToObject<RequestMemberShip>(JObject);
            int? languageID = request.languageId;
            MemberShipTypeInfoApiModel memberShipTypeApiModel = new MemberShipTypeInfoApiModel();
            memberShipTypeApiModel = service.SubcriptionInfoByProfilId(request.customerDefNo,languageID.Value);
            if (memberShipTypeApiModel.MemberShipTypeID != null)
            {
                memberShipTypeApiModel.Result = true;
                memberShipTypeApiModel.ResultMessage = "İşlem Başırılı";
                memberShipTypeApiModel.ResultCode = 202;
                return memberShipTypeApiModel;
            }
            else
            {
                memberShipTypeApiModel.Result = false;
                memberShipTypeApiModel.ResultMessage = "Kullanıcının Aboneliklerine Ulaşılamadı";
                if (request.languageId == 2)
                    memberShipTypeApiModel.ResultMessage = "Unable to Reach User's Subscriptions";
                if (request.languageId == 3)
                    memberShipTypeApiModel.ResultMessage = "Die Abonnements des Benutzers können nicht erreicht werden";
                memberShipTypeApiModel.ResultCode = 202;
                return memberShipTypeApiModel;
            }
        }
    }
}
