﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Integrations.Mailing.ContactLists.ReplaceContactList
{
    public class ReplaceContactListResponse
    {
        public string version { get; set; }
        public bool resultStatus { get; set; }
        public int resultCode { get; set; }
        public string resultMessage { get; set; }
        public bool resultObject { get; set; }
    }
}
