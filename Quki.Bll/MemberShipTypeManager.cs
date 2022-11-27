
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using Quki.Bll.Base;
using Quki.Common;
using Quki.Dal.Abstract;
using Quki.Entity.DtoModels;
using Quki.Entity.DtoModels.ApiModels;
using Quki.Entity.Models;
using Quki.Entity.Parameters;
using Quki.Entity.ViewModel;
using Quki.Interface;

namespace Quki.Bll
{
    public class MemberShipTypeManager : BllBase<MemberShipType, MemberShipTypeModel>, IMemberShipTypeService
    {
        public readonly IMemberShipTypeRepository repo;
        public readonly IMemberShipTypesWithPaymentChanelsRepository memberShipTypesWithPaymentChanelsRepository;
        public readonly IMemberShipTypeWithPropertiesRepository memberShipTypeWithPropertiesRepository;
        public readonly IMemberShipTypeWithCountryRepository memberShipTypeWithCountryRepository;
        public readonly IMemberShipPaymentPlanWithPaymentChannelRepository memberShipPaymentPlanWithPaymentChannelRepository;
        public readonly IMembershipTypePricePlaneRepository membershipTypePricePlaneRepository;
        public readonly ICategoryRepository categoryRepository;
        public readonly IMembershipPropertiesRepository membershipPropertiesRepository;
        public readonly ICountryRepository countryRepository;
        public readonly ICurrencyRepository currencyRepository;
        public readonly IMemberShipTypeWithCustomersProfilesRepository memberShipTypeWithCustomersProfilesRepository;
        public readonly IMemberShipTypeWithCustomerRepository memberShipTypeWithCustomerRepository;
        public readonly ICustomerRepository customerRepository;
        public readonly IPaymentChanelWithDeviceTypeRepository paymentChanelWithDeviceTypeRepository;
        public readonly IMemberShipTypeWithCustomersPaymentChanelRepository memberShipTypeWithCustomersPaymentChanelRepository;
        public readonly IDeviceTypeRepository deviceTypeRepository;
        
        public MemberShipTypeManager(IServiceProvider service) : base(service)
        {
            repo = service.GetService<IMemberShipTypeRepository>();
            memberShipTypesWithPaymentChanelsRepository = service.GetService<IMemberShipTypesWithPaymentChanelsRepository>();
            memberShipTypeWithPropertiesRepository = service.GetService<IMemberShipTypeWithPropertiesRepository>();
            memberShipTypeWithCountryRepository = service.GetService<IMemberShipTypeWithCountryRepository>();
            memberShipPaymentPlanWithPaymentChannelRepository = service.GetService<IMemberShipPaymentPlanWithPaymentChannelRepository>();
            membershipTypePricePlaneRepository = service.GetService<IMembershipTypePricePlaneRepository>();
            categoryRepository = service.GetService<ICategoryRepository>();
            membershipPropertiesRepository = service.GetService<IMembershipPropertiesRepository>();
            countryRepository = service.GetService<ICountryRepository>();
            currencyRepository = service.GetService<ICurrencyRepository>();
            memberShipTypeWithCustomersProfilesRepository = service.GetService<IMemberShipTypeWithCustomersProfilesRepository>();
            memberShipTypeWithCustomerRepository = service.GetService<IMemberShipTypeWithCustomerRepository>();
            customerRepository = service.GetService<ICustomerRepository>();
            paymentChanelWithDeviceTypeRepository = service.GetService<IPaymentChanelWithDeviceTypeRepository>();
            memberShipTypeWithCustomersPaymentChanelRepository = service.GetService<IMemberShipTypeWithCustomersPaymentChanelRepository>();
            deviceTypeRepository = service.GetService<IDeviceTypeRepository>();

        }

        public bool MemberShipTypeAddNew(MemberShipTypeMergeModel Item)
        {
            bool returnvalue = false;
            MemberShipType p = new MemberShipType();

            p.MemberShipTypeID = Item.MemberShipTypeAddModel.MemberShipTypeID;
            p.LanguageID = Item.MemberShipTypeAddModel.LanguageID;
            p.Name = Item.MemberShipTypeAddModel.Name;
            p.Remark = Item.MemberShipTypeAddModel.Remark;
            p.Code = Item.MemberShipTypeAddModel.Code;
            p.Status = Item.MemberShipTypeAddModel.Status;
            p.ShowOnHomePage = Item.MemberShipTypeAddModel.ShowOnHomePage;
            int _memberShipTypeSeqID = 0;
            if (Parameters.isHasIzicoo)
            {
                string ProductRefCode = string.Empty;
               // bool rezult = IyzipayEntegration.CreateProduct(Item.MemberShipTypeAddModel.Name, Item.MemberShipTypeAddModel.Remark, out ProductRefCode);
                //if (rezult)
                //{
                //    TAdd(p);
                //    var memeber = getLastMemberShipType();
                //    //Kategori Ata
                //    _memberShipTypeSeqID = (int)memeber.MemberShipTypeSeqID;
                //    MemberShipTypesWithPaymentChanel memberShipTypesWithPaymentChanel = new MemberShipTypesWithPaymentChanel();
                //    memberShipTypesWithPaymentChanel.MemberShipTypeSeqID = _memberShipTypeSeqID;
                //    memberShipTypesWithPaymentChanel.Name = Item.MemberShipTypeAddModel.Name;
                //    memberShipTypesWithPaymentChanel.Description = Item.MemberShipTypeAddModel.Remark;
                //    memberShipTypesWithPaymentChanel.ReferenceCode = ProductRefCode;
                //    memberShipTypesWithPaymentChanelsRepository.TAdd(memberShipTypesWithPaymentChanel);
                //}
            }
            List<MemberShipTypeWithPropertiessAddModel> propertiesList = Item.MemberShipTypeWithPropertiessAddModel;

            if (propertiesList != null)
            {
                foreach (var item in propertiesList)
                {
                    if (item.isHas)
                    {
                        memberShipTypeWithPropertiesRepository.AddMemberShipTypeWithPropertie(new MemberShipTypeWithProperties
                        {
                            MemberShipPropertiesSeqID = item.MemberShipPropertiesSeqID,
                            MemberShipTypeSeqID = _memberShipTypeSeqID
                        });
                    }
                }
            }

            return returnvalue;
        }


