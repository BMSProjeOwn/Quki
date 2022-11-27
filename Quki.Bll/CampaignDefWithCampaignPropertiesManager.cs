using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using Quki.Bll.Base;
using Quki.Dal.Abstract;
using Quki.Entity.Models;
using Quki.Interface;

namespace Quki.Bll
{
    public class CampaignDefWithCampaignPropertiesManager : BllBase<CampaignDefWithCampaignPropertiesDef, CampingWithPropertiesRelationModel>, ICampaignDefWithCampaignPropertiesService
    {
        public readonly ICampaignDefWithCampaignPropertiesRepository campaignDefWithCampaignPropertiesRepository;

        public CampaignDefWithCampaignPropertiesManager(IServiceProvider service) :base(service)
        {
            campaignDefWithCampaignPropertiesRepository = service.GetService<ICampaignDefWithCampaignPropertiesRepository>();
        }
        public List<CampaignDefWithCampaignPropertiesDef> GetRelationProperties(int CampaignDefSeqID)
        {
            var list = TGetList(x => x.IsActive == true && x.CampaignDefSeqID == CampaignDefSeqID);

                return list;
        }
        public bool Update(CampaignDefWithCampaignPropertiesDef model)
        {
            try
            {
                TUpdate(model);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool AddNew(CampaignDefWithCampaignPropertiesDef model) 
        {
            try
            {
                TAdd(model);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<CampingWithPropertiesRelationModel> SelectAllPropertiesByCampaignDefSeqIDSP(int CampaignDefSeqID)
        {
            string sql = @"SelectAllPropertiesByCampaignDefSeqIDSP @CampaignDefSeqID= " + CampaignDefSeqID;
            return campaignDefWithCampaignPropertiesRepository.SelectAllPropertiesByCampaignDefSeqIDSP(sql);
        }

    }
}
