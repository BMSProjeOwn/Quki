using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Base;

namespace Quki.Entity.Models
{
    public class UserProtoectInformation:EntityBase
    {
        [Key]
        public int UserProtoectInformationSeqID { get; set; }
        public int ProtectionInformationSeqID { get; set; }
        public virtual ProtoectInformation ProtoectInformation { get; set; }
        [MaxLength(450)]
        public string UserId { get; set; }

        public bool IsConfirmation { get; set; }
        public string Comment { get; set; }
        public string Remark { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public DateTime? CreatedOn { get; set; }



    }
}
