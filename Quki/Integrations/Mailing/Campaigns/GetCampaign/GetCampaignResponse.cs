using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Integrations.Mailing.Campaigns.GetCampaign
{
    public class GetCampaignResponse
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
        public string subject { get; set; }
        public string newsletterLanguage { get; set; }
        public string senderAccountId { get; set; }
        public string senderAccountDisplayName { get; set; }
        public string senderAccountEmail { get; set; }
        public DateTime plannedTime { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public int listType { get; set; }
        public List<string> lists { get; set; }
        public int status { get; set; }
        public int totalRecipients { get; set; }
        public int sent { get; set; }
        public int delivered { get; set; }
        public int opened { get; set; }
        public int clicked { get; set; }
        public int bounceSoft { get; set; }
        public int bounceHard { get; set; }
        public int spamReported { get; set; }
        public int unsubscribed { get; set; }
    }

}
