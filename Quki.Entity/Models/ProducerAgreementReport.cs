using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Entity.Models
{
    public class ProducerAgreementReport
    {
        [Key]
        public string ReportID { get; set; }
        public string BeneficiaryName { get; set; }
        public string AgreementName { get; set; }
        public string ProductName { get; set; }
        public string TotalListen { get; set; }
        public string RoyaltyOercentage { get; set; }
        public string Earning { get; set; }
    }
}
