using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Models;

namespace Quki.Entity.DtoModels
{
    public class CampaignReportModel
    {
        public int CampaignDefSeqID { get; set; }
        public short? CampaignDefTypeID { get; set; }
        public string CampaignDefName { get; set; }
        public string CampaignDefCode { get; set; }
        public bool showDetail { get; set; }
        public string input { get; set; }
        public List<CampaingReport> CampaingReport { get; set; }
        public List<SelectUseCouponCustomers> SelectUseCouponCustomers { get; set; }



    }
}
