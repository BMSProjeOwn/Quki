using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Models
{
    public class RvcMenuItemDefViewModel
    {
    }

    public class GetMenuItems
    {
        public long slu_def_seq_view { get; set; }
        public long mi_master_def_seq { get; set; }
        public string mi_master_def_name { get; set; }
        public string mi_barcode_id { get; set; }
        public double mi_price { get; set; }
        public string slu_def_name { get; set; }
        public string mi_icon_path { get; set; }
        public string rvc_mi_second_name { get; set; }
        public string rvc_mi_third_name { get; set; }
        public int slu_priority { get; set; }
        public int? control_number { get; set; }
    }
}
