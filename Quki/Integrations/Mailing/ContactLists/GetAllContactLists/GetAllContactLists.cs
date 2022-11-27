using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Integrations.Mailing.ContactLists.GetAllContactLists
{
    public class GetAllContactLists
    {
        string ApiActionName = "/inbox/v1/contactlists";
        public GetAllContactListsResponse Function(string tokken)
        {
            string URL = MailingParameters.URL + ApiActionName;
            GetAllContactListsResponse res = new GetAllContactListsResponse();
            Integrations.Conncetion con = new Integrations.Conncetion();

            List<HeaderClass> headerList = new List<HeaderClass>();
            HeaderClass header1 = new HeaderClass();
            header1.Name = "Authorization";
            header1.Value = "Bearer " + tokken;
            headerList.Add(header1);
            string resSt = "";
            resSt = con.GetConnectionHeaderList(URL, headerList, false);
            res = JsonConvert.DeserializeObject<GetAllContactListsResponse>(resSt);
            return res;
        }
    }
}
