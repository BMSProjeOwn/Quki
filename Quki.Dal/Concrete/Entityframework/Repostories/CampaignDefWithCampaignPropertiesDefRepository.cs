using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Quki.Dal.Abstract;
using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Entity.Models;

namespace Quki.Dal.Concrete.Entityframework.Repostories
{
    public class CampaignDefWithCampaignPropertiesDefRepository : GenericRepository<CampaignDefWithCampaignPropertiesDef>, ICampaignDefWithCampaignPropertiesDefRepository
    {
        public CampaignDefWithCampaignPropertiesDefRepository(DbContext context) :base(context)
        {
            
        }

        public List<CampaignDefWithCampaignPropertiesDef> GetRelationProperties(int CampaignDefSeqID)
        {
            var list = context.Set<CampaignDefWithCampaignPropertiesDef>().Where(x => x.IsActive == true && x.CampaignDefSeqID == CampaignDefSeqID).ToList();

            return list;
        }

        //public List<CampaignDefWithCampaignPropertiesDef> GetRelationProperties(int CampaignDefSeqID)
        //{
        //    var list = dbset.Where(x => x.IsActive == true && x.CampaignDefSeqID == CampaignDefSeqID).ToList();

        //    return list;
        //}

        //public bool Update(CampaignDefWithCampaignPropertiesDef model)
        //{
        //    TUpdate(model);
        //    return true;
        //}
        //public bool AddNew(CampaignDefWithCampaignPropertiesDef model)
        //{
        //    TAdd(model);
        //    return true;
        //}

        public List<CampingWithPropertiesRelationModel> SelectAllPropertiesByCampaignDefSeqIDSP(string sql)
        {
            var list = context.Set<CampingWithPropertiesRelationModel>().FromSqlRaw(sql).ToList();
            return list;
        }

        public bool Update(CampaignDefWithCampaignPropertiesDef model)
        {
            throw new NotImplementedException();
        }
    }
}
