using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Base;

namespace Quki.Entity.DtoModels
{
    public class PlayListModel:DtoBase
    {

        [Key]
        public int PlayListSeqID { get; set; }
        public int? PlayLisID { get; set; }

        public int? PlayListTypeSeqID { get; set; }
        [MaxLength(450)]
        public string customer_def_seq { get; set; }
        [MaxLength(250)]
        public string PlayListName { get; set; }
        [MaxLength(250)]
        public string PlayListThumpImagePath { get; set; }
        public int? LanguageID { get; set; }
        public int? PlayListGroupID { get; set; }
        [MaxLength(250)]
        public string Remark { get; set; }

        public int? PlayOrderNumber { get; set; }
        public bool? IsRunAutomatic { get; set; }
        public int? PlayXSecond { get; set; }
        public DateTime? StartPlayHour { get; set; }
        public DateTime? StopPlayHour { get; set; }
        public bool? IsEachDay { get; set; }
        [MaxLength(50)]
        public string RunEachThisDays { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelet { get; set; }
        [MaxLength(250)]
        public string ReserveColumn { get; set; }
        public DateTime? CreatedOn { get; set; }
        [MaxLength(450)]
        public string CreatedBy { get; set; }
        public int? PlayListTypeGroupID { get; set; }
    }
}
