using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Base;

namespace Quki.Entity.DtoModels
{
    public class IntegrationPropertiesModel : DtoBase
    {
        [Key]
        public long IntegrationPropertiesSeqID { get; set; }

        public long? IntegrationSeqID { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }

        public bool? isActive { get; set; }

        public DateTime? CreateDateTime { get; set; }

        public string CreateBy { get; set; }

    }
}
