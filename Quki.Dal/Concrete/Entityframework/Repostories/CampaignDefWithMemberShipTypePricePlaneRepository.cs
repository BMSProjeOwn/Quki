using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Quki.Dal.Abstract;
using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Entity.Models;

namespace Quki.Dal.Concrete.Entityframework.Repostories
{
    public class CampaignDefWithMemberShipTypePricePlaneRepository : GenericRepository<CampaignDefWithMemberShipTypePricePlane>, ICampaignDefWithMemberShipTypePricePlaneRepository
    {
        public CampaignDefWithMemberShipTypePricePlaneRepository(DbContext context) : base(context)
        {

        }
        public bool AddNew(CampaignDefWithMemberShipTypePricePlane model)
        {
            TAdd(model);
            return true;
        }
        public bool Update(CampaignDefWithMemberShipTypePricePlane model)
        {
            TUpdate(model);
            return true;
        }

        public List<CampaignDefWithMemberShipTypePricePlane> GetAllActiveByMemberShipTypePricePlane(int CampaignDefSeqID)
        {
            var result = dbset
                .Where(w => w.isActive == true && w.CampaignDefSeqID == CampaignDefSeqID).OrderBy(x=>x.CampaignDefWithMemberShipTypePricePlaneSeqID).ToList();
            return result;
        }
    }
}
