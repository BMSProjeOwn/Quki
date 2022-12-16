using Quki.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quki.Entity.DtoModels
{
    public class VisitorCommentsModel:DtoBase
    {

        public int VisitorCommentsSeqId { get; set; }
        public int? ComantSeqID { get; set; }
        public int? CompanySeqID { get; set; }
        public int? LanguageID { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public int? VisitorId { get; set; }
        [MaxLength(100)]
        public string VisitorEmail { get; set; }

        [MaxLength(1000)]
        public string Comment { get; set; }
        public bool Status { get; set; }
        public bool ShowOnHomePage { get; set; }
        public Int16 DisplayOrderID { get; set; }
        public DateTime? IssueStartDate { get; set; }
        public DateTime? IssueEndDate { get; set; }
        [MaxLength(450)]
        public string CreatedBy { get; set; }
        public string Phone { get; set; }
        public string Surname { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
