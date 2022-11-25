using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Integrations.Mailing.Campaigns.CreateCampaignWithNewsletter
{
    public class CreateCampaignWithNewsletterRequest
    {
        public string newsletterId { get; set; }
        public string senderAccountId { get; set; }
        public int listType { get; set; }
        public List<string> lists { get; set; }
        public DateTime plannedTime { get; set; }
        public bool notifyWhenStart { get; set; }
        public bool notifyWhenEnd { get; set; }
    }
}