        public bool MemberShipTypeUpdate(MemberShipTypeMergeModel Item)
        {
            bool returnvalue = false;
            MemberShipType p = new MemberShipType();
            p.MemberShipTypeSeqID = Item.MemberShipTypeAddModel.MemberShipTypeSeqID;
            p.MemberShipTypeID = Item.MemberShipTypeAddModel.MemberShipTypeID;
            p.LanguageID = Item.MemberShipTypeAddModel.LanguageID;
            p.Name = Item.MemberShipTypeAddModel.Name;
            p.Remark = Item.MemberShipTypeAddModel.Remark;
            p.Code = Item.MemberShipTypeAddModel.Code;
            p.Status = true;
            p.ShowOnHomePage = Item.MemberShipTypeAddModel.ShowOnHomePage;


            for (int i = 0; i < Item.MemberShipPropertiesGroupModel.Count; i++)
            {
                for (int j = 0; j < Item.MemberShipPropertiesGroupModel[i].MemberShipTypeWithPropertiessAddModel.Count; j++)
                {
                    var initialValue = Item.MemberShipPropertiesGroupModel[i].MemberShipTypeWithPropertiessAddModel[j].InitialValue;
                    var endValue = Item.MemberShipPropertiesGroupModel[i].MemberShipTypeWithPropertiessAddModel[j].EndValue;
                    var memberShipTypeSeqID = Item.MemberShipPropertiesGroupModel[i].MemberShipTypeWithPropertiessAddModel[j].MemberShipTypeSeqID;
                    var memberShipPropertiesSeqID = Item.MemberShipPropertiesGroupModel[i].MemberShipTypeWithPropertiessAddModel[j].MemberShipPropertiesSeqID;
                    var isActive = Item.MemberShipPropertiesGroupModel[i].MemberShipTypeWithPropertiessAddModel[j].IsActive;
                    var isDynamic = Item.MemberShipPropertiesGroupModel[i].MemberShipTypeWithPropertiessAddModel[j].IsDynamic;
                    var isshowScreen = Item.MemberShipPropertiesGroupModel[i].MemberShipTypeWithPropertiessAddModel[j].IsshowScreen;

                    var existsProperty = memberShipTypeWithPropertiesRepository.TGetList(x => x.MemberShipTypeSeqID == memberShipTypeSeqID && x.MemberShipPropertiesSeqID == memberShipPropertiesSeqID).FirstOrDefault();

                    MemberShipTypeWithProperties memberShipTypeWithProperties = new MemberShipTypeWithProperties();


                    if (existsProperty != null) // eğer ilişki varsa güncelle hem ilişki tablosunu hemde membershipproperties tablosunu
                    {

                        existsProperty.InitialValue = Item.MemberShipPropertiesGroupModel[i].MemberShipTypeWithPropertiessAddModel[j].InitialValue;
                        existsProperty.EndValue = Item.MemberShipPropertiesGroupModel[i].MemberShipTypeWithPropertiessAddModel[j].EndValue;
                        existsProperty.IsActive = Item.MemberShipPropertiesGroupModel[i].MemberShipTypeWithPropertiessAddModel[j].IsActive;
                        existsProperty.MemberShipPropertiesSeqID = Item.MemberShipPropertiesGroupModel[i].MemberShipTypeWithPropertiessAddModel[j].MemberShipPropertiesSeqID;
                        existsProperty.MemberShipTypeSeqID = Item.MemberShipPropertiesGroupModel[i].MemberShipTypeWithPropertiessAddModel[j].MemberShipTypeSeqID;
                        existsProperty.IsshowScreen = Item.MemberShipPropertiesGroupModel[i].MemberShipTypeWithPropertiessAddModel[j].IsshowScreen;
                        //repository.UpdateMemberShipTypeWithProperties(existsProperty);
                        memberShipTypeWithPropertiesRepository.TUpdate(existsProperty);
                    }

                    else  // eğer ilişki yoksa ilişki tablosuna ekle
                    {
                        if (isActive)
                        {

                            MemberShipTypeWithProperties m = new MemberShipTypeWithProperties()
                            {
                                InitialValue = initialValue,
                                EndValue = endValue,
                                IsActive = isActive,
                                MemberShipTypeSeqID = memberShipTypeSeqID,
                                MemberShipPropertiesSeqID = memberShipPropertiesSeqID,
                                IsshowScreen = isshowScreen
                            };
                            memberShipTypeWithPropertiesRepository.AddMemberShipTypeWithPropertie(m);
                        }
                    }
                }
            }

            //repository.SaveChange();






            var list = new List<MemberShipTypeWithCountry>();
            var list2 = new List<MemberShipTypeWithCountry>();

            for (int i = 0; i < Item.CountryModel.Count; i++)
            {
                var memberShipTypeWithCountry = memberShipTypeWithCountryRepository.TGetList(x => x.IsActivated == true && x.MemberShipTypSeqID == Item.MemberShipTypeAddModel.MemberShipTypeSeqID && x.CounrtySeqID == Item.CountryModel[i].CounrtySeqID).FirstOrDefault();

                //ilişki tablosunda yoksa ve ülke seçili ise ilişki tablosuna ekle
                if (memberShipTypeWithCountry == null && Item.CountryModel[i].IsChecked == true)
                {
                    //MemberShipTypeWithCountryRepository memberShipTypeWithCountryRepository = new MemberShipTypeWithCountryRepository(context);
                    MemberShipTypeWithCountry memberShipTypeWithCountries = new MemberShipTypeWithCountry();

                    memberShipTypeWithCountries.CounrtySeqID = Item.CountryModel[i].CounrtySeqID;
                    memberShipTypeWithCountries.IsActivated = Item.CountryModel[i].IsChecked;
                    memberShipTypeWithCountries.MemberShipTypSeqID = Item.MemberShipTypeAddModel.MemberShipTypeSeqID;
                    memberShipTypeWithCountries.CreatedOn = DateTime.Now;
                    //memberShipTypeWithCountry.CreatedBy 
                    //memberShipTypeWithCountryRepository.TAdd(memberShipTypeWithCountries);

                    list.Add(memberShipTypeWithCountries);
                }

                //ilişki tablosunda varsa ve ülke silinmişse yani false ise ve ilişkilendirilmek isteniyorsa
                if (memberShipTypeWithCountry != null)
                {
                    MemberShipTypeWithCountry memberShipTypeWithCountries = new MemberShipTypeWithCountry();

                    memberShipTypeWithCountries.MemberShipTypeWithCountrySeqID = memberShipTypeWithCountry.MemberShipTypeWithCountrySeqID;
                    memberShipTypeWithCountries.CounrtySeqID = Item.CountryModel[i].CounrtySeqID;
                    memberShipTypeWithCountries.IsActivated = Item.CountryModel[i].IsChecked;
                    memberShipTypeWithCountries.MemberShipTypSeqID = Item.MemberShipTypeAddModel.MemberShipTypeSeqID;
                    //MemberShipTypeWithCountryRepository memberShipTypeWithCountryRepository = new MemberShipTypeWithCountryRepository(context);
                    //memberShipTypeWithCountryRepository.TUpdate(memberShipTypeWithCountries);
                    list2.Add(memberShipTypeWithCountries);
                }
            }
            memberShipTypeWithCountryRepository.TAddRange(list);
            memberShipTypeWithCountryRepository.TUpdateRange(list2);
            //memberShipTypeWithCountryRepository.SaveChange();
            //repository.SaveChange();    

            if (Parameters.isHasIzicoo)
            {

                var value = memberShipTypesWithPaymentChanelsRepository.TGetList(i => i.MemberShipTypeSeqID == Item.MemberShipTypeAddModel.MemberShipTypeSeqID).FirstOrDefault();
                if (value != null)
                {
                    //bool rezult = IyzipayEntegration.UpdateProduct(Item.MemberShipTypeAddModel.Name, Item.MemberShipTypeAddModel.Remark, value.ReferenceCode.ToString());
                    //if (rezult)
                    //{
                    //    value.Name = Item.MemberShipTypeAddModel.Name;
                    //    value.Description = Item.MemberShipTypeAddModel.Remark;
                    //    memberShipTypesWithPaymentChanelsRepository.TUpdate(value);
                    //    //Repository.SaveChange();
                    //    TUpdate(p);
                    //    //SaveChange();
                    //}
                }
            }


            return returnvalue;
        }
        public bool MemberShipTypeDelete(int id)
        {

            //MemberShip Tipe direk delete edilmeyecek statusu false yapılacak. abonelikte veya başka işlemlerde kullaılmış olabilir
            var Item = TgetItemByID(id);
            Item.Status = false;

            if (Parameters.isHasIzicoo)// izico Bağlantıları Siliniyor.
            {
                var value2 = memberShipPaymentPlanWithPaymentChannelRepository.TGetList(i => i.MemberShipTypeSeqID == id).ToList();
                if (value2 != null)
                {
                    var activeMemberShipTypePrice = membershipTypePricePlaneRepository.TGetList(x => x.MemberShipTypePricePlaneSeqID.Equals(id) && x.Status.Equals(true)).ToList();
                    if (activeMemberShipTypePrice.Count > 0)
                    {
                        return false;
                    }

                }
                var value = memberShipTypesWithPaymentChanelsRepository.TGetList(i => i.MemberShipTypeSeqID == id).FirstOrDefault();
                if (value != null)
                {
                   // IyzipayEntegration.DeleteProduct(value.ReferenceCode);
                    TUpdate(Item);
                }
            }
            return true;
        }
        public List<MemberShipType> MemberShipTypeGetAllActiveList()
        {
            var value = TGetList(i => i.Status == true).ToList();
            return value;
        }

