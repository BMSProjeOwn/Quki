using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quki.Bll.Base;
using Quki.Dal.Abstract;
using Quki.Entity.DtoModels;
using Quki.Entity.DtoModels.ApiModels;
using Quki.Entity.Models;
using Quki.Bll;
using Quki.Interface;

namespace Quki.Bll
{
    public class AttributeStaticManager : BllBase<AttributeStatic, AttributeStaticModel>, IAttributeStaticService
    {
        public readonly IAttributeStaticRepository attributeStaticRepository;

        public AttributeStaticManager(IServiceProvider service) :base(service)
        {
            attributeStaticRepository = service.GetService<IAttributeStaticRepository>();
        }

    }
}
