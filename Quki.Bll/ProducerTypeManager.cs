using Microsoft.Extensions.DependencyInjection;
using System;
using Quki.Bll.Base;
using Quki.Dal.Abstract;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;
using Quki.Interface;

namespace Quki.Bll
{
    public class ProducerTypeManager : BllBase<ProducerType, ProducerTypeModel>, IProducerTypeService
    {
        public readonly IProducersRepository repo;
        public ProducerTypeManager(IServiceProvider service) : base(service)
        {
            repo = service.GetService<IProducersRepository>();
        }
        
    }
}
