using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Base;

namespace Quki.Entity.Models
{
    public class CustomerRatings:EntityBase
    {
        [Key]
        public int CustomerRatingsSeqID { get; set; }
        [MaxLength(450)]
        public string customer_def_no { get; set; }
        public int? RatingTypeSeqID { get; set; }
        public int? RatingMarkSeqID { get; set; }
        public int? RelatedRatingSeqID { get; set; }
        [MaxLength(500)]
        public string Remark { get; set; }
        public string ReatingValue { get; set; }
        [MaxLength(50)]
        public string IPBlock { get; set; }
        [MaxLength(500)]
        public string PagePath { get; set; }
        public bool IsActive { get; set; }
        public DateTime? UpdatedOn { get; set; }
        [MaxLength(450)]
        public string UpdatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        [MaxLength(450)]
        public string CreatedBy { get; set; }

    }
}
