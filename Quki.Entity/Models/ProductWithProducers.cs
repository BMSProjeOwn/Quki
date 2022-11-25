using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Base;

namespace Quki.Entity.Models
{
    public class ProductWithProducers:EntityBase
    {
        [Key]
        public int ProductWithProducerSeqID { get; set; }
        public int ProductSeqID { get; set; }
        public int ProducerSeqID { get; set; }
        [MaxLength(250)]
        public string Name { get; set; }
        public int ProducerTypeSeqID { get; set; }
        [MaxLength(1000)]
        public string Description { get; set; }
        [MaxLength(250)]
        public string ImagePath { get; set; }
        [MaxLength(250)]
        public string ImageThumpPath { get; set; }
        public DateTime? ProducerDateTime { get; set; }
        public DateTime? UpdatedOn { get; set; }
        [MaxLength(450)]
        public string UpdatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        [MaxLength(450)]
        public string CreatedBy { get; set; }
    }
}
