using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Base;

namespace Quki.Entity.DtoModels
{
    public class CampaignPropertiesDefModel : DtoBase
    {
        public int CampaignDefPropertiesDefSeqID { get; set; }
        public int CampaignDefSeqID { get; set; }
        public string CampaignDefPropertiesName { get; set; }
        public string CampaignPropertiesValue { get; set; }
        public string ValueTypeName { get; set; }
        public bool Status { get; set; }
        public short CampaignPropertiesValueTypeID { get; set; }
        public bool IsDynamic { get; set; }
        public bool IsActive { get; set; }

    }
}
