using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Entity.Models
{
    public class TrackingType
    {
        [Key]
        public int TrackingTypeSeqID { get; set; }
        public int? TrackingPageID { get; set; }
        public int LanguageID { get; set; }

        [MaxLength(250)]
        public string TrackingPageName { get; set; }
        [MaxLength(500)]
        public string ImagePath { get; set; }
        public bool IsTracking { get; set; }
        [MaxLength(250)]
        public string OnFunctionName { get; set; }

        public bool IsTrackingFunction { get; set; }
        public bool IsActive { get; set; }
        public int? GroupID { get; set; }

        public DateTime? UpdatedOn { get; set; }
        [MaxLength(450)]
        public string UpdatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        [MaxLength(450)]
        public string CreatedBy { get; set; }
    }
}
