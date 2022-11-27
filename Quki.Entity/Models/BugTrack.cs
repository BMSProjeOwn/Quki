using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Base;

namespace Quki.Entity.Models
{
    public class BugTrack:EntityBase
    {
        [Key]
        public long BugTrackSeqID { get; set; }

        public long? BugTrackNumber { get; set; }

        public string BugTrackTitle { get; set; }

        public short? BugTrackTypeID { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; set; }

        public bool? Reminder { get; set; }

        public short? Status { get; set; }

        public string VersionNumber { get; set; }

        public string ApplicationName { get; set; }

        public string RelatedPagePath { get; set; }

        public Guid? TesterSeqID { get; set; }

        public DateTime? CreatedDateTime { get; set; }

        public DateTime? CloseDateTime { get; set; }

    }
}
