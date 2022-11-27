using Microsoft.AspNetCore.Authorization;
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
    public class LanguagesController : ApiBaseController<ILanguageService, Languages, LanguageApiModel>
    {
        private readonly ILanguageService service;
        private readonly IErrorLogService errorLogService;
        public LanguagesController(ILanguageService service, IErrorLogService errorLogService, IPlayListDetailService playListDetailService) : base(service)
        {
            this.service = service;
            this.errorLogService = errorLogService;
        }
        [HttpPost]
        [AllowAnonymous]
        public LanguageApiModel GetAllLanguagesApi([FromBody] JsonElement JObject)
        {
            errorLogService.ErrorLogAdd("Languages/GetAllLanguagesApi  " + JObject.ToString());
            Request languages = Functions.ToObject<Request>(JObject);
            int? languageID = languages.languageId;

            LanguageApiModel apiModel = new LanguageApiModel();
            apiModel.Languages = service.GetAllLanguages();
            return apiModel;
        }
    }
}
