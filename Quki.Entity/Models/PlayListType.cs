using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Entity.Models
{
    public class PlayListType
    {
        [Key]
        public int PlayListTypeSeqID { get; set; }
        public int? PlayListTypeID { get; set; }
        [MaxLength(150)]
        public string PlayListTypeName { get; set; }
        public int? PlayListTypeStatusID { get; set; }
        public int? LanguageID { get; set; }
        [MaxLength(250)]
        public string PlayListTypeThumpImagePath { get; set; }
        public int? PlayListTypeGroupID { get; set; }
        [MaxLength(250)]
        public string Remark { get; set; }
        public bool? IsShowHomePage { get; set; }
        public bool? IsRunAutomatic { get; set; }
        public int? PlayXSecond { get; set; }
        public bool IsActive { get; set; }
        public DateTime? UpdatedOn { get; set; }
        [MaxLength(450)]
        public string UpdatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        [MaxLength(450)]
        public string CreatedBy { get; set; }

    }
}
