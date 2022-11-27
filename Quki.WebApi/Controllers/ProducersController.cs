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
    public class ProducersController : ApiBaseController<IProducersService, Producer, ProducersAddModel>
    {
        //entity--veri tabanı classları
        //TDto--veri tabanı calasslarına karşılık gelen transfer objeleri
        //AMAÇ:Mapper yöntemini ile transfer yapabilmek
        //Mapper:Veri tipi ve Proporty adına bakarak dönüştürme yapar.

        //her entity'nin bir DTO modeli olur.

        //

        private readonly IProducersService service;
        private readonly IErrorLogService errorLogService;
        public ProducersController(IProducersService service, IErrorLogService errorLogService) : base(service)
        {
            this.service = service;
            this.errorLogService = errorLogService;
        }
        [HttpPost]
        public PerformerListResource GetAllProducersApi([FromBody] JsonElement JObject)
        {
            errorLogService.ErrorLogAdd("Producers/GetAllProducersApi  " + JObject.ToString());

            Request languages = Functions.ToObject<Request>(JObject);
            int? languageID = languages.languageId;

            string customer_def_no = languages.customerDefNo;




            PerformerListResource res = new PerformerListResource();

            res.performers = service.getHomeProducersList(999, customer_def_no);
            res.result = true;
            res.resultCode = 1;
            res.resultMessage = "İşlem Başarılı";
            return res;
        }

        [HttpPost]
        public ProducersApiDetailModel GetProducerByIDApi([FromBody] JsonElement JObject)
        {
            errorLogService.ErrorLogAdd("Producers/GetAllProducersApi  " + JObject.ToString());
            Request languages = Functions.ToObject<Request>(JObject);
            int? languageID = languages.languageId;

            string customer_def_no = languages.customerDefNo;


            ProducersModel producer = Functions.ToObject<ProducersModel>(JObject);
            ProducersApiDetailModel producersApiDetailModel = new ProducersApiDetailModel();

            producersApiDetailModel = service.GetProducerByIDApi(producer.ProducerSeqID, customer_def_no, 999);
            return producersApiDetailModel;
        }
    }
}
