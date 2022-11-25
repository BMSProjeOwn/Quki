using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Models;

namespace Quki.Entity.DtoModels
{
    public class PaymentReportModel
    {
        public string UserID { get; set; }
        public int PaymentStatus { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public List<PaymentReport> reporList { get; set; }
    }

    
}
