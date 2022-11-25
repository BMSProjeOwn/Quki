
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Quki.Dal.Abstract;

using Quki.Entity.DtoModels;
using Quki.Entity.DtoModels.ApiModels;
using Quki.Entity.Models;
using Quki.Entity.Parameters;
using Quki.Entity.ViewModel;

namespace Quki.Dal.Concrete.Entityframework.Repostories
{
    public class MemberShipTypeRepository : GenericRepository<MemberShipType>, IMemberShipTypeRepository
    {
        public MemberShipTypeRepository(DbContext context) : base(context)
        {
            
        }

        //public bool MemberShipTypeAddNew(MemberShipTypeMergeModel Item)
        //{
        //    bool returnvalue = false;
        //    MemberShipType p = new MemberShipType();

        //    p.MemberShipTypeID = Item.MemberShipTypeAddModel.MemberShipTypeID;
        //    p.LanguageID = Item.MemberShipTypeAddModel.LanguageID;
        //    p.Name = Item.MemberShipTypeAddModel.Name;
        //    p.Remark = Item.MemberShipTypeAddModel.Remark;
        //    p.Code = Item.MemberShipTypeAddModel.Code;
        //    p.Status = Item.MemberShipTypeAddModel.Status;
        //    p.ShowOnHomePage = Item.MemberShipTypeAddModel.ShowOnHomePage;
        //    int _memberShipTypeSeqID = 0;
        //    if (Parameters.isHasIzicoo)
        //    {
        //        string ProductRefCode = string.Empty;
        //        bool rezult = IyzipayEntegration.CreateProduct(Item.MemberShipTypeAddModel.Name, Item.MemberShipTypeAddModel.Remark, out ProductRefCode);
        //        if (rezult)
        //        {
        //            TAdd(p);
        //            var memeber = getLastMemberShipType();
        //            //Kategori Ata
        //            _memberShipTypeSeqID = (int)memeber.MemberShipTypeSeqID;
        //            MemberShipTypesWithPaymentChanelsRepository Repository = new MemberShipTypesWithPaymentChanelsRepository(context);
        //            MemberShipTypesWithPaymentChanel memberShipTypesWithPaymentChanel = new MemberShipTypesWithPaymentChanel();
        //            memberShipTypesWithPaymentChanel.MemberShipTypeSeqID = _memberShipTypeSeqID;
        //            memberShipTypesWithPaymentChanel.Name = Item.MemberShipTypeAddModel.Name;
        //            memberShipTypesWithPaymentChanel.Description = Item.MemberShipTypeAddModel.Remark;
        //            memberShipTypesWithPaymentChanel.ReferenceCode = ProductRefCode;
        //            Repository.TAdd(memberShipTypesWithPaymentChanel);
        //        }
        //    }
        //    List<MemberShipTypeWithPropertiessAddModel> propertiesList = Item.MemberShipTypeWithPropertiessAddModel;

        //    MemberShipTypeWithPropertiesRepository memberShipTypeWithPropertiesRepository = new MemberShipTypeWithPropertiesRepository(context);
        //    if (propertiesList != null)
        //    {
        //        foreach (var item in propertiesList)
        //        {
        //            if (item.isHas)
        //            {
        //                memberShipTypeWithPropertiesRepository.AddMemberShipTypeWithPropertie(new MemberShipTypeWithProperties
        //                {
        //                    MemberShipPropertiesSeqID = item.MemberShipPropertiesSeqID,
        //                    MemberShipTypeSeqID = _memberShipTypeSeqID
        //                });
        //            }
        //        }
        //    }

        //    return returnvalue;
        //}


        //public bool MemberShipTypeUpdate(MemberShipTypeMergeModel Item)
        //{
        //    bool returnvalue = false;
        //    MemberShipType p = new MemberShipType();
        //    p.MemberShipTypeSeqID = Item.MemberShipTypeAddModel.MemberShipTypeSeqID;
        //    p.MemberShipTypeID = Item.MemberShipTypeAddModel.MemberShipTypeID;
        //    p.LanguageID = Item.MemberShipTypeAddModel.LanguageID;
        //    p.Name = Item.MemberShipTypeAddModel.Name;
        //    p.Remark = Item.MemberShipTypeAddModel.Remark;
        //    p.Code = Item.MemberShipTypeAddModel.Code;
        //    p.Status = true;
        //    p.ShowOnHomePage = Item.MemberShipTypeAddModel.ShowOnHomePage;


