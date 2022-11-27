using Microsoft.Extensions.DependencyInjection;
using System;
using Quki.Bll.Base;
using Quki.Dal.Abstract;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;
using Quki.Interface;

namespace Quki.Bll
{
    public class ProducerWithProduserTypeManager : BllBase<ProducerWithProduserType, ProducerWithProduserTypeModel>, IProducerWithProduserTypeService
    {
        public readonly IProducerWithProduserTypeRepository repo;
        public ProducerWithProduserTypeManager(IServiceProvider service) : base(service)
        {
            repo = service.GetService<IProducerWithProduserTypeRepository>();
        }
    }
}
