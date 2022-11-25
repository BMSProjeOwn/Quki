using System;
using System.ComponentModel.DataAnnotations;
using Quki.Entity.Base;

namespace Quki.Entity.DtoModels
{
    public class IntegrationModel:DtoBase
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
