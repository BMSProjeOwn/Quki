using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Integrations.Mailing.ContactLists.GetImportStatus
{
    public class GetImportStatus
    {
        string ApiActionName = "/inbox/v1/contactlists/";
        public GetImportStatusResponse Function(string tokken, string contactListId, string importId)
        {
            string URL = MailingParameters.URL + ApiActionName + contactListId + "/import/:" + importId;
            GetImportStatusResponse res = new GetImportStatusResponse();
            Integrations.Conncetion con = new Integrations.Conncetion();

            List<HeaderClass> headerList = new List<HeaderClass>();
            HeaderClass header1 = new HeaderClass();
            header1.Name = "Authorization";
            header1.Value = "Bearer " + tokken;
            headerList.Add(header1);
            string resSt = "";
            resSt = con.GetConnectionHeaderList(URL, headerList, false);
            res = JsonConvert.DeserializeObject<GetImportStatusResponse>(resSt);
            return res;
        }
    }
}
