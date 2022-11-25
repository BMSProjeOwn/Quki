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
    public class IntegrationPropertiesManager : BllBase<IntegrationProperties, Entity.DtoModels.IntegrationPropertiesModel>, IIntegrationPropertiesService
    {
        public readonly IIntegrationPropertiesRepository repo;
        public IntegrationPropertiesManager(IServiceProvider service) : base(service)
        {
            repo = service.GetService<IIntegrationPropertiesRepository>();
        }
        //public IntegrationModel GetIntegrationByIntegrationId(IntegrationTypes integration)
        //{
        //    IntegrationModel model = new IntegrationModel();
        //    model.Integration = integration;
        //    model.IntegrationProperties = new List<IntegrationPropertiesModel>();
        //    var result = TGetList(w => w.IntegrationSeqID == (long)integration && w.isActive == true).ToList();
        //    foreach (var item in result)
        //    {
        //        IntegrationPropertiesModel integrationPropertiesModel = new IntegrationPropertiesModel();
        //        integrationPropertiesModel.Name = item.Name;
        //        integrationPropertiesModel.Value = item.Value;
        //        model.IntegrationProperties.Add(integrationPropertiesModel);
        //    }
        //    return model;
        //}
    }
}
