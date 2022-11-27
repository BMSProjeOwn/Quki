using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Integrations.Mailing.Campaigns.CreateCampaignWithNewsletter
{
    public class CreateCampaignWithNewsletter
    {
        string ApiActionName = "/inbox/v1/campaigns";
        public CreateCampaignWithNewsletterResponse Function(CreateCampaignWithNewsletterRequest req, string tokken)
        {
            string URL = MailingParameters.URL + ApiActionName;
            CreateCampaignWithNewsletterResponse res = new CreateCampaignWithNewsletterResponse();
            string request = JsonConvert.SerializeObject(req);
            Integrations.Conncetion con = new Integrations.Conncetion();

            List<HeaderClass> headerList = new List<HeaderClass>();
            HeaderClass header1 = new HeaderClass();
            header1.Name = "Authorization";
            header1.Value = "Bearer " + tokken;
            headerList.Add(header1);
            string resSt = "";
            resSt = con.PostConnectionHeaderList(URL, request, headerList, false);
            res = JsonConvert.DeserializeObject<CreateCampaignWithNewsletterResponse>(resSt);
            return res;
        }
    }
}