        public MemberShipTypeMergeModel MemberShipTypeGetUpdateValue(int id)
        {
            var Item = TgetItemByID(id);
            var dd = GetMemberShipPriceBymembershipTypeSeq(id);
            MemberShipTypeMergeModel mymodel = new MemberShipTypeMergeModel();
            MemberShipTypeAddModel newModel = new MemberShipTypeAddModel();

            newModel.MemberShipTypeSeqID = Item.MemberShipTypeSeqID;
            newModel.LanguageID = Item.LanguageID;
            newModel.Name = Item.Name;
            newModel.Code = Item.Code;
            newModel.MemberShipTypeID = Item.MemberShipTypeID;
            newModel.Remark = Item.Remark;
            newModel.ShowOnHomePage = Item.ShowOnHomePage;
            mymodel.MemberShipTypeAddModel = newModel;
            // üye tipine ait özellikleri getirir
            //var hasMemberShipProperties = GetPropertiesByMemberShipType(id);

            var allProperties = membershipPropertiesRepository.GetPropertiesAllWithValueTypes();

            var membershipProperties = memberShipTypeWithPropertiesRepository.TGetList(p => p.MemberShipTypeSeqID == newModel.MemberShipTypeSeqID).ToList();
            var allCountry = countryRepository.TGetList(x => x.Status == true).ToList();

            List<CountryModel> countryModelList = new List<CountryModel>();


            foreach (var item in allCountry)
            {
                var memberShipTypeWithCountry = memberShipTypeWithCountryRepository.TGetList(x => x.IsActivated == true && x.MemberShipTypSeqID == newModel.MemberShipTypeSeqID && x.CounrtySeqID == item.CounrtySeqID).FirstOrDefault();

                CountryModel countryModel = new CountryModel();

                countryModel.Name = item.CountryName;
                countryModel.CounrtySeqID = item.CounrtySeqID;
                //ilişki yoksa
                if (memberShipTypeWithCountry == null)
                {
                    countryModel.IsChecked = false;
                    countryModel.CounrtySeqID = item.CounrtySeqID;

                }
                //ilişki varsa
                else
                {
                    countryModel.IsChecked = true;
                    countryModel.CounrtySeqID = item.CounrtySeqID;
                }
                countryModelList.Add(countryModel);

            }

            List<MemberShipTypeWithPropertiessAddModel> memberShipPropertiesList = new List<MemberShipTypeWithPropertiessAddModel>();
            List<MemberShipPropertiesGroupModel> memberShipPropertiesGroupModelList = new List<MemberShipPropertiesGroupModel>();
            foreach (var item in allProperties)
            {
                var memberShipTypeWithPropertiesInitialValue = memberShipTypeWithPropertiesRepository.GetMemberShipTypeWithProperties(Item.MemberShipTypeSeqID, item.MemberShipPropertiesSeqID);
                MemberShipTypeWithPropertiessAddModel model = new MemberShipTypeWithPropertiessAddModel();
                model.MemberShipPropertiesSeqID = item.MemberShipPropertiesSeqID;
                model.Name = item.Name;
                model.MemberShipTypeSeqID = id;
                model.Type = item.Type;
                model.GroupID = item.GroupID;
                model.ValueTypeSeqId = item.ValueTypeSeqId;
                model.ValueTypeName = item.ValueTypeName;
                model.ValueTypeSecondName = item.ValueTypeSecondName;
                model.IsDynamic = item.IsDynamic;
                model.IsActive = membershipProperties.Where(a => a.MemberShipPropertiesSeqID == model.MemberShipPropertiesSeqID).FirstOrDefault() == null ? false : membershipProperties.Where(a => a.MemberShipPropertiesSeqID == model.MemberShipPropertiesSeqID).FirstOrDefault().IsActive.Value;
                model.IsshowScreen = membershipProperties.Where(a => a.MemberShipPropertiesSeqID == model.MemberShipPropertiesSeqID).FirstOrDefault() == null ? false : membershipProperties.Where(a => a.MemberShipPropertiesSeqID == model.MemberShipPropertiesSeqID).FirstOrDefault().IsshowScreen;
                model.InitialValue = model.IsActive ? memberShipTypeWithPropertiesInitialValue?.InitialValue : item.InitialValue;
                model.EndValue = model.IsActive ? memberShipTypeWithPropertiesInitialValue?.EndValue : item.EndValue;
                memberShipPropertiesList.Add(model);

                MemberShipPropertiesGroupModel memberShipPropertiesGroupModel = new MemberShipPropertiesGroupModel();
                memberShipPropertiesGroupModel.GroupID = item.GroupID;
                bool addGroup = true;
                for (int i = 0; i < memberShipPropertiesGroupModelList.Count; i++)
                {
                    if (memberShipPropertiesGroupModelList[i].GroupID == memberShipPropertiesGroupModel.GroupID)
                    {
                        addGroup = false;
                    }
                }
                if (addGroup)
                {
                    memberShipPropertiesGroupModelList.Add(memberShipPropertiesGroupModel);
                }
            }

            List<MemberShipPropertiesGroupModel> memberShipPropertiesGroupList = new List<MemberShipPropertiesGroupModel>();
            foreach (var group in memberShipPropertiesGroupModelList)
            {
                MemberShipPropertiesGroupModel model = new MemberShipPropertiesGroupModel();
                model.GroupID = group.GroupID;
                List<MemberShipTypeWithPropertiessAddModel> list = new List<MemberShipTypeWithPropertiessAddModel>();
                foreach (var property in memberShipPropertiesList)
                {
                    if (group.GroupID == property.GroupID)
                    {
                        list.Add(property);
                    }
                }
                model.MemberShipTypeWithPropertiessAddModel = list;
                memberShipPropertiesGroupList.Add(model);
            }

            mymodel.MemberShipPropertiesGroupModel = memberShipPropertiesGroupList;

            var membershipTypePricePlane = membershipTypePricePlaneRepository.TGetList(p => p.MemberShipTypeSeqID == Item.MemberShipTypeSeqID && p.Status == true).ToList();
            List<MembershipTypePricePlaneModel> list2 = new List<MembershipTypePricePlaneModel>();


            foreach (var item in membershipTypePricePlane)
            {
                MembershipTypePricePlaneModel model = new MembershipTypePricePlaneModel();
                model.MemberShipTypePricePlaneSeqID = item.MemberShipTypePricePlaneSeqID;
                model.MemberShipTypeSeqID = item.MemberShipTypeSeqID;
                model.PaymentPeriod = item.PaymentPeriod;
                model.PlaneName = item.PlaneName;
                model.Price = item.Price;
                model.Status = item.Status;
                model.TrailPeriodDay = item.TrailPeriodDay;
                list2.Add(model);
            }
            mymodel.MembershipTypePricePlane = list2;
            mymodel.CountryModel = countryModelList;
            return mymodel;
        }
        public MemberShipType getLastMemberShipType()
        {
            return TGetList().OrderByDescending(u => u.MemberShipTypeSeqID).FirstOrDefault();
        }

