using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Entity.DtoModels.ApiModels
{
    public class Response
    {
        public bool Result { get; set; }
        public int ResultCode { get; set; }
        public string ResultMessage { get; set; }
    }
    public class Request
    {
        public int languageId { get; set; }
        public string customerDefNo { get; set; }
    }
}