        //    for (int i = 0; i < Item.MemberShipPropertiesGroupModel.Count; i++)
        //    {
        //        for (int j = 0; j < Item.MemberShipPropertiesGroupModel[i].MemberShipTypeWithPropertiessAddModel.Count; j++)
        //        {
        //            var initialValue = Item.MemberShipPropertiesGroupModel[i].MemberShipTypeWithPropertiessAddModel[j].InitialValue;
        //            var endValue = Item.MemberShipPropertiesGroupModel[i].MemberShipTypeWithPropertiessAddModel[j].EndValue;
        //            var memberShipTypeSeqID = Item.MemberShipPropertiesGroupModel[i].MemberShipTypeWithPropertiessAddModel[j].MemberShipTypeSeqID;
        //            var memberShipPropertiesSeqID = Item.MemberShipPropertiesGroupModel[i].MemberShipTypeWithPropertiessAddModel[j].MemberShipPropertiesSeqID;
        //            var isActive = Item.MemberShipPropertiesGroupModel[i].MemberShipTypeWithPropertiessAddModel[j].IsActive;
        //            var isDynamic = Item.MemberShipPropertiesGroupModel[i].MemberShipTypeWithPropertiessAddModel[j].IsDynamic;
        //            var isshowScreen = Item.MemberShipPropertiesGroupModel[i].MemberShipTypeWithPropertiessAddModel[j].IsshowScreen;

        //            var existsProperty = context.Set<MemberShipTypeWithProperties>().Where(x => x.MemberShipTypeSeqID == memberShipTypeSeqID && x.MemberShipPropertiesSeqID == memberShipPropertiesSeqID).FirstOrDefault();

        //            MemberShipTypeWithProperties memberShipTypeWithProperties = new MemberShipTypeWithProperties();


        //            if (existsProperty != null) // eğer ilişki varsa güncelle hem ilişki tablosunu hemde membershipproperties tablosunu
        //            {
        //                MemberShipTypeWithPropertiesRepository repository = new MemberShipTypeWithPropertiesRepository(context);

        //                existsProperty.InitialValue = Item.MemberShipPropertiesGroupModel[i].MemberShipTypeWithPropertiessAddModel[j].InitialValue;
        //                existsProperty.EndValue = Item.MemberShipPropertiesGroupModel[i].MemberShipTypeWithPropertiessAddModel[j].EndValue;
        //                existsProperty.IsActive = Item.MemberShipPropertiesGroupModel[i].MemberShipTypeWithPropertiessAddModel[j].IsActive;
        //                existsProperty.MemberShipPropertiesSeqID = Item.MemberShipPropertiesGroupModel[i].MemberShipTypeWithPropertiessAddModel[j].MemberShipPropertiesSeqID;
        //                existsProperty.MemberShipTypeSeqID = Item.MemberShipPropertiesGroupModel[i].MemberShipTypeWithPropertiessAddModel[j].MemberShipTypeSeqID;
        //                existsProperty.IsshowScreen = Item.MemberShipPropertiesGroupModel[i].MemberShipTypeWithPropertiessAddModel[j].IsshowScreen;
        //                //repository.UpdateMemberShipTypeWithProperties(existsProperty);
        //                repository.TUpdate(existsProperty);
        //            }

        //            else  // eğer ilişki yoksa ilişki tablosuna ekle
        //            {
        //                if (isActive)
        //                {
        //                   MemberShipTypeWithPropertiesRepository repository = new MemberShipTypeWithPropertiesRepository(context);
        //                    MemberShipTypeWithProperties m = new MemberShipTypeWithProperties()
        //                    {
        //                        InitialValue = initialValue,
        //                        EndValue = endValue,
        //                        IsActive = isActive,
        //                        MemberShipTypeSeqID = memberShipTypeSeqID,
        //                        MemberShipPropertiesSeqID = memberShipPropertiesSeqID,
        //                        IsshowScreen = isshowScreen
        //                    };
        //                    repository.AddMemberShipTypeWithPropertie(m);
        //                }
        //            }
        //        }
        //    }

        //    //repository.SaveChange();






        //    MemberShipTypeWithCountryRepository memberShipTypeWithCountryRepository = new MemberShipTypeWithCountryRepository(context);
        //    var list = new List<MemberShipTypeWithCountry>();
        //    var list2 = new List<MemberShipTypeWithCountry>();