        public List<MembershipProperties> GetPropertiesByMemberShipType(int MemberShipTypeSeqID)// üye tipine ait özellikleri getirir
        {

            return TGetList().Join(memberShipTypeWithPropertiesRepository.TGetList(), MemberShipType => MemberShipType.MemberShipTypeSeqID, MemberShipTypeWithProperties => MemberShipTypeWithProperties.MemberShipTypeSeqID, (MT, MTP) => new
            {
                MemberShipType = MT,
                MemberShipTypeWithProperties = MTP
            }).Join(membershipPropertiesRepository.TGetList(), iki => iki.MemberShipTypeWithProperties.MemberShipPropertiesSeqID, MembershipProperties => MembershipProperties.MemberShipPropertiesSeqID, (MTP, MP) => new
            {
                MemberShipType = MTP.MemberShipType,
                MembershipProperties = MP,
                MemberShipTypeWithProperties = MTP.MemberShipTypeWithProperties
            }).Where(I => I.MemberShipType.MemberShipTypeSeqID == MemberShipTypeSeqID).Select(I => new MembershipProperties
            {
                Name = I.MembershipProperties.Name,
                MemberShipPropertiesSeqID = I.MembershipProperties.MemberShipPropertiesSeqID,
                InitialValue = I.MemberShipTypeWithProperties.InitialValue,
                EndValue = I.MemberShipTypeWithProperties.EndValue

            }).ToList();

        }
        public MembershipTypePricePlane GetMemberShipPriceBymembershipTypeSeq(int membershipTypeSeq)
        {
            return membershipTypePricePlaneRepository.TGetList(i => i.MemberShipTypeSeqID == membershipTypeSeq && i.Status == true).FirstOrDefault();
        }


