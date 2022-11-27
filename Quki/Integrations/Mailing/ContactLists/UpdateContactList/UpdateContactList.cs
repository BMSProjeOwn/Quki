using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Integrations.Mailing.ContactLists.UpdateContactList
{
    public class UpdateContactList
    {
        string ApiActionName = "/inbox/v1/contactlists/";
        public UpdateContactListResponse Function(UpdateContactListRequest req, string tokken, string id)
        {
            string URL = MailingParameters.URL + ApiActionName + id;
            UpdateContactListResponse res = new UpdateContactListResponse();
            string request = JsonConvert.SerializeObject(req);
            Integrations.Conncetion con = new Integrations.Conncetion();

            List<HeaderClass> headerList = new List<HeaderClass>();
            HeaderClass header1 = new HeaderClass();
            header1.Name = "Authorization";
            header1.Value = "Bearer " + tokken;
            headerList.Add(header1);
            string resSt = "";
            resSt = con.PATCHConnectionHeaderList(URL, request, headerList, false);
            res = JsonConvert.DeserializeObject<UpdateContactListResponse>(resSt);
            return res;
        }
    }
}
