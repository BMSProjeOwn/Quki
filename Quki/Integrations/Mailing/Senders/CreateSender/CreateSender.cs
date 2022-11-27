using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Integrations.Mailing.Senders.CreateSender
{
    public class CreateSender
    {
        string ApiActionName = "/inbox/v1/senders";
        public CreateSenderResponse Function(CreateSenderRequest req, string tokken)
        {
            string URL = MailingParameters.URL + ApiActionName;
            CreateSenderResponse res = new CreateSenderResponse();
            string request = JsonConvert.SerializeObject(req);
            Integrations.Conncetion con = new Integrations.Conncetion();

            List<HeaderClass> headerList = new List<HeaderClass>();
            HeaderClass header1 = new HeaderClass();
            header1.Name = "Authorization";
            header1.Value = "Bearer " + tokken;
            headerList.Add(header1);
            string resSt = "";
            resSt = con.PostConnectionHeaderList(URL, request, headerList, false);
            res = JsonConvert.DeserializeObject<CreateSenderResponse>(resSt);
            return res;
        }
    }
}
