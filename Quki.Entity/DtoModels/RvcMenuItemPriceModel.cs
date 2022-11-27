using Quki.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quki.Entity.DtoModels
{
    public class RvcMenuItemPriceModel:DtoBase
    {
        public long rvc_mi_price_seq { get; set; }

        public short? mi_price_number { get; set; }

        public double? mi_price { get; set; }

        public long? rvc_def_seq { get; set; }

        public long? mi_master_def_seq { get; set; }

        public long? rvc_mi_def_seq { get; set; }

        public long rvc_mi_price_no { get; set; }

        public DateTime? UpdateDate { get; set; }
    }
}
