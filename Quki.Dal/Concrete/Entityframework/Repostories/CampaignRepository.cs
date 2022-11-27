using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quki.Dal.Abstract;
using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;

namespace Quki.Dal.Concrete.Entityframework.Repostories
{
    public class CampaignRepository : GenericRepository<CampaignDef>, ICampaignRepository
    {
        public CampaignRepository(DbContext context) : base(context)
        {

        }
        //public List<CampaignDef> GetCampaignList()
        //{

        //    var items = dbset.Where(a => a.IsActive == true).Select(x => new CampaignDef
        //    {
        //        CampaignDefSeqID = x.CampaignDefSeqID,
        //        CampaignDefRemark = x.CampaignDefRemark,
        //        Status = x.Status,
        //        CampaignDefCode = x.CampaignDefCode,
        //        CampaignDefName = x.CampaignDefName,
        //        LanguageID = x.LanguageID,
        //        CampaignDefGroupID = x.CampaignDefGroupID,
        //        StartCampaignDateTime = x.StartCampaignDateTime,
        //        EndCampaignDefDateTime = x.EndCampaignDefDateTime,
        //        IsMonday = x.IsMonday,
        //        IsTuesday = x.IsTuesday,
        //        IsWednesday = x.IsWednesday,
        //        IsThursday = x.IsThursday,
        //        IsFriyday = x.IsFriyday,
        //        IsSaturday = x.IsSaturday,
        //        IsSunday = x.IsSunday,
        //        CreatedDateTime = x.CreatedDateTime,
        //        CampaignDefTypeID = x.CampaignDefTypeID
        //    });

        //    return items.ToList().OrderByDescending(u => u.CampaignDefSeqID).ToList();
        //}
        //public int AddCampaign(AddCampaignModel addCampaignModel)
        //{
        //    var entity = new CampaignDef
        //    {
        //        CampaignDefName = addCampaignModel.CampaignDefName,
        //        CampaignDefCode = addCampaignModel.CampaignDefCode,
        //        CampaignDefGroupID = 1,
        //        CampaignDefDisplayOrderNumber = 1,
        //        CampaignDefTypeID = addCampaignModel.CampaignDefTypeID,
        //        CreatedDateTime = DateTime.Now,
        //        StartCampaignDateTime = (DateTime)addCampaignModel.StartCampaignDateTime,
        //        EndCampaignDefDateTime = (DateTime)addCampaignModel.EndCampaignDefDateTime,
        //        CampaignDefRemark = addCampaignModel.CampaignDefRemark,
        //        IsMonday = addCampaignModel.IsMonday,
        //        IsTuesday = addCampaignModel.IsTuesday,
        //        IsWednesday = addCampaignModel.IsWednesday,
        //        IsThursday = addCampaignModel.IsThursday,
        //        IsFriyday = addCampaignModel.IsFriyday,
        //        IsSaturday = addCampaignModel.IsSaturday,
        //        IsSunday = addCampaignModel.IsSunday,
        //        IsShowScreen = true,
        //        IsActive = true,
        //        LanguageID = addCampaignModel.LanguageID
        //    };

        //    TAdd(entity);
        //    entity.CampaignDefID = entity.CampaignDefSeqID;
        //    TUpdate(entity);
        //    return entity.CampaignDefSeqID;
        //}
        //public void UpdateCampaign(CampaignUpdateModel updateCampaignModel)
        //{
        //    var entity = TgetItemByID(updateCampaignModel.campaignDef.CampaignDefSeqID);


