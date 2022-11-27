using System.Collections.Generic;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;

namespace Quki.Interface
{
    public interface ICampaignDefWithMemberShipTypeService : IGenericService<CampaignDefWithMemberShipType, MemberShipTypeCampaignModel>
    {
        public CampaignDefWithMemberShipType GetCampaignDefWithMemberShipType(int MemberShipTypeSeqID, int CampaignDefSeqID);
        public void AddCampaignDefWithMemberShipType(CampaignDefWithMemberShipType Item);
        public List<CampaignDefWithMemberShipType> GetCampaignDefWithMemberShipTypeList(int CampaignDefSeqID);
        
    }
}
