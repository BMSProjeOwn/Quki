using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Integrations.Mailing.Contacts.GetAllContacts
{
    public class GetAllContacts
    {
        string ApiActionName = "/inbox/v1/contacts";
        public GetAllContactsResponse Function(string tokken)
        {
            string URL = MailingParameters.URL + ApiActionName;
            GetAllContactsResponse res = new GetAllContactsResponse();
            Integrations.Conncetion con = new Integrations.Conncetion();

            List<HeaderClass> headerList = new List<HeaderClass>();
            HeaderClass header1 = new HeaderClass();
            header1.Name = "Authorization";
            header1.Value = "Bearer " + tokken;
            headerList.Add(header1);
            string resSt = "";
            resSt = con.GetConnectionHeaderList(URL, headerList, false);
            res = JsonConvert.DeserializeObject<GetAllContactsResponse>(resSt);
            return res;
        }
    }
}
