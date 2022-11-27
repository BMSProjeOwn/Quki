using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Base;

namespace Quki.Entity.Models
{
    public class NotificationTemplatess:EntityBase
    {
        [Key]
        public int NotificationTemplatesSeqID { get; set; }

        public short? NotificationTemplateTypeID { get; set; }

        public short? NotificationTemplateGroupID { get; set; }

        public int? LanguageID { get; set; }

        public string NotificationTemplateName { get; set; }

        public string NotificationHeader { get; set; }

        public string NotificationContent { get; set; }

        public string NotificationInstraction { get; set; }

        public string NotificationFooter { get; set; }

        public short? NotificationlTypeID { get; set; }

        public string ThumpImagePath { get; set; }

        public string BackgroundIamagePath { get; set; }

        public bool İsActive { get; set; }

        public short? RepeatCounter { get; set; }

        public bool? IsCCAktive { get; set; }

        public bool? IsBCCActive { get; set; }

        public string AdminNotificationValue { get; set; }

        public string AdminEmail { get; set; }

        public string AdminEmail2 { get; set; }

        public string WhatsupInformation { get; set; }

        public string PhoneNumber { get; set; }

        public string WebAdress { get; set; }

        public Guid? UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public Guid? CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }
    }
}
