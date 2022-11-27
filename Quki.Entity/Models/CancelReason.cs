using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Base;

namespace Quki.Entity.Models
{
    public class CancelReason:EntityBase
    {
        [Key]
        public short CancelReasonSeqID { get; set; }

        public short? CancelReasonID { get; set; }

        public string CancelReasonName { get; set; }

        public short? CancelReasonTypeID { get; set; }

        public short? GroupID { get; set; }

        public int? LanguageID { get; set; }

        public short? ValueTypeID { get; set; }

        public string Remark { get; set; }

        public bool? IsActive { get; set; }

        public string ImagePath { get; set; }

        public bool? IsDynamic { get; set; }

        public bool? IsShowUser { get; set; }

        public short? DisplayOrder { get; set; }

        public Guid? UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public Guid? CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }
    }
}
