using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Integrations.Mailing.ContactLists.ImportContactsToList
{
    public class ImportContactsToList
    {
        string ApiActionName = "/inbox/v1/contactlists/";
        public ImportContactsToListResponse Function(ImportContactsToListRequest req, string tokken, string contactlistId)
        {
            string URL = MailingParameters.URL + ApiActionName + contactlistId + "/import";
            ImportContactsToListResponse res = new ImportContactsToListResponse();
            string request = JsonConvert.SerializeObject(req.list);
            Integrations.Conncetion con = new Integrations.Conncetion();

            List<HeaderClass> headerList = new List<HeaderClass>();
            HeaderClass header1 = new HeaderClass();
            header1.Name = "Authorization";
            header1.Value = "Bearer " + tokken;
            headerList.Add(header1);
            string resSt = "";
            resSt = con.PostConnectionHeaderList(URL, request, headerList, false);
            res = JsonConvert.DeserializeObject<ImportContactsToListResponse>(resSt);
            return res;
        }
    }
}
