
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Quki.Entity.DtoModels;
using Quki.Entity.DtoModels.ApiModels;
using Quki.Entity.Models;

namespace Quki.Interface
{
    public interface ICountryService : IGenericService<Counrty, CountryModel>
    {
        public List<CountryItem> GetAllCountries();
        public List<SelectListItem> GetAllCountry();
        
    }
}
