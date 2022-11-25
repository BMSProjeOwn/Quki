using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Integrations.Mailing.Campaigns.CreateCampaignWithHTML
{
    public class CreateCampaignWithHTMLRequest
    {
        public string senderAccountId { get; set; }
        public int listType { get; set; }
        public List<string> lists { get; set; }
        public string subject { get; set; }
        //public DateTime plannedTime { get; set; }
        public string htmlContent { get; set; }
        public string language { get; set; }
    }
}
