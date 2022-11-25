using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Integrations.Mailing.ContactLists.AddSingleContactToList
{
    public class AddSingleContactToListRequest
    {
        public string email { get; set; }
        public List<CustomField> customFields { get; set; }
    }
    public class CustomField
    {
        public string customFieldId { get; set; }
        public string value { get; set; }
    }

}
