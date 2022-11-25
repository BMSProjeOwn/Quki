using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Integrations.Mailing.ContactLists.AddSingleContactToList
{
    public class AddSingleContactToList
    {
        string ApiActionName = "/inbox/v1/contactlists/";
        public AddSingleContactToListResponse Function(AddSingleContactToListRequest req, string tokken, string id)
        {
            string URL = MailingParameters.URL + ApiActionName + id + "/add";
            AddSingleContactToListResponse res = new AddSingleContactToListResponse();
            string request = JsonConvert.SerializeObject(req);
            Integrations.Conncetion con = new Integrations.Conncetion();

            List<HeaderClass> headerList = new List<HeaderClass>();
            HeaderClass header1 = new HeaderClass();
            header1.Name = "Authorization";
            header1.Value = "Bearer " + tokken;
            headerList.Add(header1);
            string resSt = "";
            resSt = con.PostConnectionHeaderList(URL, request, headerList, false);
            res = JsonConvert.DeserializeObject<AddSingleContactToListResponse>(resSt);
            return res;
        }
    }
}
