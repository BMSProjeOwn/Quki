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
    public interface ICampaignDefWithMemberShipTypePricePlaneService : IGenericService<CampaignDefWithMemberShipTypePricePlane, MemberShipTypeCampaignModel>
    {
        public bool AddNew(CampaignDefWithMemberShipTypePricePlane model);
        public bool Update(CampaignDefWithMemberShipTypePricePlane model);
        public List<CampaignDefWithMemberShipTypePricePlane> GetAllActiveByMemberShipTypePricePlane(int CampaignDefSeqID);
    }
}
