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
    public class MemberShipTypePropertiesTypeManager : BllBase<MemberShipTypePropertiesType, MemberShipTypePropertiesTypeModel>, IMemberShipTypePropertiesTypeService
    {
        public readonly IMemberShipTypePropertiesTypeRepository repo;
        public readonly IValueTypesRepository valueTypesRepository;
        public MemberShipTypePropertiesTypeManager(IServiceProvider service) : base(service)
        {
            repo = service.GetService<IMemberShipTypePropertiesTypeRepository>();
            valueTypesRepository = service.GetService<IValueTypesRepository>();
        }
        public List<SelectListItem> GetAllPropertiesTypes()
        {
            return TGetList(w => w.Status == true).Select(s => new SelectListItem
            {
                Value = s.MemberShipTypePropertiesId.ToString(),
                Text = s.MemberShipTypePropertiesName,
            }).ToList();
        }


        public ValueTypes GetValue(short? valueId)
        {
            return valueTypesRepository.TGetList(x => x.ValueTypeSeqID == valueId && x.IsActive == true).FirstOrDefault();
        }
    }
}