        public List<MembershipProperties> GetMembershipProperties(int id)
        {
            return membershipPropertiesRepository.TGetList(i => i.MemberShipPropertiesSeqID == id && i.Status == true).ToList();
        }


        public List<MemberShipTypewithPrice> getMembershipTypewithPriceList()
        {

            return TGetList().Join(membershipTypePricePlaneRepository.TGetList(), MemberShipType => MemberShipType.MemberShipTypeSeqID, MembershipTypePrice => MembershipTypePrice.MemberShipTypeSeqID, (MT, MTP) => new
            {
                MemberShipType = MT,
                MembershipTypePrices = MTP
            }).Where(I => I.MemberShipType.Status == true).Select(I => new MemberShipTypewithPrice
            {
                //Name,MemberShipTypeSeqID,Price,BaseCurrencyPrice,PaymentPeriod
                Name = I.MemberShipType.Name,
                MemberShipTypeSeqID = I.MemberShipType.MemberShipTypeSeqID,
                Price = I.MembershipTypePrices.Price,
                PaymentPeriod = I.MembershipTypePrices.PaymentPeriod,
                ImageThumpPath = I.MemberShipType.ImageThumpPath
            }).ToList();
        }
        public List<GetAllMemberShipTypeModel> MembershipTypewithPricePlanWithPropertiesListForApi
            (string currencyName, string deviceType, int subribitionTypeStatus,int languageId)
        {
            List<GetAllMemberShipTypeModel> memberShipTypePricePlaneWithPropertiesModelList
                = new List<GetAllMemberShipTypeModel>();

            var sonuc = repo.MembershipTypewithPricePlanWithPropertiesListForApi(currencyName, deviceType, subribitionTypeStatus);
            if (sonuc != null)
            {
                if (sonuc.Count > 0)
                {
                    foreach (var item in sonuc)
                    {
                        GetAllMemberShipTypeModel memberShipTypePricePlaneWithPropertiesModel = new GetAllMemberShipTypeModel();
                        GetAllMemberShipTypePricePlaneModel membershipTypePricePlane = new GetAllMemberShipTypePricePlaneModel();
                        List<MembershipProperties> membershipPropertiesList = new List<MembershipProperties>();
                        memberShipTypePricePlaneWithPropertiesModel.memberShipTypeId = item.MemberShipTypeSeqID;
                        memberShipTypePricePlaneWithPropertiesModel.memberShipTypeName = item.Name;
                        membershipTypePricePlane.memberShipTypeId = item.MemberShipTypeSeqID;
                        membershipTypePricePlane.pricePlaneId = item.MemberShipTypePricePlaneSeqID;
                        membershipTypePricePlane.pricePlaneName = item.PlaneName;
                        membershipTypePricePlane.price = item.Price;
                        membershipTypePricePlane.autoRenewalCount = item.AutoRenewalCount;
                        membershipTypePricePlane.freeDay = item.FreeDay;
                        membershipTypePricePlane.paymentPeriodName = item.PaymentPeriodName;
                        membershipTypePricePlane.currencyName = item.CurrenyName;
                        membershipTypePricePlane.pricePlaneReferansCode = item.pricePlaneReferansCode;
                        memberShipTypePricePlaneWithPropertiesModel.pricePlane = membershipTypePricePlane;

                        try { membershipPropertiesList = memberShipTypeWithPropertiesRepository.GetMemberShipTypeWithProperties(item.MemberShipTypeSeqID).Where(x=>x.LanguageID==languageId).ToList(); } catch { }
                        if (membershipPropertiesList != null)
                        {
                            if (membershipPropertiesList.Count > 0)
                            {
                                memberShipTypePricePlaneWithPropertiesModel.membershipTypePropertyList = new List<GetAllMemberShipTypePropertiesModel>();
                                foreach (var itemProperties in membershipPropertiesList)
                                {
                                    GetAllMemberShipTypePropertiesModel prperties = new GetAllMemberShipTypePropertiesModel();
                                    prperties.propertyId = itemProperties.MemberShipPropertiesSeqID;
                                    prperties.languageID = itemProperties.LanguageID;
                                    prperties.Name = itemProperties.Name.Trim();
                                    memberShipTypePricePlaneWithPropertiesModel.membershipTypePropertyList.Add(prperties);
                                }
                            }
                        }
                        List<PaymentChannel> paymentChael = new List<PaymentChannel>();
                        try { paymentChael = paymentChanelWithDeviceTypeRepository.GetPaymentChanelListByDeviceTypeAndPricePlane(item.MemberShipTypePricePlaneSeqID, deviceType); } catch { }
                        if (paymentChael != null)
                        {
                            if (paymentChael.Count > 0)
                            {
                                memberShipTypePricePlaneWithPropertiesModel.membershipTypePaymentChanelList = new List<GetAllMemberShipTypePaymentChanelModel>();
                                foreach (var itemChanel in paymentChael)
                                {
                                    GetAllMemberShipTypePaymentChanelModel payChael = new GetAllMemberShipTypePaymentChanelModel();
                                    payChael.paymentChaneId = (int)itemChanel.PaymentChannelID;
                                    payChael.paymentChaneName = itemChanel.PaymentChannellName;
                                    memberShipTypePricePlaneWithPropertiesModel.membershipTypePaymentChanelList.Add(payChael);
                                }
                            }
                        }
                        memberShipTypePricePlaneWithPropertiesModelList.Add(memberShipTypePricePlaneWithPropertiesModel);
                    }
                }
            }

            //    return MemberShipPricePlaneList;

            return memberShipTypePricePlaneWithPropertiesModelList;
        }
        public List<MemberShipPricePlanGetModel> MembershipTypewithPricePlanList()
        {

            return TGetList().Join(membershipTypePricePlaneRepository.TGetList(), MemberShipType => MemberShipType.MemberShipTypeSeqID, MembershipTypePrice => MembershipTypePrice.MemberShipTypeSeqID, (MT, MTP) => new
            {
                MemberShipType = MT,
                MembershipTypePrices = MTP
            }).Where(I => I.MemberShipType.Status && I.MemberShipType.ShowOnHomePage && I.MembershipTypePrices.Status == true).Select(I => new MemberShipPricePlanGetModel
            {
                //Name,MemberShipTypeSeqID,Price,BaseCurrencyPrice,PaymentPeriod
                MemberShipTypeSeqID = I.MemberShipType.MemberShipTypeSeqID,
                Name = I.MemberShipType.Name,
                Remark = I.MemberShipType.Remark,
                MemberShipTypePricePlaneSeqID = I.MembershipTypePrices.MemberShipTypePricePlaneSeqID,
                PlaneName = I.MembershipTypePrices.PlaneName,
                Price = I.MembershipTypePrices.Price,
                PaymentPeriodName = I.MembershipTypePrices.PaymentPeriod == 1 ? "AYLIK" : "HAFTALIK",
                PaymentPeriod = I.MembershipTypePrices.PaymentPeriod,
                AutoRenewalCount = I.MembershipTypePrices.AutoRenewalCount,
                TrailPeriodDay = I.MembershipTypePrices.TrailPeriodDay
            }).ToList();
        }
        public List<MemberShipTypePricePlaneWithPropertiesModel> MembershipTypewithPricePlanWithPropertiesList(int CountrySeqID,int pricePlaneTypeId,int languageId)
        {
            List<MemberShipTypePricePlaneWithPropertiesModel> memberShipTypePricePlaneWithPropertiesModelList = new List<MemberShipTypePricePlaneWithPropertiesModel>();
            var list = membershipTypePricePlaneRepository.TGetList();
            var MemberShipPricePlaneList = TGetList().Join(membershipTypePricePlaneRepository.TGetList(), MemberShipType => MemberShipType.MemberShipTypeSeqID, MembershipTypePrice => MembershipTypePrice.MemberShipTypeSeqID, (MT, MTP) => new
            {
                MemberShipType = MT,
                MembershipTypePrices = MTP
            }).Where(x => x.MemberShipType.Status && x.MemberShipType.ShowOnHomePage && x.MembershipTypePrices.Status == true && x.MembershipTypePrices.ShowCustomers == true && x.MembershipTypePrices.MemberShipPricePlaneType==pricePlaneTypeId).ToList();

            var sonuc = MemberShipPricePlaneList.Join(memberShipTypeWithCountryRepository.TGetList(), result => result.MemberShipType.MemberShipTypeSeqID, MemberShipTypeWithCountry => MemberShipTypeWithCountry.MemberShipTypSeqID,
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
                CurrenyName = currencyRepository.TgetItemByID(I.result.MembershipTypePrices.CurrencyID.Value).CurrencyName

            }).ToList();
            foreach (var item in sonuc)
            {
                MemberShipTypePricePlaneWithPropertiesModel memberShipTypePricePlaneWithPropertiesModel = new MemberShipTypePricePlaneWithPropertiesModel();
                MembershipTypePricePlane membershipTypePricePlane = new MembershipTypePricePlane();
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
                membershipPropertiesList = memberShipTypeWithPropertiesRepository.GetMemberShipTypeWithPropertiesWithLanguage(item.MemberShipTypeSeqID,languageId);
                foreach (var itemProperties in membershipPropertiesList)
                {
                    memberShipTypePricePlaneWithPropertiesModel.MembershipProperties.Add(itemProperties);
                }
                memberShipTypePricePlaneWithPropertiesModelList.Add(memberShipTypePricePlaneWithPropertiesModel);
            }
            return memberShipTypePricePlaneWithPropertiesModelList;
        }
        public List<MemberShipTypePricePlaneWithPropertiesForGiftModel> MembershipTypewithPricePlanWithPropertiesForGiftList(int CountrySeqID,int pricePlaneTypeId)
        {
            List<MemberShipTypePricePlaneWithPropertiesForGiftModel> memberShipTypePricePlaneWithPropertiesModelList = new List<MemberShipTypePricePlaneWithPropertiesForGiftModel>();
            var list = membershipTypePricePlaneRepository.TGetList();
            var MemberShipPricePlaneList = TGetList().Join(membershipTypePricePlaneRepository.TGetList(), MemberShipType => MemberShipType.MemberShipTypeSeqID, MembershipTypePrice => MembershipTypePrice.MemberShipTypeSeqID, (MT, MTP) => new
            {
                MemberShipType = MT,
                MembershipTypePrices = MTP
            }).Where(x => x.MemberShipType.Status && x.MemberShipType.ShowOnHomePage && x.MembershipTypePrices.Status == true && x.MembershipTypePrices.ShowCustomers == true && x.MembershipTypePrices.MemberShipPricePlaneType==pricePlaneTypeId).OrderBy(x => x.MembershipTypePrices.DisplayOrderNumber).ToList();

            var sonuc = MemberShipPricePlaneList.Join(memberShipTypeWithCountryRepository.TGetList(), result => result.MemberShipType.MemberShipTypeSeqID, MemberShipTypeWithCountry => MemberShipTypeWithCountry.MemberShipTypSeqID,
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
                CurrenyName = currencyRepository.TgetItemByID(I.result.MembershipTypePrices.CurrencyID.Value).CurrencyName

            }).ToList().OrderByDescending(x=>x.Price);

