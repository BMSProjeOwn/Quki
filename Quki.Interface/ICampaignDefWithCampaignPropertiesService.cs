using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quki.Entity.DtoModels;
using Quki.Entity.DtoModels.ApiModels;
using Quki.Entity.Models;

namespace Quki.Interface
{
    public interface ICampaignDefWithCampaignPropertiesService : IGenericService<CampaignDefWithCampaignPropertiesDef, CampingWithPropertiesRelationModel>
    {
        public List<CampaignDefWithCampaignPropertiesDef> GetRelationProperties(int CampaignDefSeqID);
        public bool Update(CampaignDefWithCampaignPropertiesDef model);
        public bool AddNew(CampaignDefWithCampaignPropertiesDef model);
        public List<CampingWithPropertiesRelationModel> SelectAllPropertiesByCampaignDefSeqIDSP(int CampaignDefSeqID);
    }
}
