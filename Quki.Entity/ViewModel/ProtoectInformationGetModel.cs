using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Base;

namespace Quki.Entity.ViewModel
{
    public class ProtoectInformationGetModel:DtoBase
    {
        public int ProtectionInformationSeqID { get; set; }
        public string ProtectionInformationHeaderLine { get; set; }
        public string ProtectInformationCode { get; set; }

        public string ProtectInformationValue { get; set; }
        public string Remark { get; set; }
        public string Remark2 { get; set; }
        public bool isHas { get; set; }
        public bool isRequisite { get; set; }
        public bool IsForcedly { get; set; }
    }
}
