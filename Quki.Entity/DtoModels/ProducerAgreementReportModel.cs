using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Models;

namespace Quki.Entity.DtoModels
{
    public class ProducerAgreementReportModel
    {
        public string ReportID { get; set; }
        public string BeneficiaryName { get; set; }
        public string AgreementName { get; set; }
        public string ProductName { get; set; }
        public string TotalListen { get; set; }
        public string RoyaltyOercentage { get; set; }
        public string Earning { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public int ProducerSeqID { get; set; }

        public long ProducerAgreementSeqID { get; set; }

        public List<ProducerAgreementReport> ProducerAgreementReport { get; set; }

    }
}
