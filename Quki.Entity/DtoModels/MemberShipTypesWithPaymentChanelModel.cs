using System;
using System.ComponentModel.DataAnnotations;
using Quki.Entity.Base;
using Quki.Entity.Models;

namespace Quki.Entity.DtoModels
{
    public class MemberShipTypesWithPaymentChanelModel:DtoBase
    {
        [Key]
        public int MemberShipTypesWithPaymentChanelSeqID { get; set; }
        public int MemberShipTypeSeqID { get; set; }
        public virtual MemberShipType MemberShipType { get; set; }
        [MaxLength(250)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        [MaxLength(250)]
        public string ReferenceCode { get; set; }
        public int PamentChannelSeqID { get; set; }
        public string Status { get; set; }

        public DateTime? UpdatedOn { get; set; }
        [MaxLength(450)]
        public string UpdatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        [MaxLength(450)]
        public string CreatedBy { get; set; }
    }
}
