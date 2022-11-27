using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Base;

namespace Quki.Entity.DtoModels.ApiModels
{
    public class LanguageApiModel : DtoBase
    {
        public List<LanguageItem> Languages { get; set; }
    }

    public class LanguageItem
    {
        public int? ID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
