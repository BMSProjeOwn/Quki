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
    public class CampaignPropertiesDefManager : BllBase<CampaignPropertiesDef, CampaignPropertiesDefModel>, ICampaignPropertiesDefService
    {
        public readonly ICampaignPropertiesDefRepository repo;

        public CampaignPropertiesDefManager(IServiceProvider service) : base(service)
        {
            repo = service.GetService<ICampaignPropertiesDefRepository>();
        }
        public List<CampaignPropertiesDef> GetAllProperties()
        {
            var list = TGetList(x => x.IsActive == true).ToList();

            return list;
        }
        public bool AddProperty(CampaignPropertiesDef model)
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
        public CampaignPropertiesDef GetPropertieByFunctionName(string FunctionName)
        {
            var list = TGetList(x => x.CampaignPropertiesFunction == FunctionName).FirstOrDefault();

            return list;
        }
    }
}
