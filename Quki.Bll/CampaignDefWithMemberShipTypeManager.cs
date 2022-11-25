using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using Quki.Bll.Base;
using Quki.Dal.Abstract;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;
using Quki.Interface;

namespace Quki.Bll
{
    public class CampaignDefWithMemberShipTypeManager : BllBase<CampaignDefWithMemberShipType, MemberShipTypeCampaignModel>, ICampaignDefWithMemberShipTypeService
    {
        public readonly ICampaignDefWithMemberShipTypeRepository repo;

        public CampaignDefWithMemberShipTypeManager(IServiceProvider service) : base(service)
        {
            repo = service.GetService<ICampaignDefWithMemberShipTypeRepository>();
        }
        public CampaignDefWithMemberShipType GetCampaignDefWithMemberShipType(int MemberShipTypeSeqID, int CampaignDefSeqID)
        {
            return TGetList(p => p.MemberShipTypeSeqID == MemberShipTypeSeqID && p.CampaignDefSeqID == CampaignDefSeqID && p.isActive == true).FirstOrDefault();
        }
        public void AddCampaignDefWithMemberShipType(CampaignDefWithMemberShipType Item) 
        {
            var ControlItem = GetCampaignDefWithMemberShipType(Item.MemberShipTypeSeqID, Item.CampaignDefSeqID);
            if (ControlItem == null)
            {
                TAdd(Item);
            }
        }

        public List<CampaignDefWithMemberShipType> GetCampaignDefWithMemberShipTypeList(int CampaignDefSeqID)
        {
            return TGetList(p => p.CampaignDefSeqID == CampaignDefSeqID && p.isActive == true).ToList();
        }
        
    }
}
