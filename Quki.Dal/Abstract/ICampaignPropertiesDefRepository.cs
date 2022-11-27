using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Entity.Models;

namespace Quki.Dal.Abstract
{
    public interface ICampaignPropertiesDefRepository : IGenericRepository<CampaignPropertiesDef>
    {

        //public List<CampaignPropertiesDef> GetAllProperties();
        //public bool AddProperty(CampaignPropertiesDef model);
        //public CampaignPropertiesDef GetPropertieByFunctionName(string FunctionName);
    }
}
