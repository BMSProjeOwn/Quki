using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Quki.Entity.Base;

namespace Quki.Entity.Models
{
    public class MemberShipTypeWithCountry:EntityBase
    {
        [Key]
        public long MemberShipTypeWithCountrySeqID { get; set; }

        public int? MemberShipTypSeqID { get; set; }

        public int? CounrtySeqID { get; set; }

        public bool? IsActivated { get; set; }

        public bool? IsSeleceted { get; set; }

        public Guid? CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }
    }
}
