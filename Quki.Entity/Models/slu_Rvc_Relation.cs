using Quki.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quki.Entity.Models
{
    public class slu_Rvc_Relation: EntityBase
    {
        [Key]
        public long slu_rvc_relation_seq { get; set; }

        public long? rvc_seq { get; set; }

        public long? slu_seq { get; set; }
    }
}
