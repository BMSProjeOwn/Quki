using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Integrations.Mailing.Senders.UpdateSender
{
    public class UpdateSender
    {
        string ApiActionName = "/inbox/v1/senders/";
        public UpdateSenderResponse Function(UpdateSenderRequest req, string tokken, string id)
        {
            string URL = MailingParameters.URL + ApiActionName + id;
            UpdateSenderResponse res = new UpdateSenderResponse();
            string request = JsonConvert.SerializeObject(req);
            Integrations.Conncetion con = new Integrations.Conncetion();

            List<HeaderClass> headerList = new List<HeaderClass>();
            HeaderClass header1 = new HeaderClass();
            header1.Name = "Authorization";
            header1.Value = "Bearer " + tokken;
            headerList.Add(header1);
            string resSt = "";
            resSt = con.PATCHConnectionHeaderList(URL, request, headerList, false);
            res = JsonConvert.DeserializeObject<UpdateSenderResponse>(resSt);
            return res;
        }
    }
}
