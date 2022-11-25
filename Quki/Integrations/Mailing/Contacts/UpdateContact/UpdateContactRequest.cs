using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Integrations.Mailing.Contacts.UpdateContact
{
    public class UpdateContactRequest
    {
        public List<string> tags { get; set; }
        public List<CustomField> customFields { get; set; }
    }
    public class CustomField
    {
        public string customFieldId { get; set; }
        public string value { get; set; }
    }

}
