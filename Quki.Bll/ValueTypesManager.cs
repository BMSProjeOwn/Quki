using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using Quki.Bll.Base;
using Quki.Dal.Abstract;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;
using Quki.Interface;

namespace Quki.Bll
{
    public class ValueTypesManager : BllBase<ValueTypes, ValueTypesModel>, IValueTypesService
    {
        public readonly IValueTypesRepository repo;
        public ValueTypesManager(IServiceProvider service) : base(service)
        {
            repo = service.GetService<IValueTypesRepository>();
        }
        public List<SelectListItem> GetAllValueTypes()
        {
            return TGetList(w => w.IsActive == true).Select(s => new SelectListItem
            {
                Value = s.ValueTypeSeqID.ToString(),
                Text = s.ValueTypeSecondName,
            }).ToList();
        }


        public ValueTypes GetValue(short? valueId)
        {
            return TGetList(x => x.ValueTypeSeqID == valueId && x.IsActive == true).FirstOrDefault();
        }
    }
}
