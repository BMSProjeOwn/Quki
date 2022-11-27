using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Base;

namespace Quki.Entity.DtoModels
{
    public class PlayListDetailModel:DtoBase
    {
        [Key]
        public int PlayListDetailSeqID { get; set; }
        public int? PlayListSeqID { get; set; }
        public int? RelatedItemSeqID { get; set; }
        [MaxLength(150)]
        public string RelatedItemName { get; set; }
        [MaxLength(250)]
        public string Remark { get; set; }
        public string RelatedItemImageThumpPath { get; set; }
        public int? DisplayOrderNumber { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelet { get; set; }
        public int? LanguageID { get; set; }

        public DateTime? UpdatedOn { get; set; }
        [MaxLength(450)]
        public string UpdatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        [MaxLength(450)]
        public string CreatedBy { get; set; }
    }
}
