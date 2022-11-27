using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quki.Entity.Base;

namespace Quki.Entity.Models
{
    public class CampingWithPropertiesRelationModel : DtoBase
    {
        public string ID { get; set; }
        public string CampaignDefPropertiesName { get; set; }
        public string CampaignPropertiesFunction { get; set; }
        public string CampaignPropertiesValue { get; set; }
    }
}
