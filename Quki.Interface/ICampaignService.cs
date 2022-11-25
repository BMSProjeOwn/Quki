using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;

namespace Quki.Interface
{ 
    public interface ICampaignService : IGenericService<CampaignDef, AddCampaignModel>
{
        public List<CampaignDef> GetCampaignList();
        public int AddCampaign(AddCampaignModel addCampaignModel);
        public void UpdateCampaign(CampaignUpdateModel updateCampaignModel);
        public CampaignUpdateModel CampaignGetUpdateValue(int id);
        public void DeleteCampaign(int id);
        public List<CampaignDefWithMemberShipTypePricePlane> GetMemberShipPricePlaneForGift(int countryId);
        ///Gelmesi istenen kampanyalar 
        ///1 Code a göre gemesi için CampaignDefSeqID ve CampaignDefTypeID 0 girilmeli
        ///2 CampaignDefSeqID a göre için Code "" ve CampaignDefTypeID 0 girilmeli
        ///3 CampaignDefTypeID a göre için Code "" ve CampaignDefSeqID 0 girilmeli
        public List<SelectMemberShipPricePlaneWithCampaignCodeModel> SelectMemberShipPricePlaneWithCampaignCode(int language, string Code, int CampaignDefSeqID, int CampaignDefTypeID);
        public List<SelectListItem> GetAllCampaing();
        public List<SelectListItem> GetAllCampaingSeqID();
        
        public List<SelectListItem> GetCampaingTypeResult(string campaingType);

    }
}