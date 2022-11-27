using System.Collections.Generic;
using Quki.Entity.Models;
using Quki.Entity.ViewModel;

namespace Quki.Entity.DtoModels.ApiModels
{
    public class AccountModel : Response
    {
        public bool issubscriber { get; set; }
        public string customer_def_no { get; set; }
        public int setProfileActiveSecondTime { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public int languageId { get; set; }
    }

    public class CustomerApiModel : Response
    {
        public UserProfile UserProfile { get; set; }

    }

    public class UpdateUserResponse : Response
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
    }

    public class UserApi
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
    }

    public class ChangePasswordRequest
    {
        public string Email { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }

    public class ChangePasswordResponse : Response
    {
        public string customer_def_no { get; set; }
    }

    public class ResetPasswordRequest
    {
        public string email { get; set; }
    }

    public class ResetPasswordResponse : Response
    {
        public string Tokken { get; set; }
    }

    public class LoginRequest
    {
        public int languageId { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string providerName { get; set; }
        public string providerKey { get; set; }
    }

    public class LoginResponse : Response
    {
        public User user { get; set; }
        public int setProfileActiveSecondTime { get; set; }
        public object accessToken { get; set; }
        public object refreshToken { get; set; }
        public int languageId { set; get; }
    }


    public class User
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public bool issubscriber { get; set; }
        public string customerDefNo { get; set; }
    }

    public class AccountSettingRequest
    {
        public int languageId { get; set; }
        public string customerDefNo { get; set; }
    }

    public class AccountSettingResponse : Response
    {
        public AccountSetting accountSetting { get; set; }
    }

    public class AccountSetting
    {
        public int id { get; set; }
        public bool status { get; set; }
    }

    public class AccountSettingUpdateRequest
    {
        public List<AccountSetting> accountSettingList { get; set; }
        public int languageId { get; set; }
        public string customerDefNo { get; set; }
    }



    public class CreateMessageRequest
    {
        public string title { get; set; }
        public string mesage { get; set; }

        public int languageId { get; set; }
        public string customerDefNo { get; set; }

    }

    public class RegisterRequest
    {

        public int languageId { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public List<ProtoectInformationGetModel> ProtoectInformationGetModels { get; set; }
        public string providerName { get; set; }
        public string providerKey { get; set; }
    }


    public class UserUpdate
    {
        public string customerDefNo { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
    }

    public class MemberShipProperties
    {
        public string PropertiesCode { get; set; }
        public string PropertiesName { get; set; }
        public int PropertiesStatus { get; set; }
        public List<int> countryList { get; set; }
        public List<int> productList { get; set; }
        public string value { get; set; }
        public string PropertisMessage { get; set; }
    }

    public class MemberShipStatus
    {
        public bool status { get; set; }
        public string message { get; set; }
    }

    public class CheckDownloadAuthorizationRequest
    {
        public int languageId { get; set; }
        public string customerDefNo { get; set; }
        public int productId { get; set; }
        public int counrtyId { get; set; }
    }
}
