
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Quki.Dal.Abstract;
using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;
using Quki.Entity.ViewModel;

namespace Quki.Dal.Concrete.Entityframework.Repostories
{
    public class UserProfileRepository : GenericRepository<UserProfile>, IUserProfileRepository
    {
        public UserProfileRepository(DbContext context) : base(context)
        {
            
        }
        //public UserProfile GetUserUserProfile(string userID)
        //{
        //    var userProfile = dbset.Where(I => I.Id == userID).FirstOrDefault();
        //    return userProfile;
        //}
        public bool AddORUpdateUserProfile(UserProfileViewModel userProfileViewModel)
        {
            bool result = false;
            var userProfile = dbset.Where(I => I.Id == userProfileViewModel.Id).FirstOrDefault();
            if (userProfile != null)
            {
                if (userProfileViewModel.Name != null)
                    userProfile.Name = userProfileViewModel.Name;
                if (userProfileViewModel.SurName != null)
                    userProfile.Surname = userProfileViewModel.SurName;
                if (userProfileViewModel.PostalCode != null)
                    userProfile.PostalCode = userProfileViewModel.PostalCode;
                if (userProfileViewModel.Region != null)
                    userProfile.Region = userProfileViewModel.Region;
                if (userProfileViewModel.ShippingRegion != null)
                    userProfile.ShippingRegion = userProfileViewModel.ShippingRegion;
                if (userProfileViewModel.Address1 != null)
                    userProfile.Address1 = userProfileViewModel.Address1;
                if (userProfileViewModel.Address2 != null)
                    userProfile.Address2 = userProfileViewModel.Address2;
                if (userProfileViewModel.City != null)
                    userProfile.City = userProfileViewModel.City;
                if (userProfileViewModel.Country != null)
                    userProfile.Country = userProfileViewModel.Country;
                if (userProfileViewModel.DayPhone != null)
                    userProfile.DayPhone = userProfileViewModel.DayPhone;
                if (userProfileViewModel.EvePhone != null)
                    userProfile.EvePhone = userProfileViewModel.EvePhone;
                if (userProfileViewModel.MobPhone != null)
                    userProfile.MobPhone = userProfileViewModel.MobPhone;
                if (userProfileViewModel.Gender != null)
                    userProfile.Gender = userProfileViewModel.Gender;
                if (userProfileViewModel.BirthDate != null)
                    userProfile.BirthDate = userProfileViewModel.BirthDate;

                TUpdate(userProfile);
            }
            else
            {
                UserProfile user = new UserProfile();
                user.Id = userProfileViewModel.Id;
                user.PostalCode = userProfileViewModel.PostalCode;
                user.Region = userProfileViewModel.Region;
                user.ShippingRegion = userProfileViewModel.ShippingRegion;
                user.Address1 = userProfileViewModel.Address1;
                user.Address2 = userProfileViewModel.Address2;
                user.City = userProfileViewModel.City;
                user.Country = userProfileViewModel.Country;
                user.DayPhone = userProfileViewModel.DayPhone;
                user.EvePhone = userProfileViewModel.EvePhone;
                user.MobPhone = userProfileViewModel.MobPhone;
                user.Gender = userProfileViewModel.Gender;
                user.BirthDate = userProfileViewModel.BirthDate;
                TAdd(user);
            }
            result = true;

            return result;
        }

        //public bool ControlUserProfileForCheckOut(int languageId,string id, out string ErrorMessage)
        //{
        //    ErrorMessage = "";
        //    UserProfile userProfile = GetUserUserProfile(id);
        //    if (userProfile != null)
        //    {
        //        if (userProfile.Address1 == null || userProfile.Address1 == "")
        //        {
        //            ErrorMessage = MultiLanguageOmni.ReadResourceKey.GetString("ErrorAdress", "MultiLanguageOmni.Index");
        //            return false;
        //        }
        //        if (userProfile.City == null || userProfile.City == "")
        //        {
        //            ErrorMessage = MultiLanguageOmni.ReadResourceKey.GetString("ErrorCity", "MultiLanguageOmni.Index");
        //            return false;
        //        }
        //        if (userProfile.Country == null || userProfile.Country == "")
        //        {
        //            ErrorMessage = MultiLanguageOmni.ReadResourceKey.GetString("ErrorCountry", "MultiLanguageOmni.Index");
        //            return false;
        //        }
        //        if (userProfile.MobPhone == null || userProfile.MobPhone == "")
        //        {
        //            ErrorMessage = MultiLanguageOmni.ReadResourceKey.GetString("ErrorPhone", "MultiLanguageOmni.Index");
        //            return false;
        //        }
        //        if (languageId!=1)
        //        if (userProfile.PostalCode == null || userProfile.PostalCode == "")
        //        {
        //            ErrorMessage = MultiLanguageOmni.ReadResourceKey.GetString("ErrorPostaCode", "MultiLanguageOmni.Index");
        //                return false;
        //        }

        //        return true;
        //    }
        //    else
        //    {
        //        ErrorMessage = ErrorMessage = MultiLanguageOmni.ReadResourceKey.GetString("AccountInformationError", "MultiLanguageOmni.Index");
        //        return false;
        //    }
        //}

        //public bool ControlCartInformation(SubscriptionInitializeModel subscriptionInitializeModel, out string ErrorMessage)
        //{
        //    ErrorMessage = "";

