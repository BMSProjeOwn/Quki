using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Quki.Entity.Models
{
    [Keyless]
    public class CampaingReport
    {
        
        public string CampaignDefName { get; set; }
        public string CouponDefCode { get; set; }
        public string UseableCount { get; set; }
        public string DiscountPrice { get; set; }
        public int cuponcount { get; set; }
        public DateTime StartValidDatetime { get; set; }
        public DateTime EndValidDatetime { get; set; }
    }
}
