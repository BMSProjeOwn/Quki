using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quki.Entity.Base;

namespace Quki.Entity.DtoModels.ApiModels
{
    public class CancelReasonApiModel:DtoBase
    {
        [Key]
        public short CancelReasonSeqID { get; set; }
        public string Remark { get; set; }
    }
}
