using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quki.Integrations.Mailing.Authentication
{
    public class Authentication
    {
        string ApiActionName = "/token";
        public AuthenticationResponse AuthenticationFunction(AuthenticationRequest req)
        {
            string URL = MailingParameters.URL + ApiActionName;
            AuthenticationResponse res = new AuthenticationResponse();
            string request = JsonConvert.SerializeObject(req);
            Integrations.Conncetion con = new Integrations.Conncetion();
            string resSt = "";
            resSt = con.PostConnectionHeaderList(URL, request, null, false);
            res = JsonConvert.DeserializeObject<AuthenticationResponse>(resSt);
            return res;
        }
    }
}