        //    if (subscriptionInitializeModel.PaymentCard != null)
        //    {
        //        if (subscriptionInitializeModel.PaymentCard.CardNumber1 == null || subscriptionInitializeModel.PaymentCard.CardNumber1 == "")
        //        {
        //            ErrorMessage =  MultiLanguageOmni.ReadResourceKey.GetString("CardInformationError", "MultiLanguageOmni.Index");
        //            return false;
        //        }
        //        if (subscriptionInitializeModel.PaymentCard.CardHolderName == null || subscriptionInitializeModel.PaymentCard.CardHolderName == "")
        //        {
        //            ErrorMessage = MultiLanguageOmni.ReadResourceKey.GetString("CardOwnInformationError", "MultiLanguageOmni.Index");
        //            return false;
        //        }
        //        if (subscriptionInitializeModel.PaymentCard.CardNumber1 != null || subscriptionInitializeModel.PaymentCard.CardNumber1 != "")
        //        {
        //            int lenght = Convert.ToInt32(subscriptionInitializeModel.PaymentCard.CardNumber1.Length.ToString());
        //            if (lenght != 16)
        //            {
        //                ErrorMessage = MultiLanguageOmni.ReadResourceKey.GetString("CardNoError", "MultiLanguageOmni.Index");
        //                return false;
        //            }
        //        }
        //        if (subscriptionInitializeModel.PaymentCard.Cvc == null || subscriptionInitializeModel.PaymentCard.Cvc == "")
        //        {
        //            ErrorMessage = MultiLanguageOmni.ReadResourceKey.GetString("CardCvcError", "MultiLanguageOmni.Index");
        //            return false;
        //        }
        //        if (subscriptionInitializeModel.PaymentCard.Cvc != null || subscriptionInitializeModel.PaymentCard.Cvc != "")
        //        {
        //            int lenght = Convert.ToInt32(subscriptionInitializeModel.PaymentCard.Cvc.Length.ToString());
        //            if (lenght < 2)
        //            {
        //                ErrorMessage = MultiLanguageOmni.ReadResourceKey.GetString("CardCvcError2", "MultiLanguageOmni.Index");
        //                return false;
        //            }

        //        }
        //        if (subscriptionInitializeModel.PaymentCard.ExpireYear == null || subscriptionInitializeModel.PaymentCard.ExpireYear < 2021)
        //        {
        //            ErrorMessage = MultiLanguageOmni.ReadResourceKey.GetString("CardDateError", "MultiLanguageOmni.Index");
        //            return false;
        //        }

        //        if (subscriptionInitializeModel.PaymentCard.ExpireYear != null || subscriptionInitializeModel.PaymentCard.ExpireYear > 2021)
        //        {
        //            int year = DateTime.Now.Year;
        //            if (subscriptionInitializeModel.PaymentCard.ExpireYear < year)
        //            {
        //                ErrorMessage = MultiLanguageOmni.ReadResourceKey.GetString("CardDateError", "MultiLanguageOmni.Index");
        //                return false;
        //            }
        //            else if (subscriptionInitializeModel.PaymentCard.ExpireYear == year)
        //            {
        //                int month = DateTime.Now.Month;
        //                if (month >= subscriptionInitializeModel.PaymentCard.ExpireMonth)
        //                {
        //                    ErrorMessage = MultiLanguageOmni.ReadResourceKey.GetString("CardDateError", "MultiLanguageOmni.Index");
        //                    return false;
        //                }
        //            }
        //        }
        //        return true;
        //    }
        //    else
        //    {
        //        ErrorMessage = MultiLanguageOmni.ReadResourceKey.GetString("CardInformationError2", "MultiLanguageOmni.Index");
        //        return false;
        //    }
        //}

        //public List<SelectListItem> GetAllUsers()
        //{
        //    return dbset.Select(s => new SelectListItem
        //    {
        //        Value = s.Id.ToString(),
        //        Text = s.Name + " " + s.Surname
        //    }).ToList();
        //}

        public List<UpdateUserEmailConfirmed> SearchUserByProviderKey(string providerKey)
        {

            string sql = "exec SearchUserByProviderKey @providerKey='" + providerKey + "'";
            var isHasList = context.Set<UpdateUserEmailConfirmed>().FromSqlRaw(sql).ToList();
            return isHasList;
        }
        public bool DeleteProviderKey(string UserId)
        {

            string sql = "exec DeleteProviderKeywithId @userId='" + UserId + "'";
            var isHasList = context.Set<UpdateUserEmailConfirmed>().FromSqlRaw(sql).ToList();
            return isHasList.Count>0;
        }

        public void UpdateUserEmailConfirmed(string UserID)
        {
            string sql = "exec UpdateUserEmailConfirmed @UserID='" + UserID + "'";
            try { context.Set<UpdateUserEmailConfirmed>().FromSqlRaw(sql).ToList(); } catch (Exception ex) { }
        }
        public List<UpdateUserEmailConfirmed> InsertAspNetUserLogins(string providerName, string providerKey, string UserId)
        {
            string sql = "exec InsertAspNetUserLogins " +
                                          "@providerName='" + providerName + "', " +
                                          "@providerKey='" + providerKey + "', " +
                                          "@UserId='" + UserId + "'";
            var result = context.Set<UpdateUserEmailConfirmed>().FromSqlRaw(sql).ToList();
            return result;
        }
        public List<UpdateUserEmailConfirmed> UpdateAspNetUserLogins(string providerName, string providerKey, string UserId)
        {
            string sql = "exec UpdateAspNetUserLogins " +
                                          "@providerName='" + providerName + "', " +
                                          "@providerKey='" + providerKey + "', " +
                                          "@UserId='" + UserId + "'";
            var result = context.Set<UpdateUserEmailConfirmed>().FromSqlRaw(sql).ToList();
            return result;
        }

    }
}
