using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;

namespace Quki.Dal.Abstract
{
    public interface ICampaignRepository : IGenericRepository<CampaignDef>
    {
        //public List<CampaignDef> GetCampaignList();
        //public int AddCampaign(AddCampaignModel addCampaignModel);
        //public void UpdateCampaign(CampaignUpdateModel updateCampaignModel);
        //public CampaignUpdateModel CampaignGetUpdateValue(int id);
        //public void DeleteCampaign(int id);
        /////Gelmesi istenen kampanyalar 
        /////1 Code a göre gemesi için CampaignDefSeqID ve CampaignDefTypeID 0 girilmeli
        /////2 CampaignDefSeqID a göre için Code "" ve CampaignDefTypeID 0 girilmeli
        /////3 CampaignDefTypeID a göre için Code "" ve CampaignDefSeqID 0 girilmeli
        //public List<SelectMemberShipPricePlaneWithCampaignCodeModel> SelectMemberShipPricePlaneWithCampaignCode(int language, string Code, int CampaignDefSeqID, int CampaignDefTypeID);
        public List<SelectMemberShipPricePlaneWithCampaignCode> ExsecuteSql(string sql);
    }
}