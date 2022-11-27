using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Quki.Dal.Abstract;
using Quki.Entity.Models;

namespace Quki.Dal.Concrete.Entityframework.Repostories
{
    public class MemberShipTypePropertiesTypeRepository : GenericRepository<MemberShipTypePropertiesType>, IMemberShipTypePropertiesTypeRepository
    {
        public MemberShipTypePropertiesTypeRepository(DbContext context) : base(context)
        {

        }
        //public List<SelectListItem> GetAllPropertiesTypes()
        //{
        //    return dbset.Where(w => w.Status == true).Select(s => new SelectListItem
        //    {
        //        Value = s.MemberShipTypePropertiesId.ToString(),
        //        Text = s.MemberShipTypePropertiesName,
        //    }).ToList();
        //}


        //public ValueTypes GetValue(short? valueId)
        //{
        //    return context.Set<ValueTypes>().Where(x => x.ValueTypeSeqID == valueId && x.IsActive == true).FirstOrDefault();
        //}
    }
}
