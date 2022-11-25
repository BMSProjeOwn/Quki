using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Entity.DtoModels
{
    public class MemberShipTypeAddModel
    {
        public int MemberShipTypeSeqID { get; set; }
        public int? MemberShipTypeID { get; set; }
        public int LanguageID { get; set; }

        public string Name { get; set; }
        public string Code { get; set; }
        public string Remark { get; set; }
        public bool Status { get; set; }
        public bool ShowOnHomePage { get; set; }

    }
}
