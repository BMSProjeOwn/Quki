using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Base;
using Quki.Entity.Models;

namespace Quki.Entity.DtoModels
{
    public class MessagesModel:DtoBase
    {
        [Key]
        public int MessagesSeqID { get; set; }
        public int MessageID { get; set; }
        [MaxLength(250)]
        public string MessageName { get; set; }
        [MaxLength(250)]
        public string MessageContent { get; set; }
        public bool IsActive { get; set; }

        public Int16? MessageTypeID { get; set; }
        public int MessageTypeGroupID { get; set; }
        public int LanguageID { get; set; }
        [MaxLength(250)]
        public string ThumpMessagePath { get; set; }
        [MaxLength(450)]
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        [MaxLength(450)]
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public List<MessagesNotificationsTemplate> MessagesNotificationsTemplate { get; set; }
    }
}
