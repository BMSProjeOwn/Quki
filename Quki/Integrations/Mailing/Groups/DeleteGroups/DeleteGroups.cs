using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Integrations.Mailing.Groups.DeleteGroups
{
    public class DeleteGroups
    {
        string ApiActionName = "/inbox/v1/groups/";
        public DeleteGroupsResponse Function(string tokken, string id)
        {
            string URL = MailingParameters.URL + ApiActionName + id;
            DeleteGroupsResponse res = new DeleteGroupsResponse();
            Integrations.Conncetion con = new Integrations.Conncetion();

            List<HeaderClass> headerList = new List<HeaderClass>();
            HeaderClass header1 = new HeaderClass();
            header1.Name = "Authorization";
            header1.Value = "Bearer " + tokken;
            headerList.Add(header1);
            string resSt = "";
            resSt = con.DelConnectionHeaderList(URL, headerList, false);
            res = JsonConvert.DeserializeObject<DeleteGroupsResponse>(resSt);
            return res;
        }
    }
}
