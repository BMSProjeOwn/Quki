using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Integrations.Mailing.ContactLists.ReplaceContactList
{
    public class ReplaceContactList
    {
        string ApiActionName = "/inbox/v1/contactlists/";
        public ReplaceContactListResponse Function(ReplaceContactListRequest req, string tokken, string id)
        {
            string URL = MailingParameters.URL + ApiActionName + id;
            ReplaceContactListResponse res = new ReplaceContactListResponse();
            string request = JsonConvert.SerializeObject(req);
            Integrations.Conncetion con = new Integrations.Conncetion();

            List<HeaderClass> headerList = new List<HeaderClass>();
            HeaderClass header1 = new HeaderClass();
            header1.Name = "Authorization";
            header1.Value = "Bearer " + tokken;
            headerList.Add(header1);
            string resSt = "";
            resSt = con.PutConnectionHeaderList(URL, request, headerList, false);
            res = JsonConvert.DeserializeObject<ReplaceContactListResponse>(resSt);
            return res;
        }
    }
}
