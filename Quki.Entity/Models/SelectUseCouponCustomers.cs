using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Quki.Entity.Models
{
    public class SelectUseCouponCustomers
    {
        [Key]
        public string Name { get; set; }
        public string SurName { get; set; }
        public string CouponDefCode { get; set; }
        public string MemberShipTypeName { get; set; }
        public string Email { get; set; }
    }
}
