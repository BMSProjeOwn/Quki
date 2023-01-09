using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Base;

namespace Quki.Entity.DtoModels
{
    public class SluDefWithLanguageModel : DtoBase
    {
        [Key]
        public int SluDefWithLanguageSeqId { get; set; }
        public long? SluDefSeq { get; set; }
        public string Name { get; set; }
        public int? LanguageId { get; set; }
        public string Remark { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public string Option4 { get; set; }
        public string Option5 { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; }

    }
}
