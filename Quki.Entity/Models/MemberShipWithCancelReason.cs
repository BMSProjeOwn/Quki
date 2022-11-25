using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Base;

namespace Quki.Entity.Models
{
    public class MemberShipWithCancelReason:EntityBase
    {
        [Key]
        public int MemberShipCancelPropertiesSeqID { get; set; }

        public int? MemberShipTypePricePlaneSeqId { get; set; }
        public Guid? UserId { get; set; }
        public short? CancelReasonID { get; set; }
        public string? Value { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsShowUser { get; set; }

        public Guid? UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public Guid? CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
