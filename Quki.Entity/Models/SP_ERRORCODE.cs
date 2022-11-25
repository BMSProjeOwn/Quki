using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Entity.Models
{
    public class SP_ERRORCODE
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(20)]
        public string BANK_CODE { get; set; }
        [MaxLength(20)]
        public string ERROR_CODE { get; set; }

        public string ERROR_DESC { get; set; }
        [MaxLength(20)]
        public string ERROR_TYPE { get; set; }

        public string ACIKLAMA { get; set; }
    }
}
