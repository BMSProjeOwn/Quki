using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Integrations.Mailing.Contacts.GetContact
{
    public class GetContactResponse
    {
        public string version { get; set; }
        public bool resultStatus { get; set; }
        public int resultCode { get; set; }
        public string resultMessage { get; set; }
        public ResultObject resultObject { get; set; }
    }
    public class CustomField
    {
        public string customFieldId { get; set; }
        public string name { get; set; }
        public int type { get; set; }
        public string value { get; set; }
    }

    public class ResultObject
    {
        public string id { get; set; }
        public DateTime createTime { get; set; }
        public DateTime updateTime { get; set; }
        public string email { get; set; }
        public int rank { get; set; }
        public int status { get; set; }
        public List<string> tags { get; set; }
        public List<CustomField> customFields { get; set; }
    }

}
