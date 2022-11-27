using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Integrations.Mailing.CustomFields.CreateCustomField
{
    public class CreateCustomFieldRequest
    {
        public string Name { get; set; }
        public int Type { get; set; }
    }
}
