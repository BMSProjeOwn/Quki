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
    public class CustomersProfilesController : ApiBaseController<IMemberShipTypeWithCustomersProfilesService, MemberShipTypeWithCustomersProfiles, MemberShipTypeWithCustomersProfilesModel>
    {
        private readonly IMemberShipTypeWithCustomersProfilesService service;
        private readonly IErrorLogService errorLogService;
        private readonly IMemberShipTypeWithPropertiesService memberShipTypeWithPropertiesService;
        private readonly IProductService productsService;
        private readonly IAvatarsService avatarsService;
        private readonly IActiveProfileService activeProfileService;
        public CustomersProfilesController(IActiveProfileService activeProfileService,IMemberShipTypeWithCustomersProfilesService service, IErrorLogService errorLogService, IAvatarsService avatarsService, IMemberShipTypeWithPropertiesService memberShipTypeWithPropertiesService, IProductService productsService) : base(service)
        {
            this.service = service;
            this.errorLogService = errorLogService;
            this.memberShipTypeWithPropertiesService = memberShipTypeWithPropertiesService;
            this.productsService = productsService;
            this.avatarsService = avatarsService;
            this.activeProfileService = activeProfileService;
        }
        [HttpPost]
        public CustomersProfilesModelList GetAllProfilesApi([FromBody] JsonElement JObject)
        {
            errorLogService.ErrorLogAdd("CustomersProfiles/GetAllProfilesApi  " + JObject.ToString());
            try
            {
                errorLogService.ErrorLogAdd("Header: device-id:" + Request.Headers["device-id"].ToString()
                    + " device-type: " + Request.Headers["device-type"].ToString()
                     + " app-version: " + Request.Headers["app-version"].ToString());
            }
            catch { }

            string deviceId = "";
            string deviceType = "";
            string version = "";
            try
            {
                deviceId = Request.Headers["device-id"].ToString();
                deviceType = Request.Headers["device-type"].ToString();
                version = Request.Headers["app-version"].ToString();
            }
            catch { }

            CustomersProfilesModelList customersProfilesModelList = new CustomersProfilesModelList();

            customersProfilesModelList.Result = true;
            customersProfilesModelList.ResultCode = 1;
            customersProfilesModelList.ResultMessage = "İşlem Başarılı.";

            CustomersProfilesRequest model = Functions.ToObject<CustomersProfilesRequest>(JObject);
            customersProfilesModelList.createProfileRightCount = memberShipTypeWithPropertiesService.CreateProfileRightCount(model.userID);
            customersProfilesModelList.profileList = service
                .GelMemberShipTypeWithCustomersProfilesByUserID(model.userID, deviceId, deviceType, version);
            customersProfilesModelList.createProfileRightCount = memberShipTypeWithPropertiesService.CreateProfileRightCount(model.userID);
            customersProfilesModelList.profileList = service.GelMemberShipTypeWithCustomersProfilesByUserID(model.userID,deviceId,deviceType,version);
            return customersProfilesModelList;
        }

        [HttpPost]
        public CustomersProfilesModelResponse GetProfileApi([FromBody] JsonElement JObject)
        {
            errorLogService.ErrorLogAdd("CustomersProfiles/GetProfileApi  " + JObject.ToString());
            try
            {
                errorLogService.ErrorLogAdd("Header: device-id:" + Request.Headers["device-id"].ToString()
                    + " device-type: " + Request.Headers["device-type"].ToString()
                     + " app-version: " + Request.Headers["app-version"].ToString());
            }
            catch { }
            errorLogService.ErrorLogAdd("CustomersProfiles/GetProfileApi  " + JObject.ToString());

            string deviceId = "";
            string deviceType = "";
            string version = "";
            try
            {
                deviceId = Request.Headers["device-id"].ToString();
                deviceType = Request.Headers["device-type"].ToString();
                version = Request.Headers["app-version"].ToString();
            }
            catch { }

            CustomersProfilesModelResponse customersProfilesModelResponse = new CustomersProfilesModelResponse();
            customersProfilesModelResponse.Result = true;
            customersProfilesModelResponse.ResultCode = 1;
            customersProfilesModelResponse.ResultMessage = "İşlem Başarılı.";

            CustomersProfilesRequest model = Functions.ToObject<CustomersProfilesRequest>(JObject);
            customersProfilesModelResponse.profile = service.GelMemberShipTypeWithCustomersProfilesByProfileUserID(model.profileUserID,deviceId,deviceType,version);
           
            if(customersProfilesModelResponse.profile.userID==null)
            {
                customersProfilesModelResponse.Result = false;
                customersProfilesModelResponse.ResultCode = -1;
                customersProfilesModelResponse.ResultMessage = "Profil Bulunamadı!";
            }
            return customersProfilesModelResponse;
        }

        [HttpPost]
        public CustomersProfilesModelResponse AddProfileApi([FromBody] JsonElement JObject)
        {
             errorLogService.ErrorLogAdd("CustomersProfiles/AddProfileApi  " + JObject.ToString());

            try
            {
                errorLogService.ErrorLogAdd("Header: device-id:" + Request.Headers["device-id"].ToString()
                    + " device-type: " + Request.Headers["device-type"].ToString()
                     + " app-version: " + Request.Headers["app-version"].ToString());
            }
            catch { }

            string deviceId = "";
            string deviceType = "";
            string version = "";
            try
            {
                deviceId = Request.Headers["device-id"].ToString();
                deviceType = Request.Headers["device-type"].ToString();
                version = Request.Headers["app-version"].ToString();
            }
            catch { }

            errorLogService.ErrorLogAdd("CustomersProfiles/AddProfileApi  " + JObject.ToString());
            CustomersProfilesRequest model = Functions.ToObject<CustomersProfilesRequest>(JObject);
            
            model.profileUserID = service.AddMemberShipTypeWithCustomersProfilesByProfileUserID(model.userID, model.name, model.iconPhat);


            CustomersProfilesModelResponse customersProfilesModelResponse = new CustomersProfilesModelResponse();
            customersProfilesModelResponse.Result = true;
            customersProfilesModelResponse.ResultCode = 1;
            customersProfilesModelResponse.ResultMessage = "İşlem Başarılı.";
            customersProfilesModelResponse.profile = service
                .GelMemberShipTypeWithCustomersProfilesByProfileUserID(model.profileUserID, deviceId, deviceType, version);
            return customersProfilesModelResponse;
        }

        [HttpPost]
        public CustomersProfilesModelResponse UpdateProfileApi([FromBody] JsonElement JObject)
        {
            errorLogService.ErrorLogAdd("CustomersProfiles/UpdateProfileApi  " + JObject.ToString());

            try
            {
                errorLogService.ErrorLogAdd("Header: device-id:" + Request.Headers["device-id"].ToString()
                    + " device-type: " + Request.Headers["device-type"].ToString()
                     + " app-version: " + Request.Headers["app-version"].ToString());
            }
            catch { }

            string deviceId = "";
            string deviceType = "";
            string version = "";
            try
            {
                deviceId = Request.Headers["device-id"].ToString();
                deviceType = Request.Headers["device-type"].ToString();
                version = Request.Headers["app-version"].ToString();
            }
            catch { }

            CustomersProfilesRequest model = Functions.ToObject<CustomersProfilesRequest>(JObject);
            
            service.UpdateMemberShipTypeWithCustomersProfilesByProfileUserID(model.profileUserID, model.name, model.iconPhat);


            CustomersProfilesModelResponse customersProfilesModelResponse = new CustomersProfilesModelResponse();
            customersProfilesModelResponse.Result = true;
            customersProfilesModelResponse.ResultCode = 1;
            customersProfilesModelResponse.ResultMessage = "İşlem Başarılı.";
            customersProfilesModelResponse.profile = service
                .GelMemberShipTypeWithCustomersProfilesByProfileUserID(model.profileUserID, deviceId, deviceType, version);
            return customersProfilesModelResponse;
        }

        [HttpPost]
        public Response DeleteProfileApi([FromBody] JsonElement JObject)
        {
            errorLogService.ErrorLogAdd("CustomersProfiles/DeleteProfileApi  " + JObject.ToString());
            CustomersProfilesRequest model = Functions.ToObject<CustomersProfilesRequest>(JObject);
            service.DeleteMemberShipTypeWithCustomersProfilesByProfileUserID(model.profileUserID);


            Response res = new Response();
            res.Result = true;
            res.ResultCode = 1;
            res.ResultMessage = "İşlem Başarılı.";
            return res;
        }


        [HttpPost]
        public Response ProfileIconsApi([FromBody] JsonElement JObject)
        {
            errorLogService.ErrorLogAdd("CustomersProfiles/ProfileIconsApi  " + JObject.ToString());
            var result = avatarsService.GetAllProfileAvatars();
            ProfileIconsModel res = new ProfileIconsModel();
            res.iconsList = new List<IconsModel>();
            if (result != null)
            {
                foreach (var item in result)
                {
                    IconsModel model = new IconsModel();
                    model.iconId = item.AvatarsSeqID;
                    model.iconName = item.AvatarsName;
                    model.iconPath = item.AvatarImagePath;
                    res.iconsList.Add(model);
                }
            }

            res.Result = true;
            res.ResultCode = 1;
            res.ResultMessage = "İşlem Başarılı.";
            return res;
        }

        [HttpPost]
        public void SetProfileActive([FromBody] JsonElement JObject)
        {
            //ErrorLogRepository errorLogRepository = new ErrorLogRepository();
            //errorLogRepository.ErrorLogAdd("CustomersProfiles/SetProfileActive  " + JObject.ToString());
            CustomersProfilesRequest model = Functions.ToObject<CustomersProfilesRequest>(JObject);
            string deviceId = "";
            string deviceType = "";
            string version = "";
            try
            {
                deviceId = Request.Headers["device-id"].ToString();
                deviceType = Request.Headers["device-type"].ToString();
                version = Request.Headers["app-version"].ToString();
            }
            catch { }

            if (model.profileUserID != null)
                if (model.profileUserID != "")
                    activeProfileService.SetActiveProfile(model.profileUserID,deviceId,deviceType,version);

            Response res = new Response();
            res.Result = true;
            res.ResultCode = 1;
            res.ResultMessage = "İşlem Başarılı.";
            //return res;
        }

        [HttpPost]
        public Response SetProfileInActive([FromBody] JsonElement JObject)
        {
            errorLogService.ErrorLogAdd("CustomersProfiles/SetProfileInActive  " + JObject.ToString());
            CustomersProfilesRequest model = Functions.ToObject<CustomersProfilesRequest>(JObject);
            
            string deviceId = "";
            string deviceType = "";
            string version = "";
            try
            {
                deviceId = Request.Headers["device-id"].ToString();
                deviceType = Request.Headers["device-type"].ToString();
                version = Request.Headers["app-version"].ToString();
            }
            catch { }

            if (model.profileUserID != null)
                if (model.profileUserID != "")
                    activeProfileService.SetActiveInProfile(model.profileUserID, deviceId, deviceType, version);

            Response res = new Response();
            res.Result = true;
            res.ResultCode = 1;
            res.ResultMessage = "İşlem Başarılı.";
            return res;
        }
    }
}
