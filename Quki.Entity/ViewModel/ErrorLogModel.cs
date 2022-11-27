using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Base;

namespace Quki.Entity.ViewModel
{
    public class ErrorLogModel : DtoBase
    {
        public string TerminalNo { get; set; }

        public string Message { get; set; }

        public string InnerException { get; set; }

        public string StackTrace { get; set; }
        public int? TypeID { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
