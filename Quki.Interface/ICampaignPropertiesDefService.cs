using System.Collections.Generic;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;

namespace Quki.Interface
{
    public interface ICampaignPropertiesDefService : IGenericService<CampaignPropertiesDef, CampaignPropertiesDefModel>
    {

        public List<CampaignPropertiesDef> GetAllProperties();
        public bool AddProperty(CampaignPropertiesDef model);
        public CampaignPropertiesDef GetPropertieByFunctionName(string FunctionName);
    }
}
