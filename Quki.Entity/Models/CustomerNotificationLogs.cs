using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Base;

namespace Quki.Entity.Models
{
    public class CustomerNotificationLogs:EntityBase
    {
        [Key]
        public long CustomerNotificationLogsSeqID { get; set; }
        public int? NotificationTemplatesSeqID { get; set; }
        public long? customer_def_seq { get; set; }
        public string StatusMesaages { get; set; }
        public short? Status { get; set; }
        public string MessageContent { get; set; }
        public string BCCEmail { get; set; }
        public string CCEmail { get; set; }
        public string Email { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
