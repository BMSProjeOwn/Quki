using Quki.Entity.Base;

namespace Quki.Entity.DtoModels
{
    public class Condiment : DtoBase
    {

        public long rvc_mi_def_seq { get; set; }

        public long? rvc_def_seq { get; set; }

        public long? mi_master_def_seq { get; set; }

        public string? mi_master_def_name { get; set; }

        public string? mi_icon_path { get; set; }

        public double? mi_price{ get; set; }

    }
}
