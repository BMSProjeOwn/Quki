using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Base;

namespace Quki.Entity.DtoModels
{
    public class BugTrackDetailAddModel : DtoBase
    {
        [Key]
        public long BugTrackDetailSeqID { get; set; }

        public long? BugTrackSeqID { get; set; }

        public string ResponseDescription { get; set; }

        public short? Status { get; set; }

        public string RelatedFilePath { get; set; }

        public DateTime? CreatedDateTime { get; set; }

        public Guid? CreatedBy { get; set; }

        public Guid? AssignedBy { get; set; }

        public DateTime? ClosedDateTime { get; set; }

        public Guid? ClosedBy { get; set; }
        public BugTrackAddModel bugTrack { get; set; }

        public string Email { get; set; }

        public string BugTrackTitle { get; set; }



    }
}