        //    for (int i = 0; i < Item.CountryModel.Count; i++)
        //    {
        //        var memberShipTypeWithCountry = context.Set<MemberShipTypeWithCountry>().Where(x => x.IsActivated == true && x.MemberShipTypSeqID == Item.MemberShipTypeAddModel.MemberShipTypeSeqID && x.CounrtySeqID == Item.CountryModel[i].CounrtySeqID).FirstOrDefault();

        //        //ilişki tablosunda yoksa ve ülke seçili ise ilişki tablosuna ekle
        //        if (memberShipTypeWithCountry == null && Item.CountryModel[i].IsChecked == true)
        //        {
        //            //MemberShipTypeWithCountryRepository memberShipTypeWithCountryRepository = new MemberShipTypeWithCountryRepository(context);
        //            MemberShipTypeWithCountry memberShipTypeWithCountries = new MemberShipTypeWithCountry();

        //            memberShipTypeWithCountries.CounrtySeqID = Item.CountryModel[i].CounrtySeqID;
        //            memberShipTypeWithCountries.IsActivated = Item.CountryModel[i].IsChecked;
        //            memberShipTypeWithCountries.MemberShipTypSeqID = Item.MemberShipTypeAddModel.MemberShipTypeSeqID;
        //            memberShipTypeWithCountries.CreatedOn = DateTime.Now;
        //            //memberShipTypeWithCountry.CreatedBy 
        //            //memberShipTypeWithCountryRepository.TAdd(memberShipTypeWithCountries);

        //            list.Add(memberShipTypeWithCountries);
        //        }

        //        //ilişki tablosunda varsa ve ülke silinmişse yani false ise ve ilişkilendirilmek isteniyorsa
        //        if (memberShipTypeWithCountry != null)
        //        {
        //            MemberShipTypeWithCountry memberShipTypeWithCountries = new MemberShipTypeWithCountry();

        //            memberShipTypeWithCountries.MemberShipTypeWithCountrySeqID = memberShipTypeWithCountry.MemberShipTypeWithCountrySeqID;
        //            memberShipTypeWithCountries.CounrtySeqID = Item.CountryModel[i].CounrtySeqID;
        //            memberShipTypeWithCountries.IsActivated = Item.CountryModel[i].IsChecked;
        //            memberShipTypeWithCountries.MemberShipTypSeqID = Item.MemberShipTypeAddModel.MemberShipTypeSeqID;
        //            //MemberShipTypeWithCountryRepository memberShipTypeWithCountryRepository = new MemberShipTypeWithCountryRepository(context);
        //            //memberShipTypeWithCountryRepository.TUpdate(memberShipTypeWithCountries);
        //            list2.Add(memberShipTypeWithCountries);
        //        }
        //    }
        //    memberShipTypeWithCountryRepository.TAddRange(list);
        //    memberShipTypeWithCountryRepository.TUpdateRange(list2);
        //    //memberShipTypeWithCountryRepository.SaveChange();
        //    //repository.SaveChange();    

        //    if (Parameters.isHasIzicoo)
        //    {

        //        var value = context.Set<MemberShipTypesWithPaymentChanel>().Where(i => i.MemberShipTypeSeqID == Item.MemberShipTypeAddModel.MemberShipTypeSeqID).FirstOrDefault();
        //        if (value != null)
        //        {
        //            bool rezult = IyzipayEntegration.UpdateProduct(Item.MemberShipTypeAddModel.Name, Item.MemberShipTypeAddModel.Remark, value.ReferenceCode.ToString());
        //            if (rezult)
        //            {
        //                MemberShipTypesWithPaymentChanelsRepository Repository = new MemberShipTypesWithPaymentChanelsRepository(context);
        //                value.Name = Item.MemberShipTypeAddModel.Name;
        //                value.Description = Item.MemberShipTypeAddModel.Remark;
        //                Repository.TUpdate(value);
        //                //Repository.SaveChange();
        //                TUpdate(p);
        //                //SaveChange();
        //            }
        //        }
        //    }


        //    return returnvalue;
        //}
        //public bool MemberShipTypeDelete(int id)
        //{

        //    //MemberShip Tipe direk delete edilmeyecek statusu false yapılacak. abonelikte veya başka işlemlerde kullaılmış olabilir
        //    var Item = TgetItemByID(id);
        //    Item.Status = false;

