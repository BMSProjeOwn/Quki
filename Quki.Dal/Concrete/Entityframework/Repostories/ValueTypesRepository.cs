using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Quki.Dal.Abstract;
using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Entity.Models;

namespace Quki.Dal.Concrete.Entityframework.Repostories
{
    public class ValueTypesRepository : GenericRepository<ValueTypes>, IValueTypesRepository
    {
        public ValueTypesRepository(DbContext context) : base(context)
        {
            
        }
        //public List<SelectListItem> GetAllValueTypes()
        //{
        //    return dbset.Where(w => w.IsActive == true).Select(s => new SelectListItem
        //    {
        //        Value = s.ValueTypeSeqID.ToString(),
        //        Text = s.ValueTypeSecondName,
        //    }).ToList();
        //}


        //public ValueTypes GetValue(short? valueId)
        //{
        //    return dbset.Where(x => x.ValueTypeSeqID == valueId && x.IsActive == true).FirstOrDefault();
        //}
    }
}
