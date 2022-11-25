using System.Collections.Generic;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;

namespace Quki.Interface
{
    public interface ICampaignDefWithCampaignPropertiesDefService : IGenericService<CampaignDefWithCampaignPropertiesDef, CampaignPropertiesDefModel>
    {
        public List<CampaignDefWithCampaignPropertiesDef> GetRelationProperties(int CampaignDefSeqID);
        public bool Update(CampaignDefWithCampaignPropertiesDef model);
        public bool AddNew(CampaignDefWithCampaignPropertiesDef model);
        public List<CampingWithPropertiesRelationModel> SelectAllPropertiesByCampaignDefSeqIDSP(int CampaignDefSeqID);
    }
}
