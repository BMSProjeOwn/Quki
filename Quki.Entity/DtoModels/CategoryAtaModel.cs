using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Entity.DtoModels
{
    public class CategoryAtaModel
    {
        public int CategorySeqID { get; set; }
        public string CategoryName { get; set; }
        public bool isHas { get; set; }

        public bool Status { get; set; }
    }
}
