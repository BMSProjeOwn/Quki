using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Base;

namespace Quki.Entity.Models
{
    public class Avatars:EntityBase
    {
        [Key]
        public int AvatarsSeqID { get; set; }

        public string AvatarsName { get; set; }

        public string AvatarImagePath { get; set; }

        public short? OrderNumber { get; set; }

        public bool? IsActive { get; set; }

        public short? TypeID { get; set; }

        public short? GroupID { get; set; }

        public Guid? CreatedBy { get; set; }

        public DateTime? CreatedDateTime { get; set; }

        public Guid? UpdatedBy { get; set; }

        public DateTime? UpdateDatetime { get; set; }

    }
}
