using System.Collections.Generic;
using System.Linq;
using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Entity.DtoModels.ApiModels;
using Quki.Entity.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Quki.Dal.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Quki.Dal.Concrete.Entityframework.Repostories
{
    public class LanguageRepository : GenericRepository<Languages>, ILanguageRepository
    {
        public LanguageRepository(DbContext context) : base(context)
        {
           
        }
        //public List<LanguageItem> GetAllLanguages()
        //{
        //    return dbset.Where(w => w.Status == true).Select(s => new LanguageItem
        //    {
        //        ID = s.LanguageID,
        //        Name = s.Name,
        //        Code = s.CultureName
        //    }).ToList();
        //}

        //public List<SelectListItem> GetAllLanguages2()
        //{
        //    return dbset.Where(w => w.Status == true).Select(s => new SelectListItem
        //    {
        //        Value = s.LanguageID.ToString(),
        //        Text = s.Name
        //    }).ToList();
        //}
        
    }
}
