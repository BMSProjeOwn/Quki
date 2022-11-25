using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Base;

namespace Quki.Entity.Models
{
    public class SalesItemLineProperties:EntityBase
    {
        [Key]
        public short SalesİtemLinePropertiesSeqID { get; set; }

        public int? SalesItemLinePropertiesID { get; set; }

        public int? SalesItemLinePropertiesParentID { get; set; }

        public int? SalesItemLinePropertiesName { get; set; }

        public string SalesItemLinePropertiesValue { get; set; }

        public short? SalesItemLinePropertiesGroupID { get; set; }

        public string SalesItemLinePropertiesValueType { get; set; }

        public bool? IsActive { get; set; }

        public int? DisplayOrderNumber { get; set; }

        public int? LangugaeID { get; set; }

        public DateTime? CreatedDateTime { get; set; }

        public Guid? CreatedBy { get; set; }

        public Guid? UpdatedBy { get; set; }

        public DateTime? UpdateDateTime { get; set; }
    }
}
