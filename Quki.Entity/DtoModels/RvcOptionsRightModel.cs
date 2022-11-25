using Quki.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quki.Entity.DtoModels
{
    public class RvcOptionsRightModel:DtoBase
    {
        public long rvc_options_right_def_seq { get; set; }

        public long? rvc_def_seq { get; set; }

        public long? rvc_options_def_seq { get; set; }

        public byte? rvc_options_def_status { get; set; }

        public string? rvc_options_def_code { get; set; }

        public long rvc_options_right_def_no { get; set; }

        public DateTime? UpdateDate { get; set; }
    }
}
