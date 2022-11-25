using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Base;

namespace Quki.Entity.Models
{
    public class Document : EntityBase
    {
        [Key]
        public int DocumentSeqID { get; set; }
        public int? DocumentID { get; set; }
        public int? MenuID { get; set; }
        public int? LanguageID { get; set; }
        [MaxLength(250)]
        public string PageTitle { get; set; }
        [MaxLength(250)]
        public string Header { get; set; }
        [MaxLength(250)]
        public string Header2 { get; set; }

        [MaxLength(250)]
        public string MetaTag { get; set; }
        public string Contents { get; set; }
        public string Contents2 { get; set; }
        public DateTime? Date { get; set; }
        [MaxLength(250)]
        public string URL { get; set; }
        public bool Status { get; set; }
    }
}
