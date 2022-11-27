using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Entity.Models
{
    public class RatingMark
    {
        [Key]
        public int RatingMarkSeqID { get; set; }
        public int RatingMarkID { get; set; }


        [MaxLength(150)]
        public string RatingMarkName { get; set; }
        [MaxLength(10)]
        public string RatingMarkValue { get; set; }
        public int? LanguageID { get; set; }
        [MaxLength(500)]
        public string RatingMarkImageThumpPath { get; set; }

        public int? GroupID { get; set; }
        public bool IsActive { get; set; }
        public DateTime? UpdatedOn { get; set; }
        [MaxLength(450)]
        public string UpdatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        [MaxLength(450)]
        public string CreatedBy { get; set; }
    }
}
