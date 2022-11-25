using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Integrations.Mailing.Campaigns.CreateCampaignWithHTML
{
    public class CreateCampaignWithHTML
    {
        string ApiActionName = "/inbox/v1/campaigns/custom";
        public CreateCampaignWithHTMLResponse Function(CreateCampaignWithHTMLRequest req, string tokken)
        {
            string URL = MailingParameters.URL + ApiActionName;
            CreateCampaignWithHTMLResponse res = new CreateCampaignWithHTMLResponse();
            string request = JsonConvert.SerializeObject(req);
            Integrations.Conncetion con = new Integrations.Conncetion();

            List<HeaderClass> headerList = new List<HeaderClass>();
            HeaderClass header1 = new HeaderClass();
            header1.Name = "Authorization";
            header1.Value = "Bearer " + tokken;
            headerList.Add(header1);
            string resSt = "";

            resSt = con.SendMail(URL, request, headerList); //con.PostConnectionHeaderList(URL, request, headerList, false);
            res = JsonConvert.DeserializeObject<CreateCampaignWithHTMLResponse>(resSt);
            return res;
        }
    }
}
