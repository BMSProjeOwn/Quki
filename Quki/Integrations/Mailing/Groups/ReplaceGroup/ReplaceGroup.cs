using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Integrations.Mailing.Groups.ReplaceGroup
{
    public class ReplaceGroup
    {
        string ApiActionName = "/inbox/v1/groups/";
        public ReplaceGroupResponse Function(ReplaceGroupRequest req, string tokken, string id)
        {
            string URL = MailingParameters.URL + ApiActionName + id;
            ReplaceGroupResponse res = new ReplaceGroupResponse();
            string request = JsonConvert.SerializeObject(req);
            Integrations.Conncetion con = new Integrations.Conncetion();

            List<HeaderClass> headerList = new List<HeaderClass>();
            HeaderClass header1 = new HeaderClass();
            header1.Name = "Authorization";
            header1.Value = "Bearer " + tokken;
            headerList.Add(header1);
            string resSt = "";
            resSt = con.PutConnectionHeaderList(URL, request, headerList, false);
            res = JsonConvert.DeserializeObject<ReplaceGroupResponse>(resSt);
            return res;
        }
    }
}
