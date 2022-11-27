using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Entity.DtoModels.ApiModels
{
    public class CountryApiModel
    {
        public List<CountryItem> Countries { get; set; }
    }

    public class CountryItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }


}
