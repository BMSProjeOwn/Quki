using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Integrations.Mailing.Groups.CreateGroup
{
    public class CreateGroup
    {
        string ApiActionName = "/inbox/v1/groups";
        public CreateGroupResponse Function(CreateGroupRequest req, string tokken)
        {
            string URL = MailingParameters.URL + ApiActionName;
            CreateGroupResponse res = new CreateGroupResponse();
            string request = JsonConvert.SerializeObject(req);
            Integrations.Conncetion con = new Integrations.Conncetion();

            List<HeaderClass> headerList = new List<HeaderClass>();
            HeaderClass header1 = new HeaderClass();
            header1.Name = "Authorization";
            header1.Value = "Bearer " + tokken;
            headerList.Add(header1);
            string resSt = "";
            resSt = con.PostConnectionHeaderList(URL, request, headerList, false);
            res = JsonConvert.DeserializeObject<CreateGroupResponse>(resSt);
            return res;
        }
    }
}
