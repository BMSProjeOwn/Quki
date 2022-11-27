using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Base;

namespace Quki.Entity.DtoModels
{
    public class CountryModel : DtoBase
    {
        public int CounrtySeqID { get; set; }
        public string Name { get; set; }

        public bool IsChecked { get; set; }
    }
}
