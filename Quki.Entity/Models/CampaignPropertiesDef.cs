using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Base;

namespace Quki.Entity.Models
{
    public class CampaignPropertiesDef:EntityBase
    {
        [Key]
        public int CampaignDefPropertiesDefSeqID { get; set; }

        public string CampaignDefPropertiesName { get; set; }

        public short? CampaignPropertiesGroupID { get; set; }

        public string CampaignPropertiesFunction { get; set; }

        public short? CampaignPropertiesFunctionContent { get; set; }

        public short? CampaignPropertiesTypeID { get; set; }

        public string CampaignPropertiesValue { get; set; }

        public short CampaignPropertiesValueTypeID { get; set; }

        public string CampaignPropertiesImagePath { get; set; }

        public int? CurrencySeqID { get; set; }

        public short? DisplayOrderNumber { get; set; }

        public int? LanguageID { get; set; }

        public bool? IsDynamic { get; set; }

        public bool? IsActive { get; set; }

        public DateTime? StartDateTime { get; set; }

        public DateTime? EndDateTime { get; set; }

        public DateTime? CreatedDateTime { get; set; }

        public Guid? CreatedBy { get; set; }

        public Guid? UpdatedBy { get; set; }

        public DateTime? UpdateDateTime { get; set; }

    }
}
