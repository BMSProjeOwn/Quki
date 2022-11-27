
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Entity.DtoModels.ApiModels;
using Quki.Entity.Models;

namespace Quki.Dal.Abstract
{
    public interface ICountryRepository : IGenericRepository<Counrty>
    {
        //public List<CountryItem> GetAllCountries();
        //public List<SelectListItem> GetAllCountry();
        
    }
}
