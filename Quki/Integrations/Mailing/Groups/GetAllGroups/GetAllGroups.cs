using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Integrations.Mailing.Groups.GetAllGroups
{
    public class GetAllGroups
    {
        string ApiActionName = "/inbox/v1/groups";
        public GetAllGroupsResponse Function(string tokken)
        {
            string URL = MailingParameters.URL + ApiActionName;
            GetAllGroupsResponse res = new GetAllGroupsResponse();
            Integrations.Conncetion con = new Integrations.Conncetion();

            List<HeaderClass> headerList = new List<HeaderClass>();
            HeaderClass header1 = new HeaderClass();
            header1.Name = "Authorization";
            header1.Value = "Bearer " + tokken;
            headerList.Add(header1);
            string resSt = "";
            resSt = con.GetConnectionHeaderList(URL, headerList, false);
            res = JsonConvert.DeserializeObject<GetAllGroupsResponse>(resSt);
            return res;
        }
    }
}
