using Quki.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quki.Entity.Models
{
    public class MenuItemBarcodeDef:EntityBase
    {
        [Key]
        public long mi_barcode_def_seq { get; set; }

        public string? mi_barcode_id { get; set; }

        public long? mi_master_def_seq { get; set; }

        public string? barcode_type { get; set; }

        public long mi_barcode_def_no { get; set; }

        public DateTime? Updatedate { get; set; }

        public string? brand_name { get; set; }

    }
}
