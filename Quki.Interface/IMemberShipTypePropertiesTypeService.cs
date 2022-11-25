using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;

namespace Quki.Interface
{
    public interface IMemberShipTypePropertiesTypeService : IGenericService<MemberShipTypePropertiesType, MemberShipTypePropertiesTypeModel>
    {

        public List<SelectListItem> GetAllPropertiesTypes();


        public ValueTypes GetValue(short? valueId);
    }
}
