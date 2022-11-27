using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Entity.DtoModels
{
    public class MemberShipTypePropertiesAddModel
    {
        public int MemberShipPropertiesSeqId { get; set; }
        public int MemberShipTypeSeqId { get; set; }
        public int LanguageId { get; set; }
        public int ValueTypeSeqId { get; set; }
        public int GroupId { get; set; }
        public string Name { get; set; }
        public string InitialValue { get; set; }
        public string EndValue { get; set; }

        public string ValueTypeName { get; set; }
        public bool Status { get; set; }

        public bool IsDynamic { get; set; }
    }
}
