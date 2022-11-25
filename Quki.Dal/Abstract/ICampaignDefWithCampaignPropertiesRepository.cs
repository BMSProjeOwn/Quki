using System.Collections.Generic;
using Quki.Entity.Models;

namespace Quki.Dal.Abstract
{
    public interface ICampaignDefWithCampaignPropertiesRepository
    {
        //public List<CampaignDefWithCampaignPropertiesDef> GetRelationProperties(int CampaignDefSeqID);
        //public bool Update(CampaignDefWithCampaignPropertiesDef model);
        //public bool AddNew(CampaignDefWithCampaignPropertiesDef model);
        public List<CampingWithPropertiesRelationModel> SelectAllPropertiesByCampaignDefSeqIDSP(string sql);
    }
}
