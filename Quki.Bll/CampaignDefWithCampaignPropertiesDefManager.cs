using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using Quki.Bll.Base;
using Quki.Dal.Abstract;
using Quki.Dal.Concrete.Entityframework.Repostories;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;
using Quki.Interface;

namespace Quki.Bll
{
    public class CampaignDefWithCampaignPropertiesDefManager : BllBase<CampaignDefWithCampaignPropertiesDef, CampaignPropertiesDefModel>, ICampaignDefWithCampaignPropertiesDefService
    {
        public readonly ICampaignDefWithCampaignPropertiesDefRepository repo;

        public CampaignDefWithCampaignPropertiesDefManager(IServiceProvider service) : base(service)
        {
            repo = service.GetService<ICampaignDefWithCampaignPropertiesDefRepository>();
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
            
            return repo.SelectAllPropertiesByCampaignDefSeqIDSP(sql); 
        }
    }
}
