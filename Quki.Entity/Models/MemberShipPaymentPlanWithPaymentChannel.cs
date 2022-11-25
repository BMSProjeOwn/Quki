using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Base;

namespace Quki.Entity.Models
{
    public class MemberShipPaymentPlanWithPaymentChannel:EntityBase
    {
        [Key]
        public int MemberShipWithPaymentChannelSeqID { get; set; }
        public int MemberShipTypePricePlaneSeqID { get; set; }
        public int MemberShipTypeSeqID { get; set; }

        public int PamentChannelSeqID { get; set; }

        [MaxLength(250)]
        public string ReferenceCode { get; set; }

        public DateTime? UpdatedOn { get; set; }
        [MaxLength(450)]
        public string UpdatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        [MaxLength(450)]
        public string CreatedBy { get; set; }
        public Int16 DisplayOrderNumber { get; set; }
        public virtual MembershipTypePricePlane MembershipTypePricePlane { get; set; }





    }
}
