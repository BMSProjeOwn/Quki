using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Integrations.Mailing.ContactLists.GetImportStatus
{
    public class GetImportStatusResponse
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
        public string contactListId { get; set; }
        public List<string> customFields { get; set; }
        public int total { get; set; }
        public int added { get; set; }
        public int hardBounce { get; set; }
        public int unsubscribe { get; set; }
        public int spam { get; set; }
        public int alreadyExists { get; set; }
        public int invalid { get; set; }
        public int blocked { get; set; }
        public int repetitive { get; set; }
        public int limitExceeded { get; set; }
        public int status { get; set; }
    }
}
