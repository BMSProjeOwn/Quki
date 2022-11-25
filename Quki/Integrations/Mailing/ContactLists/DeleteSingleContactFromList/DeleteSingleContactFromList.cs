using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Integrations.Mailing.ContactLists.DeleteSingleContactFromList
{
    public class DeleteSingleContactFromList
    {
        string ApiActionName = "/inbox/v1/contactlists/";
        public DeleteSingleContactFromListResponse Function(string tokken, string id, string contact_id)
        {
            string URL = MailingParameters.URL + ApiActionName + "id" + "/delete/:" + contact_id;
            DeleteSingleContactFromListResponse res = new DeleteSingleContactFromListResponse();
            Integrations.Conncetion con = new Integrations.Conncetion();

            List<HeaderClass> headerList = new List<HeaderClass>();
            HeaderClass header1 = new HeaderClass();
            header1.Name = "Authorization";
            header1.Value = "Bearer " + tokken;
            headerList.Add(header1);
            string resSt = "";
            resSt = con.DelConnectionHeaderList(URL, headerList, false);
            res = JsonConvert.DeserializeObject<DeleteSingleContactFromListResponse>(resSt);
            return res;
        }
    }
}
