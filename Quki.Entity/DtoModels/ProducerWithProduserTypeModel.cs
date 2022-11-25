using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Base;

namespace Quki.Entity.DtoModels
{
    public class ProducerWithProduserTypeModel:DtoBase
    {   
        [Key]
        public int ProducerWithProducerTypeSeqID { get; set; }
        public int ProducerSeqID { get; set; }
        public int ProducerTypeSeqID { get; set; }
        public int ProducerID { get; set; }
        public bool IsActive { get; set; }
        public DateTime? UpdatedOn { get; set; }
        [MaxLength(450)]
        public string UpdatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        [MaxLength(450)]
        public string CreatedBy { get; set; }

    }
}
