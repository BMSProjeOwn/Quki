using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Integrations.Mailing.Contacts.GetContact
{
    public class GetContact
    {
        string ApiActionName = "/inbox/v1/contacts/";
        public GetContactResponse Function(string tokken, string id)
        {
            string URL = MailingParameters.URL + ApiActionName + id;
            GetContactResponse res = new GetContactResponse();
            Integrations.Conncetion con = new Integrations.Conncetion();

            List<HeaderClass> headerList = new List<HeaderClass>();
            HeaderClass header1 = new HeaderClass();
            header1.Name = "Authorization";
            header1.Value = "Bearer " + tokken;
            headerList.Add(header1);
            string resSt = "";
            resSt = con.GetConnectionHeaderList(URL, headerList, false);
            res = JsonConvert.DeserializeObject<GetContactResponse>(resSt);
            return res;
        }
    }
}
