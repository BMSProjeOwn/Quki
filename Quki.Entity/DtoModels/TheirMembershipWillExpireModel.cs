using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Models;

namespace Quki.Entity.DtoModels
{
    public class TheirMembershipWillExpireModel
    {
        public int MemberShipTypeSeqID { get; set; }
        public int LastDay { get; set; }
        public int MailTemplateSeqID { get; set; }
        public List<listOfExpiredMembers> reporList { get; set; }
        public List<listOfExpiredMembers> reporListForSend { get; set; }

        public bool SelectAllCheck { get; set; }
        public bool ViewSendDetail { get; set; }
        public bool ViewShowMessageFaild { get; set; }
        public bool ViewShowMessageSuscces { get; set; }
    }
}
