using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Base;

namespace Quki.Entity.DtoModels
{
    public class MemberShipTypeCampaignModel:DtoBase
    {
        public int MemberShipTypePricePlaneSeqID { get; set; }
        public int CampaignDefSeqID { get; set; }
        public string Name { get; set; }
        public bool isActive { get; set; }
    }
}
