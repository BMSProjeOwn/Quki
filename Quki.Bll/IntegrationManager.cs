using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using Quki.Bll.Base;
using Quki.Dal.Abstract;
using Quki.Entity.Models;
using Quki.Interface;

namespace Quki.Bll
{
    public class IntegrationManager : BllBase<Integration, Quki.Entity.DtoModels.IntegrationModel>, IIntegrationService

    {
        public readonly IIntegrationRepository repo;
        public IntegrationManager(IServiceProvider service) : base(service)
        {
            repo = service.GetService<IIntegrationRepository>();
        }

    }
}
