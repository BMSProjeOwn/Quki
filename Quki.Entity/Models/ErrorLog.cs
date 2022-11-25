using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Base;

namespace Quki.Entity.Models
{
    public class ErrorLog: EntityBase
    {
        [Key]
        public int ErrorLogSeqID { get; set; }
        [MaxLength(450)]
        public string TerminalNo { get; set; }

        public string Message { get; set; }

        public string InnerException { get; set; }
    
        public string StackTrace { get; set; }
        public int? TypeID { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
