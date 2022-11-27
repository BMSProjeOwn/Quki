using Quki.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quki.Entity.DtoModels
{
    public class slu_Rvc_RelationModel:DtoBase
    {
        public long slu_rvc_relation_seq { get; set; }

        public long? rvc_seq { get; set; }

        public long? slu_seq { get; set; }
    }
}
