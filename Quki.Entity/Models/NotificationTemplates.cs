using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Base;

namespace Quki.Entity.Models
{
    public class NotificationTemplates : EntityBase
    {
        [Key]
        public int NotificationTemplatesSeqID { get; set; }
        [MaxLength(250)]
        public string NotificationHeader { get; set; }
        public string NotificationContent { get; set; }
        public string NotificationInstraction { get; set; }
        public string NotificationFooter { get; set; }
        public Int16? NotificationlTypeID { get; set; }
        public bool IsActive { get; set; }
        public Int16? NotificationTemplateGroupID { get; set; }
        [MaxLength(250)]
        public string ThumpImagePath { get; set; }

        public bool IsCCAktive { get; set; }
        public bool IsBCCActive { get; set; }
        public int LanguageID { get; set; }
        [MaxLength(150)]
        public string AdminNotificationValue { get; set; }
        [MaxLength(150)]
        public string AdminEmail { get; set; }
        [MaxLength(150)]
        public string AdminEmail2 { get; set; }
        [MaxLength(150)]
        public string WhatsupInformation { get; set; }
        [MaxLength(15)]
        public string PhoneNumber { get; set; }
        [MaxLength(150)]
        public string WebAdress { get; set; }
        [MaxLength(450)]
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        [MaxLength(450)]
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public List<MessagesNotificationsTemplate> MessagesNotificationsTemplate { get; set; }
    }
}
