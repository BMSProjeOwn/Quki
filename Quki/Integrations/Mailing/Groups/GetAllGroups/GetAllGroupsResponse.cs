using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Integrations.Mailing.Groups.GetAllGroups
{
    public class GetAllGroupsResponse
    {
        public string version { get; set; }
        public bool resultStatus { get; set; }
        public int resultCode { get; set; }
        public string resultMessage { get; set; }
        public ResultObject resultObject { get; set; }
    }
    public class Item
    {
        public string id { get; set; }
        public DateTime createTime { get; set; }
        public DateTime updateTime { get; set; }
        public string groupName { get; set; }
        public int contactsCount { get; set; }
    }

    public class ResultObject
    {
        public int displayCount { get; set; }
        public int totalCount { get; set; }
        public List<Item> items { get; set; }
    }
}