        //    entity.CampaignDefSeqID = updateCampaignModel.campaignDef.CampaignDefSeqID;
        //    entity.CampaignDefTypeID = updateCampaignModel.campaignDef.CampaignDefTypeID;
        //    entity.CampaignDefName = updateCampaignModel.campaignDef.CampaignDefName;
        //    entity.CampaignDefRemark = updateCampaignModel.campaignDef.CampaignDefRemark;
        //    entity.CampaignDefCode = updateCampaignModel.campaignDef.CampaignDefCode;
        //    if (updateCampaignModel.campaignDef.StartCampaignDateTime != null)
        //        entity.StartCampaignDateTime = updateCampaignModel.campaignDef.StartCampaignDateTime;
        //    if (updateCampaignModel.campaignDef.EndCampaignDefDateTime != null)
        //        entity.EndCampaignDefDateTime = updateCampaignModel.campaignDef.EndCampaignDefDateTime;
        //    entity.LanguageID = updateCampaignModel.campaignDef.LanguageID;
        //    entity.IsMonday = updateCampaignModel.campaignDef.IsMonday;
        //    entity.IsTuesday = updateCampaignModel.campaignDef.IsTuesday;
        //    entity.IsWednesday = updateCampaignModel.campaignDef.IsWednesday;
        //    entity.IsThursday = updateCampaignModel.campaignDef.IsThursday;
        //    entity.IsFriyday = updateCampaignModel.campaignDef.IsFriyday;
        //    entity.IsSaturday = updateCampaignModel.campaignDef.IsSaturday;
        //    entity.IsSunday = updateCampaignModel.campaignDef.IsSunday;
        //    entity.UpdateDateTime = DateTime.Now;

        //    TUpdate(entity);

        //    if (updateCampaignModel.MemberShipTypeCampaignModel != null)
        //    {
        //        for (int i = 0; i < updateCampaignModel.MemberShipTypeCampaignModel.Count; i++)
        //        {

        //            var memberShipTypeName = updateCampaignModel.MemberShipTypeCampaignModel[i].Name;
        //            var isActive = updateCampaignModel.MemberShipTypeCampaignModel[i].isActive;
        //            var campaignDefSeqId = updateCampaignModel.MemberShipTypeCampaignModel[i].CampaignDefSeqID;
        //            var pricePalenSeq = updateCampaignModel.MemberShipTypeCampaignModel[i].MemberShipTypePricePlaneSeqID;


        //            var existsProperty = context.Set<CampaignDefWithMemberShipTypePricePlane>()
        //                .Where(x => x.MemberShipTypePricePlaneSeqID == pricePalenSeq && x.CampaignDefSeqID == campaignDefSeqId).FirstOrDefault();



        //            if (existsProperty != null) // eğer ilişki varsa güncelle hem ilişki tablosunu hemde membershipproperties tablosunu
        //            {
        //                CampaignDefWithMemberShipTypePricePlaneRepository repository = new CampaignDefWithMemberShipTypePricePlaneRepository(context);

        //                existsProperty.isActive = isActive;
        //                existsProperty.CampaignDefSeqID = campaignDefSeqId;
        //                existsProperty.MemberShipTypePricePlaneSeqID = pricePalenSeq;
        //                repository.Update(existsProperty);
        //            }
        //            else
        //            {
        //                if (isActive)
        //                {
        //                    CampaignDefWithMemberShipTypePricePlaneRepository repository = new CampaignDefWithMemberShipTypePricePlaneRepository(context);
        //                    CampaignDefWithMemberShipTypePricePlane c = new CampaignDefWithMemberShipTypePricePlane();
        //                    c.isActive = isActive;
        //                    c.CampaignDefSeqID = campaignDefSeqId;
        //                    c.MemberShipTypePricePlaneSeqID = pricePalenSeq;
        //                    repository.AddNew(c);
        //                }
        //            }
        //        }
        //    }

        //    CampaignDefWithCampaignPropertiesDefRepository campaignDefWithCampaignPropertiesDefRepository =
        //        new CampaignDefWithCampaignPropertiesDefRepository(context);
        //    if (updateCampaignModel.CampaignPropertiesDefModel != null)
        //    {
        //        for (int i = 0; i < updateCampaignModel.CampaignPropertiesDefModel.Count; i++)
        //        {
        //            var relationProperties = campaignDefWithCampaignPropertiesDefRepository.GetRelationProperties(updateCampaignModel.campaignDef.CampaignDefSeqID);

