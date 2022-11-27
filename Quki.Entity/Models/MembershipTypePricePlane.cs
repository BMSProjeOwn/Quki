using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Base;

namespace Quki.Entity.Models
{
    public class MembershipTypePricePlane:EntityBase
    {
        [Key]
        public int MemberShipTypePricePlaneSeqID { get; set; }
        public int MemberShipTypeSeqID { get; set; }
        public string PlaneName { get; set; }
        public virtual MemberShipType MemberShipType { get; set; }
        public decimal Price { get; set; }
        public decimal? BaseCurrencyPrice { get; set; }
        [MaxLength(250)]
        public string ShowCommentToUser { get; set; }
        public int? CurrencyID { get; set; }
        public int PaymentPeriod { get; set; }
        public int? NumberOfInstallments { get; set; }
        public DateTime? PaymentDay { get; set; }
        [MaxLength(250)]
        public string PaymentComment { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? RunAccordingToStartEndDate { get; set; }
        public DateTime? UpdatedOn { get; set; }
        [MaxLength(450)]
        public string UpdatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        [MaxLength(450)]
        public string CreatedBy { get; set; }
        public Int16 DisplayOrderNumber { get; set; }
        public int? AutoRenewalCount { get; set; }
        public int? TrailPeriodDay { get; set; }
        public int? FreeDay { get; set; }
        public bool? ShowCustomers { get; set; }
        public bool Status { get; set; }
        public List<MemberShipPaymentPlanWithPaymentChannel> MemberShipPaymentPlanWithPaymentChannel { get; set; }
        public short? MemberShipPricePlaneType { get; set; }

    }
}
