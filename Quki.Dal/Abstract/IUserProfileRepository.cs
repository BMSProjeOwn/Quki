
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;
using Quki.Entity.ViewModel;

namespace Quki.Dal.Abstract
{
    public interface IUserProfileRepository : IGenericRepository<UserProfile>
    {
        //    public UserProfile GetUserUserProfile(string userID);
        public bool AddORUpdateUserProfile(UserProfileViewModel userProfileViewModel);
        //    public bool ControlUserProfileForCheckOut(int languageId, string id, out string ErrorMessage);
        //    public bool ControlCartInformation(SubscriptionInitializeModel subscriptionInitializeModel, out string ErrorMessage);
        //    public List<SelectListItem> GetAllUsers();
        public List<UpdateUserEmailConfirmed> SearchUserByProviderKey(string providerKey);
        public void UpdateUserEmailConfirmed(string UserID);
        public List<UpdateUserEmailConfirmed> InsertAspNetUserLogins(string providerName, string providerKey, string UserId);
        public List<UpdateUserEmailConfirmed> UpdateAspNetUserLogins(string providerName, string providerKey, string UserId);

        public bool DeleteProviderKey(string UserId);

    }
}