        //            bool isRelated = false;
        //            int relationPosition = -1;
        //            if (relationProperties != null)
        //            {
        //                if (relationProperties.Count > 0)
        //                {
        //                    for (int j = 0; j < relationProperties.Count; j++)
        //                    {
        //                        if (updateCampaignModel.CampaignPropertiesDefModel[i].CampaignDefPropertiesDefSeqID == relationProperties[j].CampaignDefPropertiesDefSeqID)
        //                        {
        //                            relationPosition = j;
        //                            isRelated = true;
        //                            break;
        //                        }
        //                    }
        //                }
        //            }
        //            if (updateCampaignModel.CampaignPropertiesDefModel[i].Status)
        //            {
        //                if (!isRelated)
        //                {
        //                    CampaignDefWithCampaignPropertiesDef campaignDefWithCampaignPropertiesDef = new CampaignDefWithCampaignPropertiesDef();
        //                    campaignDefWithCampaignPropertiesDef.CampaignDefPropertiesDefSeqID = updateCampaignModel.CampaignPropertiesDefModel[i].CampaignDefPropertiesDefSeqID;
        //                    campaignDefWithCampaignPropertiesDef.IsActive = true;
        //                    campaignDefWithCampaignPropertiesDef.Value = updateCampaignModel.CampaignPropertiesDefModel[i].CampaignPropertiesValue;
        //                    campaignDefWithCampaignPropertiesDef.CampaignDefSeqID = updateCampaignModel.campaignDef.CampaignDefSeqID;
        //                    campaignDefWithCampaignPropertiesDef.CreatedDateTime = DateTime.Now;
        //                    try
        //                    {
        //                        campaignDefWithCampaignPropertiesDefRepository.AddNew(campaignDefWithCampaignPropertiesDef);
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                    }
        //                }
        //                else
        //                {
        //                    relationProperties[relationPosition].IsActive = true;
        //                    relationProperties[relationPosition].UpdateDateTime = DateTime.Now;
        //                    relationProperties[relationPosition].Value
        //                        = updateCampaignModel.CampaignPropertiesDefModel[i].CampaignPropertiesValue;
        //                    campaignDefWithCampaignPropertiesDefRepository.Update(relationProperties[relationPosition]);
        //                }
        //            }
        //            else
        //            {
        //                if (isRelated)
        //                {
        //                    relationProperties[relationPosition].IsActive = false;
        //                    relationProperties[relationPosition].UpdateDateTime = DateTime.Now;
        //                    campaignDefWithCampaignPropertiesDefRepository.Update(relationProperties[relationPosition]);
        //                }
        //            }
        //        }
        //    }
        //}
        //public CampaignUpdateModel CampaignGetUpdateValue(int id)
        //{
        //    CampaignUpdateModel campaignUpdateModel = new CampaignUpdateModel();
        //    var Item = TgetItemByID(id);

        //    CampaignDefWithCouponRepository campaignDefWithCouponRepository = new CampaignDefWithCouponRepository(context);

        //    var couponList = campaignDefWithCouponRepository.CouponList(id);

        //    List<CampaignDefWithCouponModel> campaignDefWithCouponModelList = new List<CampaignDefWithCouponModel>();

        //    List<MemberShipTypeCampaignModel> memberShipTypeCampaignModelList = new List<MemberShipTypeCampaignModel>();

        //    MemberShipTypeRepository memberShipTypeRepository = new MemberShipTypeRepository(context);

        //    var memberShipTypeList = memberShipTypeRepository.MembershipTypewithPricePlanWithPropertiesList();

        //    CampaignDefWithMemberShipTypeRepositories campaignDefWithMemberShipTypeRepositories = new CampaignDefWithMemberShipTypeRepositories(context);
        //    CampaignDefWithMemberShipTypePricePlaneRepository campaignDefWithMemberShipTypePricePlaneRepository = new CampaignDefWithMemberShipTypePricePlaneRepository(context);
        //    var relationMemberShipTypeList = campaignDefWithMemberShipTypeRepositories.GetCampaignDefWithMemberShipTypeList(id);
        //    var relationMemberShipTypePricePlaneList = campaignDefWithMemberShipTypePricePlaneRepository.GetAllActiveByMemberShipTypePricePlane(id);


        //    foreach (var itemMemberShip in memberShipTypeList)
        //    {