        //    if (Parameters.isHasIzicoo)// izico Bağlantıları Siliniyor.
        //    {
        //        var value2 = context.Set<MemberShipPaymentPlanWithPaymentChannel>().Where(i => i.MemberShipTypeSeqID == id).ToList();
        //        if (value2 != null)
        //        {
        //            var activeMemberShipTypePrice = context.Set<MembershipTypePricePlane>().Where(x => x.MemberShipTypePricePlaneSeqID.Equals(id) && x.Status.Equals(true)).ToList();
        //            if (activeMemberShipTypePrice.Count > 0)
        //            {
        //                return false;
        //            }

        //        }
        //        var value = context.Set<MemberShipTypesWithPaymentChanel>().Where(i => i.MemberShipTypeSeqID == id).FirstOrDefault();
        //        if (value != null)
        //        {
        //            IyzipayEntegration.DeleteProduct(value.ReferenceCode);
        //            TUpdate(Item);
        //        }
        //    }
        //    return true;
        //}
        //public List<MemberShipType> MemberShipTypeGetAllActiveList()
        //{
        //    var value = dbset.Where(i => i.Status == true).ToList();
        //    return value;
        //}

        //public MemberShipTypeMergeModel MemberShipTypeGetUpdateValue(int id)
        //{
        //    var Item = TgetItemByID(id);
        //    var dd = GetMemberShipPriceBymembershipTypeSeq(id);
        //    MemberShipTypeMergeModel mymodel = new MemberShipTypeMergeModel();
        //    MemberShipTypeAddModel newModel = new MemberShipTypeAddModel();

        //    newModel.MemberShipTypeSeqID = Item.MemberShipTypeSeqID;
        //    newModel.LanguageID = Item.LanguageID;
        //    newModel.Name = Item.Name;
        //    newModel.Code = Item.Code;
        //    newModel.MemberShipTypeID = Item.MemberShipTypeID;
        //    newModel.Remark = Item.Remark;
        //    newModel.ShowOnHomePage = Item.ShowOnHomePage;
        //    mymodel.MemberShipTypeAddModel = newModel;
        //    CategoryRepository categoryRepository = new CategoryRepository(context);
        //    // üye tipine ait özellikleri getirir
        //    //var hasMemberShipProperties = GetPropertiesByMemberShipType(id);
        //    MembershipPropertiesRepository membershipPropertiesRepository = new MembershipPropertiesRepository(context);

        //    var allProperties = membershipPropertiesRepository.GetPropertiesAllWithValueTypes();

        //    MemberShipTypeWithPropertiesRepository memberShipTypeWithPropertiesRepository = new MemberShipTypeWithPropertiesRepository(context);
        //    var membershipProperties = memberShipTypeWithPropertiesRepository.GetMemberShipTypeWithPropertyList(newModel.MemberShipTypeSeqID);
        //    var allCountry = context.Set<Counrty>().Where(x => x.Status == true).ToList();

        //    List<CountryModel> countryModelList = new List<CountryModel>();


        //    foreach (var item in allCountry)
        //    {
        //        var memberShipTypeWithCountry = context.Set<MemberShipTypeWithCountry>().Where(x => x.IsActivated == true && x.MemberShipTypSeqID == newModel.MemberShipTypeSeqID && x.CounrtySeqID == item.CounrtySeqID).FirstOrDefault();

        //        CountryModel countryModel = new CountryModel();

        //        countryModel.Name = item.CountryName;
        //        countryModel.CounrtySeqID = item.CounrtySeqID;
        //        //ilişki yoksa
        //        if (memberShipTypeWithCountry == null)
        //        {
        //            countryModel.IsChecked = false;
        //            countryModel.CounrtySeqID = item.CounrtySeqID;

        //        }
        //        //ilişki varsa
        //        else
        //        {
        //            countryModel.IsChecked = true;
        //            countryModel.CounrtySeqID = item.CounrtySeqID;
        //        }
        //        countryModelList.Add(countryModel);

        //    }

