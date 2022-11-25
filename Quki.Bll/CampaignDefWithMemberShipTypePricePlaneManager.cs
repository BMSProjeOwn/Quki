using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using Quki.Bll.Base;
using Quki.Dal.Abstract;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;
using Quki.Interface;

namespace Quki.Bll
{
    public class CampaignDefWithMemberShipTypePricePlaneManager : BllBase<CampaignDefWithMemberShipTypePricePlane, MemberShipTypeCampaignModel>, ICampaignDefWithMemberShipTypePricePlaneService
    {
        public readonly ICampaignDefWithMemberShipTypePricePlaneRepository repo;

        public CampaignDefWithMemberShipTypePricePlaneManager(IServiceProvider service) : base(service)
        {
            repo = service.GetService<ICampaignDefWithMemberShipTypePricePlaneRepository>();
        }
        public bool AddNew(CampaignDefWithMemberShipTypePricePlane model)
        { return repo.AddNew(model); }
        public bool Update(CampaignDefWithMemberShipTypePricePlane model)
        {
            return repo.Update(model);
        }
        public List<CampaignDefWithMemberShipTypePricePlane> GetAllActiveByMemberShipTypePricePlane(int CampaignDefSeqID)
        {
            return repo.GetAllActiveByMemberShipTypePricePlane(CampaignDefSeqID);
        }
    }
}
