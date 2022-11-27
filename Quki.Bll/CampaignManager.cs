using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class CampaignManager : BllBase<CampaignDef, AddCampaignModel>, ICampaignService
    {
        public readonly ICampaignRepository repo;
        public readonly ICampaignDefWithMemberShipTypePricePlaneRepository campaignDefWithMemberShipTypePricePlaneRepository;
        public readonly ICampaignDefWithCampaignPropertiesDefRepository campaignDefWithCampaignPropertiesDefRepository;
        public readonly ICampaignDefWithCouponRepository campaignDefWithCouponRepository;
        public readonly IMemberShipTypeRepository memberShipTypeRepository;
        public readonly ICampaignDefWithMemberShipTypeRepository campaignDefWithMemberShipTypeRepository;
        public readonly IValueTypesRepository valueTypesRepository;
        public readonly ICampaignPropertiesDefRepository campaignPropertiesDefRepository;
        public readonly IMembershipPropertiesRepository membershipPropertiesRepository;

        public CampaignManager(IServiceProvider service) : base(service)
        {
            repo = service.GetService<ICampaignRepository>();
            campaignDefWithMemberShipTypePricePlaneRepository = service.GetService<ICampaignDefWithMemberShipTypePricePlaneRepository>();
            campaignDefWithCampaignPropertiesDefRepository = service.GetService<ICampaignDefWithCampaignPropertiesDefRepository>();
            campaignDefWithCouponRepository = service.GetService<ICampaignDefWithCouponRepository>();
            memberShipTypeRepository = service.GetService<IMemberShipTypeRepository>();
            campaignDefWithMemberShipTypeRepository = service.GetService<ICampaignDefWithMemberShipTypeRepository>();
            campaignPropertiesDefRepository = service.GetService<ICampaignPropertiesDefRepository>();
            valueTypesRepository = service.GetService<IValueTypesRepository>();
            membershipPropertiesRepository = service.GetService<IMembershipPropertiesRepository>();

        }
        public List<CampaignDef> GetCampaignList()
        {

            var items = TGetList(a => a.IsActive == true).Select(x => new CampaignDef
            {
                CampaignDefSeqID = x.CampaignDefSeqID,
                CampaignDefRemark = x.CampaignDefRemark,
                Status = x.Status,
                CampaignDefCode = x.CampaignDefCode,
                CampaignDefName = x.CampaignDefName,
                LanguageID = x.LanguageID,
                CampaignDefGroupID = x.CampaignDefGroupID,
                StartCampaignDateTime = x.StartCampaignDateTime,
                EndCampaignDefDateTime = x.EndCampaignDefDateTime,
                IsMonday = x.IsMonday,
                IsTuesday = x.IsTuesday,
                IsWednesday = x.IsWednesday,
                IsThursday = x.IsThursday,
                IsFriyday = x.IsFriyday,
                IsSaturday = x.IsSaturday,
                IsSunday = x.IsSunday,
                CreatedDateTime = x.CreatedDateTime,
                CampaignDefTypeID = x.CampaignDefTypeID
            });

            return items.ToList().OrderByDescending(u => u.CampaignDefSeqID).ToList();
        }
        public List<CampaignDef> GetCampaignListByCampaingType(int campaingType)
        {

            var items = TGetList(a => a.IsActive == true && a.CampaignDefTypeID == campaingType).Select(x => new CampaignDef
            {
                CampaignDefSeqID = x.CampaignDefSeqID,
                CampaignDefRemark = x.CampaignDefRemark,
                Status = x.Status,
                CampaignDefCode = x.CampaignDefCode,
                CampaignDefName = x.CampaignDefName,
                LanguageID = x.LanguageID,
                CampaignDefGroupID = x.CampaignDefGroupID,
                StartCampaignDateTime = x.StartCampaignDateTime,
                EndCampaignDefDateTime = x.EndCampaignDefDateTime,
                IsMonday = x.IsMonday,
                IsTuesday = x.IsTuesday,
                IsWednesday = x.IsWednesday,
                IsThursday = x.IsThursday,
                IsFriyday = x.IsFriyday,
                IsSaturday = x.IsSaturday,
                IsSunday = x.IsSunday,
                CreatedDateTime = x.CreatedDateTime,
                CampaignDefTypeID = x.CampaignDefTypeID
            });

            return items.ToList().OrderByDescending(u => u.CampaignDefSeqID).ToList();
        }

        public List<SelectListItem> GetAllCampaing()
        {
            return TGetList(w => w.IsActive == true).Select(s => new SelectListItem
            {
                Value = s.CampaignDefTypeID.ToString(),
                Text = s.CampaignDefName
            }).ToList();
        }
        public List<SelectListItem> GetAllCampaingSeqID()
        {
            return TGetList(w => w.IsActive == true).Select(s => new SelectListItem
            {
                Value = s.CampaignDefSeqID.ToString(),
                Text = s.CampaignDefName
            }).ToList();
        }
        public List<SelectListItem> GetCampaingTypeResult(string campaingType)
        {
            return TGetList(w => w.CampaignDefTypeID == Convert.ToInt32(campaingType) && w.IsActive == true).Select(s => new SelectListItem
            {
                Value = s.CampaignDefSeqID.ToString(),
                Text = s.CampaignDefName
            }).ToList();
        }
        public List<CampaignDefWithMemberShipTypePricePlane> GetMemberShipPricePlaneForGift(int countryId)
        {
            List<CampaignDefWithMemberShipTypePricePlane> campaignPricePlaneList = new List<CampaignDefWithMemberShipTypePricePlane>();

            var campaingsGift = GetCampaignListByCampaingType(2);
            foreach (var item in campaingsGift)
            {

                var campaignDefWithMemberShipTypePricePlaneList = campaignDefWithMemberShipTypePricePlaneRepository.GetAllActiveByMemberShipTypePricePlane(item.CampaignDefSeqID);
                foreach (var item2 in campaignDefWithMemberShipTypePricePlaneList)
                {
                    campaignPricePlaneList.Add(item2);
                }
            }
            return campaignPricePlaneList.ToList();

        }
        public int AddCampaign(AddCampaignModel addCampaignModel)
        {
            var entity = new CampaignDef
            {
                CampaignDefName = addCampaignModel.CampaignDefName,
                CampaignDefCode = addCampaignModel.CampaignDefCode,
                CampaignDefGroupID = 1,
                CampaignDefDisplayOrderNumber = 1,
                CampaignDefTypeID = addCampaignModel.CampaignDefTypeID,
                CreatedDateTime = DateTime.Now,
                StartCampaignDateTime = (DateTime)addCampaignModel.StartCampaignDateTime,
                EndCampaignDefDateTime = (DateTime)addCampaignModel.EndCampaignDefDateTime,
                CampaignDefRemark = addCampaignModel.CampaignDefRemark,
                IsMonday = addCampaignModel.IsMonday,
                IsTuesday = addCampaignModel.IsTuesday,
                IsWednesday = addCampaignModel.IsWednesday,
                IsThursday = addCampaignModel.IsThursday,
                IsFriyday = addCampaignModel.IsFriyday,
                IsSaturday = addCampaignModel.IsSaturday,
                IsSunday = addCampaignModel.IsSunday,
                IsShowScreen = true,
                IsActive = true,
                LanguageID = addCampaignModel.LanguageID
            };

            TAdd(entity);
            entity.CampaignDefID = entity.CampaignDefSeqID;
            TUpdate(entity);
            return entity.CampaignDefSeqID;
        }
        public void UpdateCampaign(CampaignUpdateModel updateCampaignModel)
        {
            var entity = TgetItemByID(updateCampaignModel.campaignDef.CampaignDefSeqID);


            entity.CampaignDefSeqID = updateCampaignModel.campaignDef.CampaignDefSeqID;
            entity.CampaignDefTypeID = updateCampaignModel.campaignDef.CampaignDefTypeID;
            entity.CampaignDefName = updateCampaignModel.campaignDef.CampaignDefName;
            entity.CampaignDefRemark = updateCampaignModel.campaignDef.CampaignDefRemark;
            entity.CampaignDefCode = updateCampaignModel.campaignDef.CampaignDefCode;
            if (updateCampaignModel.campaignDef.StartCampaignDateTime != null)
                entity.StartCampaignDateTime = updateCampaignModel.campaignDef.StartCampaignDateTime;
            if (updateCampaignModel.campaignDef.EndCampaignDefDateTime != null)
                entity.EndCampaignDefDateTime = updateCampaignModel.campaignDef.EndCampaignDefDateTime;
            entity.LanguageID = updateCampaignModel.campaignDef.LanguageID;
            entity.IsMonday = updateCampaignModel.campaignDef.IsMonday;
            entity.IsTuesday = updateCampaignModel.campaignDef.IsTuesday;
            entity.IsWednesday = updateCampaignModel.campaignDef.IsWednesday;
            entity.IsThursday = updateCampaignModel.campaignDef.IsThursday;
            entity.IsFriyday = updateCampaignModel.campaignDef.IsFriyday;
            entity.IsSaturday = updateCampaignModel.campaignDef.IsSaturday;
            entity.IsSunday = updateCampaignModel.campaignDef.IsSunday;
            entity.UpdateDateTime = DateTime.Now;

            TUpdate(entity);

            if (updateCampaignModel.MemberShipTypeCampaignModel != null)
            {
                for (int i = 0; i < updateCampaignModel.MemberShipTypeCampaignModel.Count; i++)
                {

                    var memberShipTypeName = updateCampaignModel.MemberShipTypeCampaignModel[i].Name;
                    var isActive = updateCampaignModel.MemberShipTypeCampaignModel[i].isActive;
                    var campaignDefSeqId = updateCampaignModel.MemberShipTypeCampaignModel[i].CampaignDefSeqID;
                    var pricePalenSeq = updateCampaignModel.MemberShipTypeCampaignModel[i].MemberShipTypePricePlaneSeqID;


                    var existsProperty = campaignDefWithMemberShipTypePricePlaneRepository.TGetList()
                        .Where(x => x.MemberShipTypePricePlaneSeqID == pricePalenSeq && x.CampaignDefSeqID == campaignDefSeqId).FirstOrDefault();



                    if (existsProperty != null) // eğer ilişki varsa güncelle hem ilişki tablosunu hemde membershipproperties tablosunu
                    {

                        existsProperty.isActive = isActive;
                        existsProperty.CampaignDefSeqID = campaignDefSeqId;
                        existsProperty.MemberShipTypePricePlaneSeqID = pricePalenSeq;
                        campaignDefWithMemberShipTypePricePlaneRepository.Update(existsProperty);
                    }
                    else
                    {
                        if (isActive)
                        {
                            CampaignDefWithMemberShipTypePricePlane c = new CampaignDefWithMemberShipTypePricePlane();
                            c.isActive = isActive;
                            c.CampaignDefSeqID = campaignDefSeqId;
                            c.MemberShipTypePricePlaneSeqID = pricePalenSeq;
                            campaignDefWithMemberShipTypePricePlaneRepository.AddNew(c);
                        }
                    }
                }
            }

            if (updateCampaignModel.CampaignPropertiesDefModel != null)
            {
                for (int i = 0; i < updateCampaignModel.CampaignPropertiesDefModel.Count; i++)
                {
                    var relationProperties = campaignDefWithCampaignPropertiesDefRepository.GetRelationProperties(updateCampaignModel.campaignDef.CampaignDefSeqID);

                    bool isRelated = false;
                    int relationPosition = -1;
                    if (relationProperties != null)
                    {
                        if (relationProperties.Count > 0)
                        {
                            for (int j = 0; j < relationProperties.Count; j++)
                            {
                                if (updateCampaignModel.CampaignPropertiesDefModel[i].CampaignDefPropertiesDefSeqID == relationProperties[j].CampaignDefPropertiesDefSeqID)
                                {
                                    relationPosition = j;
                                    isRelated = true;
                                    break;
                                }
                            }
                        }
                    }
                    if (updateCampaignModel.CampaignPropertiesDefModel[i].Status)
                    {
                        if (!isRelated)
                        {
                            CampaignDefWithCampaignPropertiesDef campaignDefWithCampaignPropertiesDef = new CampaignDefWithCampaignPropertiesDef();
                            campaignDefWithCampaignPropertiesDef.CampaignDefPropertiesDefSeqID = updateCampaignModel.CampaignPropertiesDefModel[i].CampaignDefPropertiesDefSeqID;
                            campaignDefWithCampaignPropertiesDef.IsActive = true;
                            campaignDefWithCampaignPropertiesDef.Value = updateCampaignModel.CampaignPropertiesDefModel[i].CampaignPropertiesValue;
                            campaignDefWithCampaignPropertiesDef.CampaignDefSeqID = updateCampaignModel.campaignDef.CampaignDefSeqID;
                            campaignDefWithCampaignPropertiesDef.CreatedDateTime = DateTime.Now;
                            try
                            {
                                campaignDefWithCampaignPropertiesDefRepository.TAdd(campaignDefWithCampaignPropertiesDef);
                            }
                            catch (Exception ex)
                            {
                            }
                        }
                        else
                        {
                            relationProperties[relationPosition].IsActive = true;
                            relationProperties[relationPosition].UpdateDateTime = DateTime.Now;
                            relationProperties[relationPosition].Value
                                = updateCampaignModel.CampaignPropertiesDefModel[i].CampaignPropertiesValue;
                            campaignDefWithCampaignPropertiesDefRepository.TUpdate(relationProperties[relationPosition]);
                        }
                    }
                    else
                    {
                        if (isRelated)
                        {
                            relationProperties[relationPosition].IsActive = false;
                            relationProperties[relationPosition].UpdateDateTime = DateTime.Now;
                            campaignDefWithCampaignPropertiesDefRepository.TUpdate(relationProperties[relationPosition]);
                        }
                    }
                }
            }
        }
        public CampaignUpdateModel CampaignGetUpdateValue(int id)
        {
            CampaignUpdateModel campaignUpdateModel = new CampaignUpdateModel();
            var Item = TgetItemByID(id);

            var couponList = campaignDefWithCouponRepository.CouponList(id);

            List<CampaignDefWithCouponModel> campaignDefWithCouponModelList = new List<CampaignDefWithCouponModel>();

            List<MemberShipTypeCampaignModel> memberShipTypeCampaignModelList = new List<MemberShipTypeCampaignModel>();


            var memberShipTypeList = memberShipTypeRepository.MembershipTypewithPricePlanWithPropertiesList();

            var relationMemberShipTypeList = campaignDefWithMemberShipTypeRepository.TGetList(p => p.CampaignDefSeqID == id && p.isActive == true).ToList();
            var relationMemberShipTypePricePlaneList = campaignDefWithMemberShipTypePricePlaneRepository.GetAllActiveByMemberShipTypePricePlane(id);


            foreach (var itemMemberShip in memberShipTypeList)
            {


                MemberShipTypeCampaignModel model = new MemberShipTypeCampaignModel();
                model.Name = itemMemberShip.Name;
                model.CampaignDefSeqID = id;
                model.MemberShipTypePricePlaneSeqID = itemMemberShip.MemberShipTypePricePlaneSeqID;

                model.isActive = false;
                foreach (var item2 in relationMemberShipTypePricePlaneList)
                {
                    if (itemMemberShip.MemberShipTypePricePlaneSeqID == item2.MemberShipTypePricePlaneSeqID)
                    {
                        model.isActive = true;
                    }
                }
                memberShipTypeCampaignModelList.Add(model);
            }

            var allProperties = campaignPropertiesDefRepository.TGetList(x => x.IsActive == true).ToList();
            var relationProperties = campaignDefWithCampaignPropertiesDefRepository.GetRelationProperties(id);

            List<CampaignPropertiesDefModel> campaniaPropertiesList = new List<CampaignPropertiesDefModel>();


            foreach (var item in couponList)
            {
                CampaignDefWithCouponModel model = new CampaignDefWithCouponModel();

                model.CouponDefCode = item.CouponDefCode;


                campaignDefWithCouponModelList.Add(model);

            }



            foreach (var item in allProperties)
            {

                CampaignPropertiesDefModel model = new CampaignPropertiesDefModel();

                model.CampaignDefPropertiesName = item.CampaignDefPropertiesName;
                model.CampaignPropertiesValue = item.CampaignPropertiesValue;
                model.ValueTypeName = valueTypesRepository.TGetList(x => x.ValueTypeSeqID == item.CampaignPropertiesValueTypeID && x.IsActive == true).FirstOrDefault().ValueTypeName; ;
                model.CampaignDefPropertiesDefSeqID = item.CampaignDefPropertiesDefSeqID;
                model.CampaignDefSeqID = id;
                model.Status = false;
                model.IsDynamic = (bool)item.IsDynamic;


                foreach (var relationItem in relationProperties)
                {
                    if (relationItem.CampaignDefPropertiesDefSeqID == item.CampaignDefPropertiesDefSeqID)
                    {
                        model.Status = true;

                        if (item.IsDynamic == true)
                        {
                            model.CampaignPropertiesValue = relationItem.Value;
                        }

                    }

                }


                campaniaPropertiesList.Add(model);


            }


            campaignUpdateModel.CampaignPropertiesDefModel = campaniaPropertiesList;
            campaignUpdateModel.campaignDef = Item;
            campaignUpdateModel.CampaignDefWithCouponModel = campaignDefWithCouponModelList;
            campaignUpdateModel.MemberShipTypeCampaignModel = memberShipTypeCampaignModelList;


            return campaignUpdateModel;
        }
        public void DeleteCampaign(int id)
        {

            var x = TGetList(x => x.CampaignDefSeqID == id).FirstOrDefault();

            x.IsActive = false;

            TUpdate(x);
        }
        //Gelmesi istenen kampanyalar 
        //1 Code a göre gemesi için CampaignDefSeqID ve CampaignDefTypeID 0 girilmeli
        //2 CampaignDefSeqID a göre için Code "" ve CampaignDefTypeID 0 girilmeli
        //3 CampaignDefTypeID a göre için Code "" ve CampaignDefSeqID 0 girilmeli
        public List<SelectMemberShipPricePlaneWithCampaignCodeModel> SelectMemberShipPricePlaneWithCampaignCode(int language, string Code, int CampaignDefSeqID, int CampaignDefTypeID)
        {
            List<SelectMemberShipPricePlaneWithCampaignCodeModel> returnModelList = new List<SelectMemberShipPricePlaneWithCampaignCodeModel>();


            string sql = "exec SelectMemberShipPricePlaneWithCampaignCode @code='" + Code + "' , @language=" + language + ", @CampaignDefSeqID=" + CampaignDefSeqID + ", @CampaignDefTypeID=" + CampaignDefTypeID;
            List<SelectMemberShipPricePlaneWithCampaignCode> membershipTypes = null;
            try { membershipTypes = repo.ExsecuteSql(sql); }
            catch (Exception ex) { }

            if (membershipTypes != null)
            {
                if (membershipTypes.Count > 0)
                {
                    for (int i = 0; i < membershipTypes.Count; i++)
                    {
                        if (Convert.ToInt32(membershipTypes[i].NumberOfUses) > 0)
                        {
                            SelectMemberShipPricePlaneWithCampaignCodeModel returnModel = new SelectMemberShipPricePlaneWithCampaignCodeModel();
                            returnModel.CampingMemberShipType = membershipTypes[i];
                            returnModel.CampingProperties = campaignDefWithCampaignPropertiesDefRepository.GetRelationProperties(membershipTypes[i].CampaignDefSeqID);
                            returnModel.MembershipProperties = membershipPropertiesRepository.GetProperties(membershipTypes[i].MemberShipTypeSeqID);
                            returnModelList.Add(returnModel);
                        }
                    }
                }
            }
            return returnModelList;
        }

    }
}