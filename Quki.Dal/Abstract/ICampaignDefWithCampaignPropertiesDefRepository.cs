using System.Collections.Generic;
using Quki.Entity.Models;

namespace Quki.Dal.Abstract
{
    public interface ICampaignDefWithCampaignPropertiesDefRepository :IGenericRepository<CampaignDefWithCampaignPropertiesDef>
    {
        public List<CampaignDefWithCampaignPropertiesDef> GetRelationProperties(int CampaignDefSeqID);
        public List<CampingWithPropertiesRelationModel> SelectAllPropertiesByCampaignDefSeqIDSP(string sql);
    }
}
