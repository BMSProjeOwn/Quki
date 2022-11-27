using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Entity.Models;

namespace Quki.Dal.Abstract
{
    public interface IValueTypesRepository : IGenericRepository<ValueTypes>
    {
        //public List<SelectListItem> GetAllValueTypes();
        //public ValueTypes GetValue(short? valueId);
    }
}
