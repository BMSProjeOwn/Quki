using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Base;

namespace Quki.Entity.DtoModels.ApiModels
{
    public class CancelCustomerApiModel:DtoBase
    {
        public int languageId { get; set; }
        public string customerDefNo { get; set; }
        List<CancelReasonApiModel> cancelReasonApiModels { get; set; }
    }
    public class CancelResponse
    {
        public bool Result { get; set; }
        public int ResultCode { get; set; }
        public string ResultMessage { get; set; }
        public bool isSubscriber{get; set; }
    }
}
