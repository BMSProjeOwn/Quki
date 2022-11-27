using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Quki.Entity.Base;

namespace Quki.Entity.Models
{
    public class MembershipProperties:EntityBase
    {
        [Key]
        public int MemberShipPropertiesSeqID { get; set; }
        public int MemberShipPropertiesID { get; set; }
        public int LanguageID { get; set; }
        public Int16 ParentID { get; set; }
        [MaxLength(150)]
        public string Name { get; set; }
        [MaxLength(150)]
        public string InitialValue { get; set; }
        [MaxLength(150)]
        public string EndValue { get; set; }
        public string Command { get; set; }
        [MaxLength(150)]
        public string FunctionName { get; set; }
        public string ImageThumpPath { get; set; }
        public string Remark { get; set; }
        public int GroupID { get; set; }
        public bool IsDynamic { get; set; }
        public int? ValueTypeSeqID { get; set; }
         public int? Type { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        public Int16 DisplayOrderNumber { get; set; }
        public bool Status { get; set; }

        public bool IsshowScreen { get; set; }

        public List<MemberShipTypeWithProperties> MemberShipTypeWithPropertiess { get; set; }
    }
}
