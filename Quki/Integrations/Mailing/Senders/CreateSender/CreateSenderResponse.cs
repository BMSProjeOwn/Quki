using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Integrations.Mailing.Senders.CreateSender
{
    public class CreateSenderResponse
    {
        public string version { get; set; }
        public bool resultStatus { get; set; }
        public int resultCode { get; set; }
        public string resultMessage { get; set; }
        public ResultObject resultObject { get; set; }
    }
    public class ResultObject
    {
        public string id { get; set; }
        public DateTime createTime { get; set; }
        public DateTime updateTime { get; set; }
        public string email { get; set; }
        public string displayName { get; set; }
        public string replyEmail { get; set; }
        public bool spf { get; set; }
        public bool dkim { get; set; }
        public bool dmarc { get; set; }
        public bool activation { get; set; }
        public string fullName { get; set; }
    }
}
