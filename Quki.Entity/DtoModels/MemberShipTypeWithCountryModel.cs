using System;
using Quki.Entity.Base;

namespace Quki.Entity.DtoModels
{
    public class MemberShipTypeWithCountryModel : DtoBase
    {
        public long MemberShipTypeWithCountrySeqID { get; set; }

        public int? MemberShipTypSeqID { get; set; }

        public int? CounrtySeqID { get; set; }

        public bool? IsActivated { get; set; }

        public bool? IsSeleceted { get; set; }

        public Guid? CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }
    }
}
