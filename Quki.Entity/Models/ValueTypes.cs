using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Base;

namespace Quki.Entity.Models
{
    public class ValueTypes:EntityBase
    {
        [Key]
        public short ValueTypeSeqID { get; set; }

        public short? ValueTypeID { get; set; }

        public string ValueTypeName { get; set; }

        public string ValueTypeSecondName { get; set; }

        public int? LanguageID { get; set; }

        public short? GroupID { get; set; }

        public string Remark { get; set; }

        public bool? IsActive { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public Guid? UpdatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        public Guid? CreatedBy { get; set; }
    }
}
