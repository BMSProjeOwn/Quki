using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Integrations.Mailing.Campaigns.GetCampaign
{
    public class GetCampaign
    {
        string ApiActionName = "/inbox/v1/campaigns/";
        public GetCampaignResponse Function(string tokken, string id)
        {
            string URL = MailingParameters.URL + ApiActionName + id;
            GetCampaignResponse res = new GetCampaignResponse();
            Integrations.Conncetion con = new Integrations.Conncetion();

            List<HeaderClass> headerList = new List<HeaderClass>();
            HeaderClass header1 = new HeaderClass();
            header1.Name = "Authorization";
            header1.Value = "Bearer " + tokken;
            headerList.Add(header1);
            string resSt = "";
            resSt = con.GetConnectionHeaderList(URL, headerList, false);
            res = JsonConvert.DeserializeObject<GetCampaignResponse>(resSt);
            return res;
        }
    }
}
