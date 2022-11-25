using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Entity.Models
{
    public class TheirMembershipWillExpire
    {
        [Key]
        public int MemberShipType { get; set; }

        public int LastDay { get; set; }
        public int MailTemplate { get; set; }
    }
}