        //    List<MemberShipTypeWithPropertiessAddModel> memberShipPropertiesList = new List<MemberShipTypeWithPropertiessAddModel>();
        //    List<MemberShipPropertiesGroupModel> memberShipPropertiesGroupModelList = new List<MemberShipPropertiesGroupModel>();
        //    foreach (var item in allProperties)
        //    {
        //        var memberShipTypeWithPropertiesInitialValue = memberShipTypeWithPropertiesRepository.GetMemberShipTypeWithProperties(Item.MemberShipTypeSeqID, item.MemberShipPropertiesSeqID);
        //        MemberShipTypeWithPropertiessAddModel model = new MemberShipTypeWithPropertiessAddModel();
        //        model.MemberShipPropertiesSeqID = item.MemberShipPropertiesSeqID;
        //        model.Name = item.Name;
        //        model.MemberShipTypeSeqID = id;
        //        model.Type = item.Type;
        //        model.GroupID = item.GroupID;
        //        model.ValueTypeSeqId = item.ValueTypeSeqId;
        //        model.ValueTypeName = item.ValueTypeName;
        //        model.ValueTypeSecondName = item.ValueTypeSecondName;
        //        model.IsDynamic = item.IsDynamic;
        //        model.IsActive = membershipProperties.Where(a => a.MemberShipPropertiesSeqID == model.MemberShipPropertiesSeqID).FirstOrDefault() == null ? false : membershipProperties.Where(a => a.MemberShipPropertiesSeqID == model.MemberShipPropertiesSeqID).FirstOrDefault().IsActive.Value;
        //        model.IsshowScreen = membershipProperties.Where(a => a.MemberShipPropertiesSeqID == model.MemberShipPropertiesSeqID).FirstOrDefault() == null ? false : membershipProperties.Where(a => a.MemberShipPropertiesSeqID == model.MemberShipPropertiesSeqID).FirstOrDefault().IsshowScreen;
        //        model.InitialValue = model.IsActive ? memberShipTypeWithPropertiesInitialValue?.InitialValue : item.InitialValue;
        //        model.EndValue = model.IsActive ? memberShipTypeWithPropertiesInitialValue?.EndValue : item.EndValue;
        //        memberShipPropertiesList.Add(model);

        //        MemberShipPropertiesGroupModel memberShipPropertiesGroupModel = new MemberShipPropertiesGroupModel();
        //        memberShipPropertiesGroupModel.GroupID = item.GroupID;
        //        bool addGroup = true;
        //        for (int i = 0; i < memberShipPropertiesGroupModelList.Count; i++)
        //        {
        //            if (memberShipPropertiesGroupModelList[i].GroupID == memberShipPropertiesGroupModel.GroupID)
        //            {
        //                addGroup = false;
        //            }
        //        }
        //        if (addGroup)
        //        {
        //            memberShipPropertiesGroupModelList.Add(memberShipPropertiesGroupModel);
        //        }
        //    }

        //    List<MemberShipPropertiesGroupModel> memberShipPropertiesGroupList = new List<MemberShipPropertiesGroupModel>();
        //    foreach (var group in memberShipPropertiesGroupModelList)
        //    {
        //        MemberShipPropertiesGroupModel model = new MemberShipPropertiesGroupModel();
        //        model.GroupID = group.GroupID;
        //        List<MemberShipTypeWithPropertiessAddModel> list = new List<MemberShipTypeWithPropertiessAddModel>();
        //        foreach (var property in memberShipPropertiesList)
        //        {
        //            if (group.GroupID == property.GroupID)
        //            {
        //                list.Add(property);
        //            }
        //        }
        //        model.MemberShipTypeWithPropertiessAddModel = list;
        //        memberShipPropertiesGroupList.Add(model);
        //    }

        //    mymodel.MemberShipPropertiesGroupModel = memberShipPropertiesGroupList;

        //    MembershipTypePricePlaneRepository membershipTypePricePlaneRepository = new MembershipTypePricePlaneRepository(context);
        //    var membershipTypePricePlane = membershipTypePricePlaneRepository.GetMembershipTypePricePlaneByMemberShipTypeID(Item.MemberShipTypeSeqID);
        //    List<MembershipTypePricePlaneModel> list2 = new List<MembershipTypePricePlaneModel>();


        //    foreach (var item in membershipTypePricePlane)
        //    {
        //        MembershipTypePricePlaneModel model = new MembershipTypePricePlaneModel();
        //        model.MemberShipTypePricePlaneSeqID = item.MemberShipTypePricePlaneSeqID;
        //        model.MemberShipTypeSeqID = item.MemberShipTypeSeqID;
        //        model.PaymentPeriod = item.PaymentPeriod;
        //        model.PlaneName = item.PlaneName;
        //        model.Price = item.Price;
        //        model.Status = item.Status;
        //        model.TrailPeriodDay = item.TrailPeriodDay;
        //        list2.Add(model);
        //    }
        //    mymodel.MembershipTypePricePlane = list2;
        //    mymodel.CountryModel = countryModelList;
        //    return mymodel;
        //}
        //public MemberShipType getLastMemberShipType()
        //{
        //    return dbset.OrderByDescending(u => u.MemberShipTypeSeqID).FirstOrDefault();
        //}

