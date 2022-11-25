using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Integrations.Mailing.Groups.UpdateGroups
{
    public class UpdateGroups
    {
        string ApiActionName = "/inbox/v1/groups/";
        public UpdateGroupsResponse Function(UpdateGroupsRequest req, string tokken, string id)
        {
            string URL = MailingParameters.URL + ApiActionName + id;
            UpdateGroupsResponse res = new UpdateGroupsResponse();
            string request = JsonConvert.SerializeObject(req);
            Integrations.Conncetion con = new Integrations.Conncetion();

            List<HeaderClass> headerList = new List<HeaderClass>();
            HeaderClass header1 = new HeaderClass();
            header1.Name = "Authorization";
            header1.Value = "Bearer " + tokken;
            headerList.Add(header1);
            string resSt = "";
            resSt = con.PATCHConnectionHeaderList(URL, request, headerList, false);
            res = JsonConvert.DeserializeObject<UpdateGroupsResponse>(resSt);
            return res;
        }
    }
}