            foreach (var item in sonuc)
            {
                MemberShipTypePricePlaneWithPropertiesForGiftModel memberShipTypePricePlaneWithPropertiesModel = new MemberShipTypePricePlaneWithPropertiesForGiftModel();
                MembershipTypePricePlane membershipTypePricePlane = new MembershipTypePricePlane();
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
            return memberShipPaymentPlanWithPaymentChannelRepository.TGetList(i => i.MemberShipTypePricePlaneSeqID == MemberShipTypePricePlaneSeqID).FirstOrDefault();
        }
        public MemberShipType GetMemberShipTypeByMemberShipTypePricePlaneSeqID(int MemberShipTypePricePlaneSeqID)
        {
            var MemberShipPaymentPlanInfo = memberShipPaymentPlanWithPaymentChannelRepository.TGetList(i => i.MemberShipTypePricePlaneSeqID == MemberShipTypePricePlaneSeqID).FirstOrDefault();
            var MemberShipTypeInfo = TGetList(x => x.MemberShipTypeSeqID.Equals(MemberShipPaymentPlanInfo.MemberShipTypeSeqID)).FirstOrDefault();
            return MemberShipTypeInfo;
        }



        public List<SelectListItem> GetAllMemberShipType()
        {
            return TGetList(w => w.Status == true).Select(s => new SelectListItem
            {
                Value = s.MemberShipTypeSeqID.ToString(),
                Text = s.Name
            }).ToList();
        }

