using System;
using System.ComponentModel.DataAnnotations;
using Quki.Entity.Base;
using Quki.Entity.Models;

namespace Quki.Entity.DtoModels
{
    public class UserProtoectInformationModel:DtoBase
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
