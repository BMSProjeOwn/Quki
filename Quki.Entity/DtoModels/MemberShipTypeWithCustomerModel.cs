using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Base;
using Quki.Entity.Models;

namespace Quki.Entity.DtoModels
{
    public class MemberShipTypeWithCustomerModel:DtoBase
    {
        [Key]
        public int MemberShipTypeWithCustomerSeqID { get; set; }
        [MaxLength(450)]
        public string Id { get; set; }
        public int MemberShipTypeSeqID { get; set; }
        public int MemberShipTypePricePlaneSeqID { get; set; }
        public virtual MemberShipTypeModel MemberShipType { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        [MaxLength(500)]
        public string ShowDecriptionToUser { get; set; }
        public int? PaymentPeriod { get; set; }
        public float? DiscountRate { get; set; }
        public decimal Price { get; set; }
        public int CurrencySeqID { get; set; }

        public DateTime? UpdatedOn { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        public int? AutoRenewalCount { get; set; }
        public int? TrailPeriodDay { get; set; }
        public int? FreeDay { get; set; }
        public int? MembershipStatus { get; set; }
        public bool IsActive { get; set; }
        public List<MemberShipTypeWithCustomersPaymentChanelModel> MemberShipTypeWithCustomersPaymentChanel { get; set; }


    }
}
