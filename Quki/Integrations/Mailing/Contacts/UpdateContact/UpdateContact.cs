using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Integrations.Mailing.Contacts.UpdateContact
{
    public class UpdateContact
    {
        string ApiActionName = "/inbox/v1/contacts/";
        public UpdateContactResponse Function(UpdateContactRequest req, string tokken, string id)
        {
            string URL = MailingParameters.URL + ApiActionName + id + "/status";
            UpdateContactResponse res = new UpdateContactResponse();
            string request = JsonConvert.SerializeObject(req);
            Integrations.Conncetion con = new Integrations.Conncetion();

            List<HeaderClass> headerList = new List<HeaderClass>();
            HeaderClass header1 = new HeaderClass();
            header1.Name = "Authorization";
            header1.Value = "Bearer " + tokken;
            headerList.Add(header1);
            string resSt = "";
            resSt = con.PostConnectionHeaderList(URL, request, headerList, false);
            res = JsonConvert.DeserializeObject<UpdateContactResponse>(resSt);
            return res;
        }
    }
}
