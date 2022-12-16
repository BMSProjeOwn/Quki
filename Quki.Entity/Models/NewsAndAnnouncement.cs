using Quki.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quki.Entity.Models
{
    public class NewsAndAnnouncement:EntityBase
    {
        [Key]
        public int NewsAndAnnouncementSeqId { get; set; }

        public int? NewsAndAnnouncementId { get; set; }

        public int? LanguageId { get; set; }

        public int? TypeId { get; set; }

        public string Subject { get; set; }

        public string Contents { get; set; }

        public string Remark { get; set; }

        public string Author { get; set; }

        public string Source { get; set; }

        public string ImagePath { get; set; }

        public string ThumbPath { get; set; }

        public int? OrderNumber { get; set; }

        public int? MainGroupId { get; set; }

        public string SubGroupId { get; set; }

        public bool Status { get; set; }

        public string NavigateUrl { get; set; }

        public DateTime? IssueStartDate { get; set; }

        public DateTime? IssueEndDate { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? CreatedBy { get; set; }
    }
}
