using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Quki.Dal.Abstract;
using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Entity.Models;

namespace Quki.Dal.Concrete.Entityframework.Repostories
{
    public class CampaignDefWithMemberShipTypeRepository : GenericRepository<CampaignDefWithMemberShipType>, ICampaignDefWithMemberShipTypeRepository
    {
        public CampaignDefWithMemberShipTypeRepository(DbContext context) :base(context)
        {
           
        }
        //public CampaignDefWithMemberShipType GetCampaignDefWithMemberShipType(int MemberShipTypeSeqID, int CampaignDefSeqID)
        //{

        //    return dbset.Where(p => p.MemberShipTypeSeqID == MemberShipTypeSeqID && p.CampaignDefSeqID == CampaignDefSeqID && p.isActive == true).FirstOrDefault();
        //}

        //public void AddCampaignDefWithMemberShipType(CampaignDefWithMemberShipType Item)
        //{
        //    var ControlItem = GetCampaignDefWithMemberShipType(Item.MemberShipTypeSeqID, Item.CampaignDefSeqID);
        //    if (ControlItem == null)
        //    {
        //        TAdd(Item);
        //    }
        //}




        //public List<CampaignDefWithMemberShipType> GetCampaignDefWithMemberShipTypeList(int CampaignDefSeqID)
        //{
        //    return dbset.Where(p => p.CampaignDefSeqID == CampaignDefSeqID && p.isActive == true).ToList();
        //}
    }
}
