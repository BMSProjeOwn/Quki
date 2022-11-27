using Quki.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quki.Entity.DtoModels
{
    public class SluDefModel:DtoBase
    {
        public long slu_def_seq { get; set; }

        public string? slu_def_name { get; set; }

        public long? touch_screen_style_def_seq { get; set; }

        public long? slu_def_no { get; set; }

        public long? parent_slu_def_no { get; set; }

        public string? slu_type { get; set; }

        public int? slu_type_slu_status { get; set; }

        public string? slu_type_slu_name_place { get; set; }

        public int? slu_type_slu_position_x { get; set; }

        public int? slu_type_slu_position_y { get; set; }

        public int? slu_type_slu_hight { get; set; }

        public int? slu_type_slu_width { get; set; }

        public string? slu_type_slu_image { get; set; }

        public string? slu_type_slu_image_place { get; set; }

        public int? slu_type_slu_image_place_status { get; set; }

        public string? slu_type_slu_back_color { get; set; }

        public string? slu_type_slu_back_color_extra { get; set; }

        public string? slu_type_slu_back_color_change_to_time { get; set; }

        public int? slu_type_slu_time_to_change_back_color { get; set; }

        public string? slu_type_slu_font_color { get; set; }

        public string? slu_type_slu_font_type { get; set; }

        public double? slu_type_slu_font_size { get; set; }

        public string? slu_type_slu_font_style { get; set; }

        public string? slu_type_slu_form_color { get; set; }

        public string? slu_type_slu_single_click { get; set; }

        public string? slu_type_slu_double_click_func { get; set; }

        public string? slu_type_slu_right_click_func { get; set; }

        public string? slu_type_slu_on_enter_click_func { get; set; }

        public int? control_type_number { get; set; }

        public string? control_type_name { get; set; }

        public int? control_number { get; set; }

        public DateTime? UpdateDate { get; set; }

      
    }
}
