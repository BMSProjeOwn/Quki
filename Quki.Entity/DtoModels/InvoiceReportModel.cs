using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Base;

namespace Quki.Entity.DtoModels
{
    public class InvoiceReportModel
    {
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public List<SalesModel> Detail { get; set; }
    }
    public class SalesModel : DtoBase
    {
        public long SalesSeqID { get; set; }
        public string DocumentNumber { get; set; }
        public decimal SalesTotal { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
    }

}
