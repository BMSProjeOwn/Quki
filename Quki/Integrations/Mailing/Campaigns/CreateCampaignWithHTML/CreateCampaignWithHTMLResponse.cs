using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Integrations.Mailing.Campaigns.CreateCampaignWithHTML
{
    public class CreateCampaignWithHTMLResponse
    {
        public string version { get; set; }
        public bool resultStatus { get; set; }
        public int resultCode { get; set; }
        public string resultMessage { get; set; }
        public string resultObject { get; set; }
    }
}
