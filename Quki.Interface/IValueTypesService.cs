using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;

namespace Quki.Interface
{
    public interface IValueTypesService : IGenericService<ValueTypes, ValueTypesModel>
    {
        public List<SelectListItem> GetAllValueTypes();
        public ValueTypes GetValue(short? valueId);
    }
}
