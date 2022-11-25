using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Base;
using Quki.Entity.Models;

namespace Quki.Entity.DtoModels
{
    public class BugTrackAddModel:DtoBase
    {
        public long BugTrackSeqID { get; set; }

        public long? BugTrackNumber { get; set; }

        public string BugTrackTitle { get; set; }

        public short? BugTrackTypeID { get; set; }

        public string Description { get; set; }

        public IFormFile ImagePath { get; set; }
        public string ImagePathName { get; set; }


        public short? Status { get; set; }

        public string VersionNumber { get; set; }

        public string ApplicationName { get; set; }

        public string RelatedPagePath { get; set; }

        public Guid? TesterSeqID { get; set; }

        public DateTime? CreatedDateTime { get; set; }

        public DateTime? CloseDateTime { get; set; }

        public string Email { get; set; }

        public string AssignedBy { get; set; }
        public string ResponseDescription { get; set; }

        public BugTrackDetail bugTrackDetail { get; set; }

    }
}
