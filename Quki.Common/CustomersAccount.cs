using Microsoft.AspNetCore.Identity;
using System;
using Quki.Entity.Models;
using Quki.Entity.ViewModel;
using Quki.Interface;

namespace Quki.Common
{
    public class  CustomersAccount
    {
        private readonly IUserProfileService service;
        private readonly IMemberShipTypeService membershipTypeService;
        private readonly IMemberShipTypeWithCustomerService memberShipTypeWithCustomerService;
        public CustomersAccount(IUserProfileService service, IMemberShipTypeService membershipTypeService, IMemberShipTypeWithCustomerService memberShipTypeWithCustomerService)
        {
            this.service=service;
            this.membershipTypeService=membershipTypeService;
            this.memberShipTypeWithCustomerService = memberShipTypeWithCustomerService;
        }
        public SubscriberNewAcountModel getSubscriberNewAcountModel(string id, UserManager<AppUser> userMeneger)
        {
            SubscriberNewAcountModel SubscriberNewAcountModel = new SubscriberNewAcountModel();

            if (id != "")
            {
                var user2 = userMeneger.FindByIdAsync(id).Result;

                UserProfileViewModel profileViewModel = new UserProfileViewModel();
                if (id != "")
                {
                    var userProfile = service.GetUserUserProfile(id);
                    MemberShipTypeWithCustomer memberShipTypeWithCustomer = memberShipTypeWithCustomerService.getMemberShipTypeWithCustomers(id);
                    UserProfileViewModel model = new UserProfileViewModel();
                    model.issubscriber = false;
                    model.subscriberRef = "";
                    if (memberShipTypeWithCustomer != null)
                    {
                        MemberShipTypeWithCustomersPaymentChanel mm = memberShipTypeWithCustomerService.getMemberShipTypeWithCustomersPaymentChanel(id);
                        bool issubscriber = true; // IyzipayEntegration.IsSubscription(mm.ReferenceCode);
                        if (issubscriber)// burada kişi abone mi diye bakılacak
                        {
                            //SubscriptionInformation(memberShipTypeWithCustomer.ShowDecriptionToUser, pricingPlanReferenceCode);
                            //
                            model.issubscriber = issubscriber;
                            model.subscriberRef = memberShipTypeWithCustomer.ShowDecriptionToUser;
                        }
                        else
                        {
                            
                            SubscriberNewAcountModel.MemberShipPricePlanGetModelList = membershipTypeService.MembershipTypewithPricePlanList();
                        }
                    }
                    else
                    {

                        SubscriberNewAcountModel.MemberShipPricePlanGetModelList= membershipTypeService.MembershipTypewithPricePlanList();
                    }
                    model.Id = user2.Id;
                    if (userProfile != null)
                    {

                        model.Name = userProfile.Name;
                        model.SurName = userProfile.Surname;
                        model.Email = user2.Email;
                        model.PostalCode = userProfile.PostalCode;
                        model.Region = userProfile.Region;
                        model.ShippingRegion = userProfile.ShippingRegion;
                        model.Address1 = userProfile.Address1;
                        model.Address2 = userProfile.Address2;
                        model.City = userProfile.City;
                        model.Country = userProfile.Country;
                        model.DayPhone = userProfile.DayPhone;
                        model.EvePhone = userProfile.EvePhone;
                        model.MobPhone = userProfile.MobPhone;
                        model.Gender = userProfile.Gender;
                        if (userProfile.BirthDate != null && userProfile.BirthDate>=DateTime.Now.AddYears(-300))
                        {

                            model.BirthDate = userProfile.BirthDate.Value;
                        }
                        else
                        {
                            model.BirthDate = DateTime.Now;
                        }
                    }
                    SubscriberNewAcountModel.UserProfileViewModel = model;
                }
            }
            return SubscriberNewAcountModel;
        }

    }
}