        //public List<MembershipProperties> GetPropertiesByMemberShipType(int MemberShipTypeSeqID)// üye tipine ait özellikleri getirir
        //{

        //    return dbset.Join(context.Set<MemberShipTypeWithProperties>(), MemberShipType => MemberShipType.MemberShipTypeSeqID, MemberShipTypeWithProperties => MemberShipTypeWithProperties.MemberShipTypeSeqID, (MT, MTP) => new
        //    {
        //        MemberShipType = MT,
        //        MemberShipTypeWithProperties = MTP
        //    }).Join(context.Set<MembershipProperties>(), iki => iki.MemberShipTypeWithProperties.MemberShipPropertiesSeqID, MembershipProperties => MembershipProperties.MemberShipPropertiesSeqID, (MTP, MP) => new
        //    {
        //        MemberShipType = MTP.MemberShipType,
        //        MembershipProperties = MP,
        //        MemberShipTypeWithProperties = MTP.MemberShipTypeWithProperties
        //    }).Where(I => I.MemberShipType.MemberShipTypeSeqID == MemberShipTypeSeqID).Select(I => new MembershipProperties
        //    {
        //        Name = I.MembershipProperties.Name,
        //        MemberShipPropertiesSeqID = I.MembershipProperties.MemberShipPropertiesSeqID,
        //        InitialValue = I.MemberShipTypeWithProperties.InitialValue,
        //        EndValue = I.MemberShipTypeWithProperties.EndValue

        //    }).ToList();

        //}
        //public MembershipTypePricePlane GetMemberShipPriceBymembershipTypeSeq(int membershipTypeSeq)
        //{
        //    return context.Set<MembershipTypePricePlane>().Where(i => i.MemberShipTypeSeqID == membershipTypeSeq && i.Status == true).FirstOrDefault();
        //}


        //public List<MembershipProperties> GetMembershipProperties(int id)
        //{
        //    return context.Set<MembershipProperties>().Where(i => i.MemberShipPropertiesSeqID == id && i.Status == true).ToList();
        //}


        //public List<MemberShipTypewithPrice> getMembershipTypewithPriceList()
        //{

        //    return dbset.Join(context.Set<MembershipTypePricePlane>(), MemberShipType => MemberShipType.MemberShipTypeSeqID, MembershipTypePrice => MembershipTypePrice.MemberShipTypeSeqID, (MT, MTP) => new
        //    {
        //        MemberShipType = MT,
        //        MembershipTypePrices = MTP
        //    }).Where(I => I.MemberShipType.Status == true).Select(I => new MemberShipTypewithPrice
        //    {
        //        //Name,MemberShipTypeSeqID,Price,BaseCurrencyPrice,PaymentPeriod
        //        Name = I.MemberShipType.Name,
        //        MemberShipTypeSeqID = I.MemberShipType.MemberShipTypeSeqID,
        //        Price = I.MembershipTypePrices.Price,
        //        PaymentPeriod = I.MembershipTypePrices.PaymentPeriod,
        //        ImageThumpPath = I.MemberShipType.ImageThumpPath
        //    }).ToList();
        //}

        //public List<MemberShipPricePlanGetModel> MembershipTypewithPricePlanList()
        //{

