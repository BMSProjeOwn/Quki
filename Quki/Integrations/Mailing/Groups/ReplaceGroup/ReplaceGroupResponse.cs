﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Integrations.Mailing.Groups.ReplaceGroup
{
    public class ReplaceGroupResponse
    {
        public string version { get; set; }
        public bool resultStatus { get; set; }
        public int resultCode { get; set; }
        public string resultMessage { get; set; }
        public bool resultObject { get; set; }
    }
}