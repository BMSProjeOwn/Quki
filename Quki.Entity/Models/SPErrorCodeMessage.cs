using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Entity.Models
{
    public class SPErrorCodeMessage
    {
        [Key]
        public int SPErrorCodeDefSeq { get; set; }
        public string BankCode { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorType { get; set; }
        public string Remark { get; set; }
    }
}
