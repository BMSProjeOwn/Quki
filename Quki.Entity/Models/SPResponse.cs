using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Entity.Models
{
    public class SPResponse
    {
        [Key]
        public string ID { get; set; }
        public bool Result { get; set; }
        public int ResultCode { get; set; }
        public string ResultMessage { get; set; }
    }
}
