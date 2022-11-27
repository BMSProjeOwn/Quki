using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Base;

namespace Quki.Entity.Models
{
    public class MemberShipTypeWithCustomersPaymentChanel : EntityBase
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
