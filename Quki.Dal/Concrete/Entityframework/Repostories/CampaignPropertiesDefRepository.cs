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
    public class CampaignPropertiesDefRepository : GenericRepository<CampaignPropertiesDef>, ICampaignPropertiesDefRepository
    {
        public CampaignPropertiesDefRepository(DbContext context):base(context)
        {

        }
        //public List<CampaignPropertiesDef> GetAllProperties()
        //{

        //    var list = dbset.Where(x => x.IsActive == true).ToList();

        //    return list;
        //}

        //public bool AddProperty(CampaignPropertiesDef model)
        //{
        //    TAdd(model);
        //    return true;
        //}

        //public CampaignPropertiesDef GetPropertieByFunctionName(string FunctionName)
        //{

        //    var list = dbset.Where(x => x.CampaignPropertiesFunction == FunctionName).FirstOrDefault();

        //    return list;
        //}

    }
}
