using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Entity.Models
{
    public class SP_BANK_BIN
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(20)]
        public string BANK_CODE { get; set; }
        [MaxLength(20)]
        public string BIN_VALUE { get; set; }
        [MaxLength(20)]
        public string TYPE { get; set; }
        [MaxLength(20)]
        public string SUB_TYPE { get; set; }
        [MaxLength(20)]
        public string VIRTUAL { get; set; }
        [MaxLength(20)]
        public string PREPAID { get; set; }
        [MaxLength(250)]
        public string MODIFIED_BY { get; set; }
    
        public DateTime? MODIFIED_DATE { get; set; }
    }
}
