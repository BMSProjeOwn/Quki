
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using Quki.Bll.Base;
using Quki.Dal.Abstract;
using Quki.Entity.DtoModels;
using Quki.Entity.DtoModels.ApiModels;
using Quki.Entity.Models;
using Quki.Interface;

namespace Quki.Bll
{
    public class CountryManager : BllBase<Counrty, CountryModel>, ICountryService
    {
        public readonly ICountryRepository repo;

        public CountryManager(IServiceProvider service) : base(service)
        {
            repo = service.GetService<ICountryRepository>();
        }
        public List<CountryItem> GetAllCountries() {
            return TGetList(w => w.Status == true).Select(s => new CountryItem
            {
                ID = s.CounrtySeqID,
                Name = s.CountryName
            }).ToList();
        }
        public List<SelectListItem> GetAllCountry() {
            return TGetList(w => w.Status == true).Select(s => new SelectListItem
            {
                Value = s.CounrtySeqID.ToString(),
                Text = s.CountryName
            }).ToList();
        }
        
    }
}
