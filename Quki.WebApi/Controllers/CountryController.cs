using Microsoft.AspNetCore.Mvc;
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
    public class CountryController : ApiBaseController<ICountryService, Counrty, CountryModel>
    {
        private readonly ICountryService service;
        private readonly IErrorLogService errorLogService;
        public CountryController(ICountryService service, IErrorLogService errorLogService) : base(service)
        {
            this.service = service;
            this.errorLogService = errorLogService;
        }
        [HttpPost]
        public CountryApiModel GetAllCountriesApi([FromBody] JsonElement JObject)
        {
            errorLogService.ErrorLogAdd("Country/GetAllCountriesApi  " + JObject.ToString());
            Request languages = Functions.ToObject<Request>(JObject);
            int? languageID = languages.languageId;

            CountryApiModel apiModel = new CountryApiModel();
            apiModel.Countries = service.GetAllCountries();
            return apiModel;
        }
    }
}
