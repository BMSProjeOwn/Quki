
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quki.Dal.Abstract;
using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Entity.Models;

namespace Quki.Dal.Concrete.Entityframework.Repostories
{
    public class IntegrationPropertiesRepository : GenericRepository<IntegrationProperties>, IIntegrationPropertiesRepository
    {
        public IntegrationPropertiesRepository(DbContext context):base(context)
        {

        }
        //public IntegrationModel GetIntegrationByIntegrationId(IntegrationTypes integration)
        //{
        //    IntegrationModel model = new IntegrationModel();
        //    model.Integration = integration;
        //    model.IntegrationProperties = new List<IntegrationPropertiesModel>();
        //    var result = dbset.Where(w => w.IntegrationSeqID == (long)integration && w.isActive == true).ToList();
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
