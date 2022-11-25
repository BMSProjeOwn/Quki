using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Entity.Models
{
    public class MessagesNotificationsTemplate
    {
        [Key]
        public int MessagesNotificationSeqID { get; set; }
        public int NotificationTemplatesSeqID { get; set; }
        public NotificationTemplates NotificationTemplates { get; set; }
        public int MessagesSeqID { get; set; }
        public Messages Messages { get; set; }
        public int CategorySeqID { get; set; }
      
        public int IsDeleted { get; set; }
        [MaxLength(450)]
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        [MaxLength(450)]
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
