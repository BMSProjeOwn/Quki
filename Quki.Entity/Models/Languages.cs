using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Base;

namespace Quki.Entity.Models
{
    public class Languages:EntityBase
    {
        [Key]
        public int LanguageSeqID { get; set; }
        public int? LanguageID { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string CultureName { get; set; }
        [MaxLength(150)]
        public string ImagePath { get; set; }
        public bool SetDefaultLanguage { get; set; }
        public bool Status { get; set; }

    }
}
