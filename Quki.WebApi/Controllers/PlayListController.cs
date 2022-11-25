using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json;
using Quki.Common;
using Quki.Dal.Concrete.Entityframework.Repostories;
using Quki.Entity.DtoModels;
using Quki.Entity.DtoModels.ApiModels;
using Quki.Entity.Models;
using Quki.Entity.ViewModel;
using Quki.Interface;
using Quki.WebApi.Base;

namespace Quki.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PlayListController : ApiBaseController<IPlayListService, PlayList, PlayListModel>
    {
        private readonly IPlayListService service;
        private readonly IErrorLogService errorLogService;
        private readonly IPlayListDetailService playListDetailService;
        public PlayListController(IPlayListService service, IErrorLogService errorLogService, IPlayListDetailService playListDetailService) : base(service)
        {
            this.service = service;
            this.errorLogService = errorLogService;
            this.playListDetailService = playListDetailService;
        }
        [HttpPost]
        public GetAllPlayListApi GetCustomerPlayListApi([FromBody] JsonElement JObject)
        {
            errorLogService.ErrorLogAdd("PlayList/GetCustomerPlayListApi  " + JObject.ToString());
            PlayListProductApiRequest req = Functions.ToObject<PlayListProductApiRequest>(JObject);
            int languageID = req.languageId;


            string customer_def_no = req.customerDefNo;

            var list = service.GetCustomerPlayListSP(customer_def_no, 999, languageID);
            GetAllPlayListApi getAllPlayList = new GetAllPlayListApi();
            getAllPlayList.PlayList = list;
            getAllPlayList.Result = true;
            getAllPlayList.ResultCode = 1;
            getAllPlayList.ResultMessage = "İşlem Başarılı.";
            return getAllPlayList;
        }

        [HttpPost]
        public GetAllPlayListCreateApi CreatePlayListApi([FromBody] JsonElement JObject)
        {
            errorLogService.ErrorLogAdd("PlayList/CreatePlayListApi  " + JObject.ToString());
            CreatePlayListRequest req = Functions.ToObject<CreatePlayListRequest>(JObject);
            int languageID = req.languageId;


            service.CreatePlayListApi(req);
            var list = service.GetCustomerPlayListSP(req.customerDefNo, 1, languageID);
            GetAllPlayListCreateApi getAllPlayList = new GetAllPlayListCreateApi();
            getAllPlayList.PlayList = list[0];
            getAllPlayList.Result = true;
            getAllPlayList.ResultCode = 1;
            getAllPlayList.ResultMessage = "İşlem Başarılı.";
            return getAllPlayList;
        }

        [HttpPost]
        public GetAllPlayListApi DeletePlayListApi([FromBody] JsonElement JObject)
        {
            errorLogService.ErrorLogAdd("PlayList/DeletePlayListApi  " + JObject.ToString());
            PlayListProductApiRequest req = Functions.ToObject<PlayListProductApiRequest>(JObject);
            int languageID = req.languageId;


            service.DeletePlayListApi(req.playListID);
            var list = service.GetCustomerPlayListSP(req.customerDefNo, 999, languageID);
            GetAllPlayListApi getAllPlayList = new GetAllPlayListApi();
            getAllPlayList.PlayList = list;
            getAllPlayList.Result = true;
            getAllPlayList.ResultCode = 1;
            getAllPlayList.ResultMessage = "İşlem Başarılı.";
            return getAllPlayList;
        }

        [HttpPost]
        public GetAllPlayListApi AddProductApi([FromBody] JsonElement JObject)
        {
            errorLogService.ErrorLogAdd("PlayList/AddProductApi  " + JObject.ToString());
            PlayListAddOrDeleteRequest req = Functions.ToObject<PlayListAddOrDeleteRequest>(JObject);
            int languageID = req.languageId;

            var list = service.GetCustomerPlayListSP(req.customerDefNo, 999, languageID);

            playListDetailService.AddItemApi(req.playListID, req.productID);

            GetAllPlayListApi getAllPlayList = new GetAllPlayListApi();
            getAllPlayList.PlayList = list;
            getAllPlayList.Result = true;
            getAllPlayList.ResultCode = 1;
            getAllPlayList.ResultMessage = "İşlem Başarılı.";
            return getAllPlayList;
        }

        [HttpPost]
        public GetAllPlayListApi DeletePlayListProductApi([FromBody] JsonElement JObject)
        {
            errorLogService.ErrorLogAdd("PlayList/DeletePlayListProductApi  " + JObject.ToString());
           ErrorLogModel errorLogModel = new ErrorLogModel();
            errorLogModel.CreateDate = DateTime.Now;
            errorLogModel.TerminalNo = "0";
            errorLogModel.Message = JObject.ToString();
            errorLogModel.InnerException = "";
            errorLogModel.StackTrace = "";
            errorLogModel.TypeID = 0;
            errorLogService.ErrorLogAdd(errorLogModel);


            PlayListAddOrDeleteRequest req = Functions.ToObject<PlayListAddOrDeleteRequest>(JObject);
            int languageID = req.languageId;
            playListDetailService.DeletePlayListDetailApi(req.playListID, req.productID);
            var list = service.GetCustomerPlayListSP(req.customerDefNo, 999, languageID);
            GetAllPlayListApi getAllPlayList = new GetAllPlayListApi();
            getAllPlayList.PlayList = list;
            getAllPlayList.Result = true;
            getAllPlayList.ResultCode = 1;
            getAllPlayList.ResultMessage = "İşlem Başarılı.";
            return getAllPlayList;
        }

        [HttpPost]
        public GetAllPlayListApi ChangeDisplayOrderNumberApi([FromBody] JsonElement JObject)
        {
            errorLogService.ErrorLogAdd("PlayList/ChangeDisplayOrderNumberApi  " + JObject.ToString());
            ErrorLogModel errorLogModel = new ErrorLogModel();
            errorLogModel.CreateDate = DateTime.Now;
            errorLogModel.TerminalNo = "0";
            errorLogModel.Message = JObject.ToString();
            errorLogModel.InnerException = "";
            errorLogModel.StackTrace = "";
            errorLogModel.TypeID = 0;
            errorLogService.ErrorLogAdd(errorLogModel);


            PlayListProductApiRequest req = Functions.ToObject<PlayListProductApiRequest>(JObject);
            int languageID = req.languageId;

            for (int i = 0; i < req.playList.Count; i++)
                playListDetailService.ChangeDisplayOrderNumber(req.playListID, req.playList[i].productID, req.playList[i].displayOrderNumber);
            var list = service.GetCustomerPlayListSP(req.customerDefNo, 999, languageID);
            GetAllPlayListApi getAllPlayList = new GetAllPlayListApi();
            getAllPlayList.PlayList = list;
            getAllPlayList.Result = true;
            getAllPlayList.ResultCode = 1;
            getAllPlayList.ResultMessage = "İşlem Başarılı.";
            return getAllPlayList;
        }
    }
}