        //    return dbset.Join(context.Set<MembershipTypePricePlane>(), MemberShipType => MemberShipType.MemberShipTypeSeqID, MembershipTypePrice => MembershipTypePrice.MemberShipTypeSeqID, (MT, MTP) => new
        //    {
        //        MemberShipType = MT,
        //        MembershipTypePrices = MTP
        //    }).Where(I => I.MemberShipType.Status && I.MemberShipType.ShowOnHomePage && I.MembershipTypePrices.Status == true).Select(I => new MemberShipPricePlanGetModel
        //    {
        //        //Name,MemberShipTypeSeqID,Price,BaseCurrencyPrice,PaymentPeriod
        //        MemberShipTypeSeqID = I.MemberShipType.MemberShipTypeSeqID,
        //        Name = I.MemberShipType.Name,
        //        Remark = I.MemberShipType.Remark,
        //        MemberShipTypePricePlaneSeqID = I.MembershipTypePrices.MemberShipTypePricePlaneSeqID,
        //        PlaneName = I.MembershipTypePrices.PlaneName,
        //        Price = I.MembershipTypePrices.Price,
        //        PaymentPeriodName = I.MembershipTypePrices.PaymentPeriod == 1 ? "AYLIK" : "HAFTALIK",
        //        PaymentPeriod = I.MembershipTypePrices.PaymentPeriod,
        //        AutoRenewalCount = I.MembershipTypePrices.AutoRenewalCount,
        //        TrailPeriodDay = I.MembershipTypePrices.TrailPeriodDay
        //    }).ToList();
        //}
        public List<MemberShipTypePricePlaneWithPropertiesModel> MembershipTypewithPricePlanWithPropertiesList(int CountrySeqID)
        {
            List<MemberShipTypePricePlaneWithPropertiesModel> memberShipTypePricePlaneWithPropertiesModelList = new List<MemberShipTypePricePlaneWithPropertiesModel>();
            var MemberShipPricePlaneList = dbset.Join(context.Set<MembershipTypePricePlane>(), MemberShipType => MemberShipType.MemberShipTypeSeqID, MembershipTypePrice => MembershipTypePrice.MemberShipTypeSeqID, (MT, MTP) => new
            {
                MemberShipType = MT,
                MembershipTypePrices = MTP
            }).Where(x => x.MemberShipType.Status && x.MemberShipType.ShowOnHomePage && x.MembershipTypePrices.Status == true && x.MembershipTypePrices.ShowCustomers == true).ToList();

            var sonuc = MemberShipPricePlaneList.Join(context.Set<MemberShipTypeWithCountry>(), result => result.MemberShipType.MemberShipTypeSeqID, MemberShipTypeWithCountry => MemberShipTypeWithCountry.MemberShipTypSeqID,
            (R, MTSC) => new
            {
                result = R,
                MemberShipTypeWithCountry = MTSC
            }
            ).Where(I => I.result.MemberShipType.Status && I.result.MemberShipType.ShowOnHomePage && I.result.MembershipTypePrices.Status && I.MemberShipTypeWithCountry.IsActivated == true && I.MemberShipTypeWithCountry.CounrtySeqID == CountrySeqID).Select(I => new MemberShipPricePlanGetModel
            {
                //Name,MemberShipTypeSeqID,Price,BaseCurrencyPrice,PaymentPeriod
                MemberShipTypeSeqID = I.result.MemberShipType.MemberShipTypeSeqID,
                Name = I.result.MemberShipType.Name,
                Remark = I.result.MemberShipType.Remark,
                MemberShipTypePricePlaneSeqID = I.result.MembershipTypePrices.MemberShipTypePricePlaneSeqID,
                PlaneName = I.result.MembershipTypePrices.PlaneName,
                Price = I.result.MembershipTypePrices.Price,
                PaymentPeriodName = I.result.MembershipTypePrices.PaymentPeriod == 1 ? "AYLIK" : "HAFTALIK",
                PaymentPeriod = I.result.MembershipTypePrices.PaymentPeriod,
                AutoRenewalCount = I.result.MembershipTypePrices.AutoRenewalCount,
                TrailPeriodDay = I.result.MembershipTypePrices.TrailPeriodDay,
                CurrenyName = context.Set<Currency>().Find(I.result.MembershipTypePrices.CurrencyID).CurrencyName

            }).ToList();
            foreach (var item in sonuc)
            {
                MemberShipTypePricePlaneWithPropertiesModel memberShipTypePricePlaneWithPropertiesModel = new MemberShipTypePricePlaneWithPropertiesModel();
                MembershipTypePricePlane membershipTypePricePlane = new MembershipTypePricePlane();
                MemberShipTypeWithPropertiesRepository memberShipTypeWithPropertiesRepository = new MemberShipTypeWithPropertiesRepository(context);
                List<MembershipProperties> membershipPropertiesList = new List<MembershipProperties>();
                memberShipTypePricePlaneWithPropertiesModel.MemberShipTypeName = item.Name;
                memberShipTypePricePlaneWithPropertiesModel.MemberShipTypeRemark = item.Remark;
                membershipTypePricePlane.MemberShipTypeSeqID = item.MemberShipTypeSeqID;
                membershipTypePricePlane.MemberShipTypePricePlaneSeqID = item.MemberShipTypePricePlaneSeqID;
                membershipTypePricePlane.PlaneName = item.PlaneName;
                membershipTypePricePlane.Price = item.Price;
                membershipTypePricePlane.AutoRenewalCount = item.AutoRenewalCount;
                membershipTypePricePlane.TrailPeriodDay = item.TrailPeriodDay;
                memberShipTypePricePlaneWithPropertiesModel.MembershipTypePricePlane = membershipTypePricePlane;
                memberShipTypePricePlaneWithPropertiesModel.PaymentPeriodName = item.PaymentPeriodName;
                memberShipTypePricePlaneWithPropertiesModel.CurrencyName = item.CurrenyName;
                membershipPropertiesList = memberShipTypeWithPropertiesRepository.GetMemberShipTypeWithProperties(item.MemberShipTypeSeqID);
                foreach (var itemProperties in membershipPropertiesList)
                {
                    memberShipTypePricePlaneWithPropertiesModel.MembershipProperties.Add(itemProperties);
                }
                memberShipTypePricePlaneWithPropertiesModelList.Add(memberShipTypePricePlaneWithPropertiesModel);
            }
            return memberShipTypePricePlaneWithPropertiesModelList;
        }

