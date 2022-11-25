using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Integrations.Mailing.Campaigns.GetAllCampaigns
{
    public class GetAllCampaignsResponse
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
        public string createUserId { get; set; }
        public DateTime updateTime { get; set; }
        public string updateUserId { get; set; }
        public string subject { get; set; }
        public DateTime plannedTime { get; set; }
        public int totalRecipients { get; set; }
        public int sent { get; set; }
        public int delivered { get; set; }
        public int opened { get; set; }
        public int clicked { get; set; }
        public int bounceSoft { get; set; }
        public int bounceHard { get; set; }
        public int spamReported { get; set; }
        public int unsubscribed { get; set; }
        public int totalOpens { get; set; }
        public int totalClicks { get; set; }
        public DateTime lastOpenTime { get; set; }
        public object lastClickTime { get; set; }
        public double averageOpenTime { get; set; }
        public int status { get; set; }
    }

    public class ResultObject
    {
        public int displayCount { get; set; }
        public int totalCount { get; set; }
        public List<Item> items { get; set; }
    }

}
