using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Quki.Dal.Abstract;
using Quki.Dal.Concrete.Entityframework.Context;

namespace Quki.Dal.Concrete.Entityframework.Repostories
{
    public class CurrencyRepository : GenericRepository<Quki.Entity.Models.Currency>, ICurrencyRepository
    {
        public CurrencyRepository(DbContext context):base(context)
        {
            
        }
        //public List<SelectListItem> GetAllCurrency()
        //{
        //    return dbset.Select(s => new SelectListItem
        //    {
        //        Value = s.CurrencyID.ToString(),
        //        Text = s.CurrencyName
        //    }).ToList();
        //}
    }
}
