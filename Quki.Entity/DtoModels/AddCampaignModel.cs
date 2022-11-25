using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Base;

namespace Quki.Entity.DtoModels
{
    public class AddCampaignModel : DtoBase
    {
        [Key]
        public int CampaignDefSeqID { get; set; }

        public int? CampaignDefID { get; set; }

        public string CampaignDefName { get; set; }

        public string CampaignDefCode { get; set; }

        public short? CampaignDefTypeID { get; set; }

        public string CampaignDefImagePath { get; set; }

        public short? CampaignDefGroupID { get; set; }

        public string CampaignDefRemark { get; set; }

        public short? CampaignDefDisplayOrderNumber { get; set; }

        public DateTime? StartCampaignDateTime { get; set; }

        public DateTime? EndCampaignDefDateTime { get; set; }

        public bool IsMonday { get; set; }

        public bool IsTuesday { get; set; }

        public bool IsWednesday { get; set; }

        public bool IsThursday { get; set; }

        public bool IsFriyday { get; set; }

        public bool IsSaturday { get; set; }

        public bool IsSunday { get; set; }

        public DateTime? TriggerDateTime { get; set; }

        public int LanguageID { get; set; }

        public short Status { get; set; }

        public bool IsActive { get; set; }

        public bool IsShowScreen { get; set; }

        public string ShowContentToUser { get; set; }

        public string ShowInstractionToUser { get; set; }

        public DateTime? CreatedDateTime { get; set; }

        public Guid? CreatedBy { get; set; }

        public Guid? UpdatedBy { get; set; }

        public DateTime? UpdateDateTime { get; set; }
    }
}
