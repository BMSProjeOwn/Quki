using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Base;

namespace Quki.Entity.ViewModel
{
    public class VisitorCommentsModel:DtoBase
    {

        public int VisitorCommentsSeqId { get; set; }
        public int ComantSeqID { get; set; }
        public string Name { get; set; }
        public string ProductName { get; set; }
        public string CreatedBy { get; set; }

        public string VisitorEmail { get; set; }
        public string Comment { get; set; }
        public decimal? CustomerRaiting { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool ShowOnHomePage { get; set; }
        public Int16 DisplayOrderID { get; set; }
    }
}
