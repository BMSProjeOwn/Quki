using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Integrations.Mailing.CustomFields.GetAllCustomFields
{
    public class GetAllCustomFields
    {
        string ApiActionName = "/inbox/v1/customfields";
        public GetAllCustomFieldsResponse Function(string tokken)
        {
            string URL = MailingParameters.URL + ApiActionName;
            GetAllCustomFieldsResponse res = new GetAllCustomFieldsResponse();
            Integrations.Conncetion con = new Integrations.Conncetion();

            List<HeaderClass> headerList = new List<HeaderClass>();
            HeaderClass header1 = new HeaderClass();
            header1.Name = "Authorization";
            header1.Value = "Bearer " + tokken;
            headerList.Add(header1);
            string resSt = "";
            resSt = con.GetConnectionHeaderList(URL, headerList, false);
            res = JsonConvert.DeserializeObject<GetAllCustomFieldsResponse>(resSt);
            return res;
        }
    }
}