        //        MemberShipTypeCampaignModel model = new MemberShipTypeCampaignModel();
        //        model.Name = itemMemberShip.Name;
        //        model.CampaignDefSeqID = id;
        //        model.MemberShipTypePricePlaneSeqID = itemMemberShip.MemberShipTypePricePlaneSeqID;

        //        model.isActive = false;
        //        foreach (var item2 in relationMemberShipTypePricePlaneList)
        //        {
        //            if (itemMemberShip.MemberShipTypePricePlaneSeqID == item2.MemberShipTypePricePlaneSeqID)
        //            {
        //                model.isActive = true;
        //            }
        //        }
        //        memberShipTypeCampaignModelList.Add(model);
        //    }

        //    CampaignPropertiesDefRepository campaignPropertiesDefRepository = new CampaignPropertiesDefRepository(context);
        //    CampaignDefWithCampaignPropertiesDefRepository campaignDefWithCampaignPropertiesDefRepository = new CampaignDefWithCampaignPropertiesDefRepository(context);
        //    var allProperties = campaignPropertiesDefRepository.GetAllProperties();
        //    var relationProperties = campaignDefWithCampaignPropertiesDefRepository.GetRelationProperties(id);

        //    List<CampaignPropertiesDefModel> campaniaPropertiesList = new List<CampaignPropertiesDefModel>();


        //    foreach (var item in couponList)
        //    {
        //        CampaignDefWithCouponModel model = new CampaignDefWithCouponModel();

        //        model.CouponDefCode = item.CouponDefCode;


        //        campaignDefWithCouponModelList.Add(model);

        //    }



        //    foreach (var item in allProperties)
        //    {

        //        CampaignPropertiesDefModel model = new CampaignPropertiesDefModel();
        //        ValueTypesRepository valueTypesRepository = new ValueTypesRepository(context);

        //        model.CampaignDefPropertiesName = item.CampaignDefPropertiesName;
        //        model.CampaignPropertiesValue = item.CampaignPropertiesValue;
        //        model.ValueTypeName = valueTypesRepository.GetValue(item.CampaignPropertiesValueTypeID).ValueTypeName;
        //        model.CampaignDefPropertiesDefSeqID = item.CampaignDefPropertiesDefSeqID;
        //        model.CampaignDefSeqID = id;
        //        model.Status = false;
        //        model.IsDynamic = (bool)item.IsDynamic;


        //        foreach (var relationItem in relationProperties)
        //        {
        //            if (relationItem.CampaignDefPropertiesDefSeqID == item.CampaignDefPropertiesDefSeqID)
        //            {
        //                model.Status = true;

        //                if (item.IsDynamic == true)
        //                {
        //                    model.CampaignPropertiesValue = relationItem.Value;
        //                }

        //            }

        //        }


        //        campaniaPropertiesList.Add(model);


        //    }


        //    campaignUpdateModel.CampaignPropertiesDefModel = campaniaPropertiesList;
        //    campaignUpdateModel.campaignDef = Item;
        //    campaignUpdateModel.CampaignDefWithCouponModel = campaignDefWithCouponModelList;
        //    campaignUpdateModel.MemberShipTypeCampaignModel = memberShipTypeCampaignModelList;


        //    return campaignUpdateModel;
        //}
        //public void DeleteCampaign(int id)
        //{

        //    var x = dbset.Where(x => x.CampaignDefSeqID == id).FirstOrDefault();

        //    x.IsActive = false;

        //    TUpdate(x);
        //}
        ////Gelmesi istenen kampanyalar 
        ////1 Code a göre gemesi için CampaignDefSeqID ve CampaignDefTypeID 0 girilmeli
        ////2 CampaignDefSeqID a göre için Code "" ve CampaignDefTypeID 0 girilmeli
        ////3 CampaignDefTypeID a göre için Code "" ve CampaignDefSeqID 0 girilmeli
        public List<SelectMemberShipPricePlaneWithCampaignCode> ExsecuteSql(string sql)
        {
            var membershipTypes = context.Set<SelectMemberShipPricePlaneWithCampaignCode>().FromSqlRaw(sql).ToList(); 
            
            return membershipTypes;
        }
    }
}