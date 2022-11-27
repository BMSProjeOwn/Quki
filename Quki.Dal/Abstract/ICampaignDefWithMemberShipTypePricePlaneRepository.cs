using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Entity.Models;

namespace Quki.Dal.Abstract
{
    public interface ICampaignDefWithMemberShipTypePricePlaneRepository : IGenericRepository<CampaignDefWithMemberShipTypePricePlane>
    {
        public bool AddNew(CampaignDefWithMemberShipTypePricePlane model);
        public bool Update(CampaignDefWithMemberShipTypePricePlane model);
        public List<CampaignDefWithMemberShipTypePricePlane> GetAllActiveByMemberShipTypePricePlane(int CampaignDefSeqID);
    }
}
