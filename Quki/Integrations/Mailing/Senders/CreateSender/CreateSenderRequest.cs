using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Integrations.Mailing.Senders.CreateSender
{
    public class CreateSenderRequest
    {
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string ReplyEmail { get; set; }
    }
}
