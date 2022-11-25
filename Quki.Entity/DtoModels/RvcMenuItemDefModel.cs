using Quki.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quki.Entity.DtoModels
{
    public class RvcMenuItemDefModel:DtoBase
    {

        public long rvc_mi_def_seq { get; set; }

        public long? rvc_def_seq { get; set; }

        public long? mi_master_def_seq { get; set; }

        public string? mi_master_def_name { get; set; }

        public string? rvc_mi_second_name { get; set; }

        public string? rvc_mi_third_name { get; set; }

        public long? slu_seq { get; set; }

        public short? slu_priority { get; set; }

        public string? mi_master_def_type { get; set; }

        public byte? mi_is_active { get; set; }

        public byte? mi_is_sale { get; set; }

        public byte? mi_is_weight { get; set; }

        public byte? mi_is_weight_tare { get; set; }

        public double? mi_weight_tare { get; set; }

        public byte? is_required_condiment { get; set; }

        public string? mi_icon_path { get; set; }

        public long? mi_class_def_seq { get; set; }

        public long? print_class_def_seq { get; set; }

        public long? main_group_def_seq { get; set; }

        public long? sub_group_def_seq { get; set; }

        public long? condiment_profile_def_seq { get; set; }

        public long? condiment_main_group_def_seq { get; set; }

        public long? mi_stock_group_seq { get; set; }

        public byte? mi_is_count_promt { get; set; }

        public long? mi_promt_count { get; set; }

        public long? mi_master_def_number { get; set; }

        public long rvc_mi_def_no { get; set; }

        public DateTime? UpdateDate { get; set; }

        public byte? IsFree { get; set; }
    }
}
