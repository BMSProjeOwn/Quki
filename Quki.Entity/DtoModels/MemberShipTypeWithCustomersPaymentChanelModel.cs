using System.ComponentModel.DataAnnotations;
using Quki.Entity.Base;
using Quki.Entity.Models;

namespace Quki.Entity.DtoModels
{
    public class MemberShipTypeWithCustomersPaymentChanelModel : DtoBase
    {
        [Key]
        public int MemberShipTypeWithCustomersPaymentChanelSeqID { get; set; }
        [MaxLength(450)]
        public int MemberShipTypeWithCustomerSeqID { get; set; }// 
        public virtual MemberShipTypeWithCustomer MemberShipTypeWithCustomer { get; set; }// 

        public string ReferenceCode { get; set; }// 
        public int MemberShipWithPamentChannelSeqID { get; set; }
    
      
        public string ReferenceStatus { get; set; }
        public string data { get; set; }
    }
}
