using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Integrations.Mailing.CustomFields.CreateCustomField
{
    public class CreateCustomField
    {
        string ApiActionName = "/inbox/v1/customfields";
        public CreateCustomFieldResponse Function(CreateCustomFieldRequest req, string tokken)
        {
            string URL = MailingParameters.URL + ApiActionName;
            CreateCustomFieldResponse res = new CreateCustomFieldResponse();
            string request = JsonConvert.SerializeObject(req);
            Integrations.Conncetion con = new Integrations.Conncetion();

            List<HeaderClass> headerList = new List<HeaderClass>();
            HeaderClass header1 = new HeaderClass();
            header1.Name = "Authorization";
            header1.Value = "Bearer " + tokken;
            headerList.Add(header1);
            string resSt = "";
            resSt = con.PostConnectionHeaderList(URL, request, headerList, false);
            res = JsonConvert.DeserializeObject<CreateCustomFieldResponse>(resSt);
            return res;
        }
    }
}