        public List<MemberShipTypeCampaignModel> MembershipTypewithPricePlanWithPropertiesList()
        {
            var MemberShipPricePlaneList = TGetList().Join(membershipTypePricePlaneRepository.TGetList(), MemberShipType => MemberShipType.MemberShipTypeSeqID, MembershipTypePrice => MembershipTypePrice.MemberShipTypeSeqID, (MT, MTP) => new
            {
                MemberShipType = MT,
                MembershipTypePrices = MTP
            }).Where(x => x.MemberShipType.Status && x.MemberShipType.ShowOnHomePage && x.MembershipTypePrices.Status == true && x.MembershipTypePrices.ShowCustomers == true)
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

        public List<MemberShipTypeCampaignModel> MembershipTypewithPricePlanWithPropertiesListByCouponCode(string code)
        {


            var MemberShipPricePlaneList = TGetList().Join(membershipTypePricePlaneRepository.TGetList(), MemberShipType => MemberShipType.MemberShipTypeSeqID, MembershipTypePrice => MembershipTypePrice.MemberShipTypeSeqID, (MT, MTP) => new
            {
                MemberShipType = MT,
                MembershipTypePrices = MTP
            }).Where(x => x.MemberShipType.Status && x.MemberShipType.ShowOnHomePage && x.MembershipTypePrices.Status == true && x.MembershipTypePrices.ShowCustomers == true)
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

        public MemberShipTypeInfoApiModel SubcriptionInfoByProfilId(string ProfilId,int languageID)
        {
            MemberShipTypeInfoApiModel memberShipTypeModel = new MemberShipTypeInfoApiModel();
            string userId = ProfilId;
            if (memberShipTypeWithCustomersProfilesRepository.TGetList(x => x.ProfileUserID == ProfilId).FirstOrDefault() != null)
            {
                userId = memberShipTypeWithCustomersProfilesRepository.TGetList(x => x.ProfileUserID == ProfilId).FirstOrDefault().UserID;
            }
            var userMemberShipTypeCustomer = memberShipTypeWithCustomerRepository.TGetList(x => x.Id == userId && x.IsActive==true).FirstOrDefault();
            if (userMemberShipTypeCustomer !=null)
            {
                int userMemberShipTypeId = userMemberShipTypeCustomer.MemberShipTypeSeqID;
                int userMemberShipTypePricePlaneId = userMemberShipTypeCustomer.MemberShipTypePricePlaneSeqID;
                var userMemberShipType = repo.TGetList(x => x.MemberShipTypeSeqID.Equals(userMemberShipTypeId)).FirstOrDefault();
                var userMemberShipTypePricePlane = membershipTypePricePlaneRepository.TGetList(x => x.MemberShipTypePricePlaneSeqID.Equals(userMemberShipTypePricePlaneId)).FirstOrDefault();
                var memberShipProperties = memberShipTypeWithPropertiesRepository.GetMemberShipTypeWithProperties(userMemberShipTypeId).Where(x=>x.LanguageID==languageID).ToList();
                MembershipPropertiesApiModel membershipProperties;
                List<MembershipPropertiesApiModel> membershipPropertieslist = new List<MembershipPropertiesApiModel>();

                foreach (var item in memberShipProperties)
                {
                    membershipProperties = new MembershipPropertiesApiModel();
                    membershipProperties.languageID = item.LanguageID;
                    membershipProperties.Name = item.Name.Trim();
                    membershipProperties.propertyId = item.MemberShipPropertiesSeqID;
                    membershipPropertieslist.Add(membershipProperties);
                }
                DateTime startDate = userMemberShipTypeCustomer.StartDateTime; ;
                DateTime endDate = userMemberShipTypeCustomer.EndDateTime; ;
                int mount = (DateTime.Now - startDate).Days;
                mount = mount / 30;
                endDate = startDate.AddMonths(mount + 1);
                memberShipTypeModel.pricePlane.pricePlaneId = userMemberShipTypePricePlaneId;
                memberShipTypeModel.pricePlane.memberShipTypeId = userMemberShipTypeId;
                memberShipTypeModel.memberShipTypeWithPropertiessList = membershipPropertieslist;
                memberShipTypeModel.pricePlane.PaymentPeriod = userMemberShipTypePricePlane.PaymentPeriod;
                memberShipTypeModel.pricePlane.currencyName = currencyRepository.TGetList(x => x.CurrencySeqID == userMemberShipTypePricePlane.CurrencyID).FirstOrDefault().CurrencyName;
                memberShipTypeModel.pricePlane.endDate = endDate;
                memberShipTypeModel.pricePlane.startDate = startDate;
                memberShipTypeModel.pricePlane.pricePlaneName = userMemberShipTypePricePlane.PlaneName;
                int userPaymentSeqId = memberShipTypeWithCustomerRepository.TGetList(x => x.Id == userId).FirstOrDefault().MemberShipTypeWithCustomerSeqID;
                int paymentChannelId = memberShipTypeWithCustomersPaymentChanelRepository.TGetList(x => x.MemberShipTypeWithCustomerSeqID == userPaymentSeqId).FirstOrDefault().MemberShipWithPamentChannelSeqID;
                memberShipTypeModel.Email = repo.GetEmailByUserId(userId);
                memberShipTypeModel.MemberShipTypeID = userMemberShipTypeId;
                memberShipTypeModel.MemberShipTypeSeqID = userMemberShipType.MemberShipTypeSeqID;
                memberShipTypeModel.pricePlane.pricePlaneReferansCode = memberShipPaymentPlanWithPaymentChannelRepository.TGetList(x => x.MemberShipTypePricePlaneSeqID == userMemberShipTypePricePlaneId && x.PamentChannelSeqID == paymentChannelId).FirstOrDefault().ReferenceCode;
                memberShipTypeModel.pricePlane.CurrencyBaseSymbol = currencyRepository.TGetList(x => x.CurrencySeqID == userMemberShipTypePricePlane.CurrencyID).FirstOrDefault().CurrencyBaseSymbol;
                memberShipTypeModel.pricePlane.price = userMemberShipTypePricePlane.Price;
                memberShipTypeModel.pricePlane.priceText = memberShipTypeModel.pricePlane.CurrencyBaseSymbol + userMemberShipTypePricePlane.Price;
                memberShipTypeModel.pricePlane.freeDay = userMemberShipTypePricePlane.TrailPeriodDay.Value;
               
                return memberShipTypeModel;
            }
            return memberShipTypeModel;
        }

        public List<GetAllMemberShipTypeReferansCodeModel> MembershipTypewithPricePlanReferancCodeListForApi(string deviceType)
        {
            short deviceTypeId=deviceTypeRepository.TGetList(x => x.DeviceTypeName == deviceType).FirstOrDefault().DeviceTypeSeqID;
            int PaymentChannelSeqId=paymentChanelWithDeviceTypeRepository.TGetList(x => x.DeviceTypeSeqID == deviceTypeId).FirstOrDefault().PaymentChanelSeqID.Value;
            var list = memberShipPaymentPlanWithPaymentChannelRepository.TGetList(x => x.PamentChannelSeqID == PaymentChannelSeqId);
            return list.Join(memberShipTypeWithCountryRepository.TGetList(), msppwpc => msppwpc.MemberShipTypeSeqID, mstwc => mstwc.MemberShipTypSeqID, (MSPCTWC, MSTWC) => new
           {
               MemberShipPaymentPlanWithPaymentChannel = MSPCTWC,
               MemberShipTypeWithCountry = MSTWC
           }).Where(I => I.MemberShipTypeWithCountry.CounrtySeqID == 2).Select(I => new GetAllMemberShipTypeReferansCodeModel
           {
               pricePlaneReferansCode = I.MemberShipPaymentPlanWithPaymentChannel.ReferenceCode,
               pricePlaneId=I.MemberShipPaymentPlanWithPaymentChannel.MemberShipTypePricePlaneSeqID
               
           }).ToList();
            
        }

    }
}
