﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Integrations.Mailing.ContactLists.CreateContactList
{
    public class CreateContactListRequest
    {
        public string listName { get; set; }
        public string groupId { get; set; }
        public int legislation { get; set; }
    }
}
