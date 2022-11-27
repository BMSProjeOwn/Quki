using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Base;

namespace Quki.Entity.DtoModels
{
    public class CustomerTrackingTypeModel:DtoBase
    {
        [Key]
        public long CustomerTrackingTypeSeqID { get; set; }
        public int? TrackingTypeSeqID { get; set; }
        [MaxLength(450)]
        public string Customer_def_no { get; set; }
        [MaxLength(250)]
        public string Remark { get; set; }
        [MaxLength(500)]
        public int? RelatedTrackingSeqID { get; set; }
        public int? RelatedTrackingTypeID { get; set; }
        public bool IsShowUserScreen { get; set; }
        [MaxLength(250)]
        public string TrackingPagePathURL { get; set; }
        [MaxLength(250)]
        public string IPBlock { get; set; }
        public DateTime? EnterPageDateTime { get; set; }
        public DateTime? ExitPageDateTime { get; set; }
        public int? GroupID { get; set; }
        public int Minute { get; set; }
        public int? PlatformTypeID { get; set; }
        public DateTime FunctionEnterDateTime { get; set; }

        public DateTime FunctionExitDateTime { get; set; }


        [MaxLength(250)]
        public string EventFunctionName { get; set; }
        [MaxLength(250)]
        public string Country { get; set; }
        [MaxLength(250)]
        public string HostInformation { get; set; }
        public DateTime? UpdatedOn { get; set; }
        [MaxLength(450)]
        public string UpdatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        [MaxLength(450)]
        public string CreatedBy { get; set; }
    }
}
