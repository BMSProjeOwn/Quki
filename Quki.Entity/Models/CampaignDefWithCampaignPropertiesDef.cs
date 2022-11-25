using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Base;

namespace Quki.Entity.Models
{
    public class CampaignDefWithCampaignPropertiesDef :EntityBase
    {
        [Key]
        public int CampaignDefWithCampaignPropertiesDefSeqID { get; set; }

        public int? CampaignDefPropertiesDefSeqID { get; set; }

        public int? CampaignDefSeqID { get; set; }

        public string PropertiesName { get; set; }

        public short? PropertiesTypeID { get; set; }

        public string Value { get; set; }

        public string StartValue { get; set; }

        public string EndValue { get; set; }

        public DateTime? CreatedDateTime { get; set; }

        public Guid? CreatedBy { get; set; }

        public Guid? UpdatedBy { get; set; }

        public DateTime? UpdateDateTime { get; set; }

        public bool? IsActive { get; set; }
    }
}
