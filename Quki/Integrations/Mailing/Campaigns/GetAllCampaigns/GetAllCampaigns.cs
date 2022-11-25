using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Integrations.Mailing.Campaigns.GetAllCampaigns
{
    public class GetAllCampaigns
    {
        string ApiActionName = "/inbox/v1/campaigns";
        public GetAllCampaignsResponse Function(string tokken)
        {
            string URL = MailingParameters.URL + ApiActionName;
            GetAllCampaignsResponse res = new GetAllCampaignsResponse();
            Integrations.Conncetion con = new Integrations.Conncetion();

            List<HeaderClass> headerList = new List<HeaderClass>();
            HeaderClass header1 = new HeaderClass();
            header1.Name = "Authorization";
            header1.Value = "Bearer " + tokken;
            headerList.Add(header1);
            string resSt = "";
            resSt = con.GetConnectionHeaderList(URL, headerList, false);
            res = JsonConvert.DeserializeObject<GetAllCampaignsResponse>(resSt);
            return res;
        }
    }
}
