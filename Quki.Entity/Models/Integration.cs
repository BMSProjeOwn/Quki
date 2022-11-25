using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Base;

namespace Quki.Entity.Models
{
    public class Integration:EntityBase
    {
        [Key]
        public long IntegrationSeqID { get; set; }

        public long? IntegrationID { get; set; }

        public string IntegrationName { get; set; }

        public string IntegrationDescription { get; set; }

        public int? IntegrationState { get; set; }

        public bool? isActive { get; set; }

        public DateTime? CreateDateTime { get; set; }

        public string CreateBy { get; set; }

        public int? IntegrationStatus { get; set; }

    }
}
