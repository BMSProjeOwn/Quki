using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Entity.Models
{
    public class ListeningRateReportByUser
    {
        [Key]
        public string ID { get; set; }
        public string UserName { get; set; }
        public string ProductName { get; set; }
        public int ProductImageSeqID { get; set; }
        public string MediaTypeName { get; set; }
        public int UserTotalListen { get; set; }
        public string UserID { get; set; }
        public string MemberShipTypeName { get; set; }
    }
}
