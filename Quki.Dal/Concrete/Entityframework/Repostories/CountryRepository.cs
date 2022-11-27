
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Quki.Dal.Abstract;
using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Entity.DtoModels.ApiModels;
using Quki.Entity.Models;

namespace Quki.Dal.Concrete.Entityframework.Repostories
{
    public class CountryRepository : GenericRepository<Counrty>, ICountryRepository
    {
        public CountryRepository(DbContext context):base(context)
        {
            
        }
        //public List<CountryItem> GetAllCountries()
        //{
        //    return dbset.Where(w => w.Status == true).Select(s => new CountryItem
        //    {
        //        ID = s.CounrtySeqID,
        //        Name = s.CountryName
        //    }).ToList();
        //}


        //public List<SelectListItem> GetAllCountry()
        //{
        //    return dbset.Where(w => w.Status == true).Select(s => new SelectListItem
        //    {
        //        Value = s.CounrtySeqID.ToString(),
        //        Text = s.CountryName
        //    }).ToList();
        //}
    }
}
