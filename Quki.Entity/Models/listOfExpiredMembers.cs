using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Entity.Models
{
    public class listOfExpiredMembers
    {
        [Key]
        public string ID { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MemberShipTypeName { get; set; }
        public string MemberStartDate { get; set; }
        public string MemberEndDate { get; set; }
        public string TotalAmountPayable { get; set; }
        public string TotalPayment { get; set; }
        public string Email { get; set; }
        public string customer_def_seq { get; set; }
        public bool SendMailCheck { get; set; }
    }
}