        public MemberShipPaymentPlanWithPaymentChannel GetMemberShipPricePlanByMemberShipTypePricePlaneSeqID(int MemberShipTypePricePlaneSeqID)
        {
            return context.Set<MemberShipPaymentPlanWithPaymentChannel>().Where(i => i.MemberShipTypePricePlaneSeqID == MemberShipTypePricePlaneSeqID).FirstOrDefault();
        }
        //public MemberShipType GetMemberShipTypeByMemberShipTypePricePlaneSeqID(int MemberShipTypePricePlaneSeqID)
        //{
        //    var MemberShipPaymentPlanInfo = context.Set<MemberShipPaymentPlanWithPaymentChannel>().Where(i => i.MemberShipTypePricePlaneSeqID == MemberShipTypePricePlaneSeqID).FirstOrDefault();
        //    var MemberShipTypeInfo = dbset.Where(x => x.MemberShipTypeSeqID.Equals(MemberShipPaymentPlanInfo.MemberShipTypeSeqID)).FirstOrDefault();
        //    return MemberShipTypeInfo;
        //}



        //public List<SelectListItem> GetAllMemberShipType()
        //{
        //    return dbset.Where(w => w.Status == true).Select(s => new SelectListItem
        //    {
        //        Value = s.MemberShipTypeSeqID.ToString(),
        //        Text = s.Name
        //    }).ToList();
        //}

        public List<MemberShipTypeCampaignModel> MembershipTypewithPricePlanWithPropertiesList()
        {
            var MemberShipPricePlaneList = dbset.Join(context.Set<MembershipTypePricePlane>(), MemberShipType => MemberShipType.MemberShipTypeSeqID, MembershipTypePrice => MembershipTypePrice.MemberShipTypeSeqID, (MT, MTP) => new
            {
                MemberShipType = MT,
                MembershipTypePrices = MTP
            }).Where(x => x.MemberShipType.Status && x.MembershipTypePrices.Status == true)
            .Select(s => new MemberShipTypeCampaignModel
            {
                MemberShipTypePricePlaneSeqID = s.MembershipTypePrices.MemberShipTypePricePlaneSeqID,
                isActive = false,
                Name = s.MemberShipType.Name + " (" + s.MembershipTypePrices.PlaneName + ")",
                CampaignDefSeqID = 0
            })
            .ToList();

            return MemberShipPricePlaneList;

        }

        public List<GetAllPricePlaneSP> MembershipTypewithPricePlanWithPropertiesListForApi(string currencyName, string deviceType, int subribitionTypeStatus)
        {
            string sql = "exec GetAllPricePlaneSP " +
                "@CountryCode='" + currencyName + "' , " +
                "@subribitionTypeStatus='" + subribitionTypeStatus + "' , " +
                "@DeviceType='" + deviceType + "'";
            return context.Set<GetAllPricePlaneSP>().FromSqlRaw(sql).ToList();
        }
        public string GetEmailByUserId(string userID)
        {
            
            return context.Set<AppUser>().Where(x=>x.Id==userID).FirstOrDefault().Email;
        }
    }
}
