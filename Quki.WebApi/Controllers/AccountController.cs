using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Quki.Bll;
using Quki.Common;
using Quki.Entity.DtoModels;
using Quki.Entity.DtoModels.ApiModels;
using Quki.Entity.Models;
using Quki.Entity.Parameters;
using Quki.Entity.Statics;
using Quki.Entity.ViewModel;
using Quki.Interface;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Newtonsoft.Json;
using System.Net;
using System.IdentityModel.Tokens.Jwt;
using Newtonsoft.Json.Linq;
using Iyzipay.Model;

namespace Quki.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AccountController : ControllerBase
    {
        private readonly List<ClientModel> _clients;

        IConfiguration configuration;
        private readonly IMemberShipTypeWithPropertiesService service;
        private readonly IErrorLogService errorLogService;
        private readonly IMemberShipTypeWithCustomersProfilesService memberShipTypeWithCustomersProfilesService;
        private readonly IUserProfileService userProfileService;
        private readonly IEmailTemplateService emailTemplateService;
        private readonly IUserProtoectInformationService userProtoectInformationService;
        private readonly IMemberShipTypeWithCustomerService memberShipTypeWithCustomerService;
        private readonly ICustomerService customerService;
        private readonly IProtoectInformationService protoectInformationService;
        private readonly ICountryService countryService;

        public AccountController(
            IConfiguration configuration,
            IMemberShipTypeWithPropertiesService service,
            IErrorLogService errorLogService,
            IMemberShipTypeWithCustomersProfilesService memberShipTypeWithCustomersProfilesService,
            IUserProfileService userProfileService,
            IEmailTemplateService emailTemplateService,
            IUserProtoectInformationService userProtoectInformationService,
            IMemberShipTypeWithCustomerService memberShipTypeWithCustomerService,
            ICustomerService customerService,
            IProtoectInformationService protoectInformationService,
            UserManager<AppUser> userMeneger,
            SignInManager<AppUser> signInManager,
            IOptions<List<ClientModel>> optionsClients,
            ICountryService countryService
            )
        {
            this.configuration = configuration;
            this.service = service;
            this.errorLogService = errorLogService;
            this.memberShipTypeWithCustomersProfilesService = memberShipTypeWithCustomersProfilesService;
            this.userProfileService = userProfileService;
            this.emailTemplateService = emailTemplateService;
            this.userProtoectInformationService = userProtoectInformationService;
            this.memberShipTypeWithCustomerService = memberShipTypeWithCustomerService;
            this.customerService = customerService;
            this.protoectInformationService = protoectInformationService;
            this.countryService = countryService;
            UserMeneger = userMeneger;
            SignInManager = signInManager;
            _clients = optionsClients.Value;
        }

        public UserManager<AppUser> UserMeneger { get; }
        public SignInManager<AppUser> SignInManager { get; }

        [HttpGet("Register")]
        [AllowAnonymous]
        AccountModel Register([FromBody] JsonElement JObject)
        {
            RegisterRequest req = Functions.ToObject<RegisterRequest>(JObject);
            int? languageID = req.languageId;

            AccountModel res = new AccountModel();
            var headerIp = Request.HttpContext.Connection.RemoteIpAddress;
            string countryCode = Functions.GetCountryInfo(headerIp);
            
            AppUser app = new AppUser();
            res.ResultMessage = "İşlem Başarısız.";
            res.ResultCode = 0;
            res.Result = false;

            app.UserName = req.email;
            app.Email = req.email;
            if (req.ProtoectInformationGetModels != null)
            {
                for (int i = 0; i < req.ProtoectInformationGetModels.Count; i++)
                {
                    if (req.ProtoectInformationGetModels[i].isRequisite && !req.ProtoectInformationGetModels[i].isHas)
                    {
                        //ModelState.AddModelError("", viewModel.ProtoectInformationGetModels[i].ProtectionInformationHeaderLine + " Sözleşme koşulları formu doldurulmalıdır. ");
                        res.ResultMessage = req.ProtoectInformationGetModels[i].ProtectionInformationHeaderLine + " Sözleşme koşulları formu doldurulmalıdır. ";
                        // Burası düşünülecek.
                    }

                }
            }

            var user1 = UserMeneger.FindByEmailAsync(req.email).Result;
            if (user1 != null)
            {
                res.ResultCode = 202;
                    res.ResultMessage = "Bu Email Sistemde Mevcuttur!";
                if (res.languageId == 2)
                {
                    res.ResultMessage = "This Email Is Available In The System!";
                }
                if (res.languageId == 3)
                {
                    res.ResultMessage = "Diese E-Mail ist im System verfügbar!";
                }
            }
            else
            {
                bool isCreated = false;
                bool isCreatedWithExternel = false;
                string isHas = "";
                if (req.providerKey != null)
                {
                    if (req.providerKey != "")
                    {
                        //string sql = "exec SearchUserByProviderKey @providerKey='" + req.providerKey + "'";
                        //var isHasList = context.UpdateUserEmailConfirmed.FromSqlRaw(sql).ToList();
                        var isHasList = userProfileService.SearchUserByProviderKey(req.providerKey);
                        if (isHasList != null)
                        {
                            if (isHasList.Count > 0)
                            {
                                isHas = isHasList[0].Result;
                            }
                        }

                        if (isHas == "" || isHas == "0")
                        {
                            var result = UserMeneger.CreateAsync(app, req.providerKey);
                            if (result.Result.Succeeded)
                            {
                                try
                                {
                                    UserProfileViewModel model = new UserProfileViewModel();
                                    model.Id = app.Id;
                                    model.Name = "";
                                    model.SurName = "";
                                    var countryInfo = countryService.TGetList(x => x.CountryCode == countryCode).FirstOrDefault();
                                    if (countryInfo != null)
                                    {
                                        model.Country = countryInfo.CounrtySeqID.ToString();
                                    }
                                    else
                                    {
                                        model.Country = "2";
                                    }
                                    model.LanguageID = req.languageId;
                                    model.Email = app.Email;
                                    userProfileService.AddORUpdateUserProfile(model);
                                    CustomerAddModel customerAddModel = new CustomerAddModel();
                                    customerAddModel.LanguageID = req.languageId;
                                    customerAddModel.email = app.Email;
                                    customerAddModel.customer_def_name = "";
                                    customerAddModel.customer_def_surname = "";
                                    customerAddModel.UserID = app.Id;
                                    customerService.CustomerAddNewCustomer(customerAddModel);
                                    res.customer_def_no = app.Id;
                                }
                                catch (Exception ex) { }
                                var loginInfo = UserMeneger.AddLoginAsync(app, new UserLoginInfo(loginProvider: req.providerName, providerKey: req.providerKey, displayName: "GoogleDN")).Result;
                                isCreatedWithExternel = true;
                                isCreated = true;
                                try
                                {

                                    var client = _clients.SingleOrDefault(x => x.Id == Request.Headers["client-id"].ToString() && x.Secret == Request.Headers["client-secret"].ToString());
                                    client.Email = req.email;
                                    client.Password = req.password == null ? "" : req.password;
                                    client.DeviceType = Request.Headers["device-type"].ToString();
                                    client.DeviceId = Request.Headers["client-id"].ToString();
                                    client.ProviderKey = req.providerKey == null ? "" : req.providerKey;
                                    client.ProviderName = req.providerName == null ? "" : req.providerName;
                                    res.Result = true;
                                    if (languageID == 1)
                                    { res.ResultMessage = "Giriş Başarılı."; }
                                    else if (languageID == 2)
                                    { res.ResultMessage = "Login successful."; }
                                    else if (languageID == 3)
                                    { res.ResultMessage = "Anmeldung erfolgreich."; }
                                    else
                                    { res.ResultMessage = "Giriş Başarılı."; }
                                    res.ResultCode = 200;
                                    res.AccessToken = new TokenManager(configuration).CreateAccessTokenClient(client);
                                    res.RefreshToken = new TokenManager(configuration).CreateRefreshTokenClient(client);
                                    return res;
                                }
                                catch (Exception)
                                {
                                    res.AccessToken = "";
                                    res.RefreshToken = "";
                                    res.ResultMessage = "Token Hatası Cihaz için token oluştururken hata oluştu";
                                    return res;
                                }
                            }
                        }
                        else
                        {
                            res.ResultMessage = "Bu Bilgi Sistemde Mevcuttur!";
                        }
                    }
                }

                if (!isCreatedWithExternel && isHas == "")
                {
                    var result2 = UserMeneger.CreateAsync(app, req.password);
                    if (result2.Result.Succeeded)
                    {
                        try
                        {
                            UserProfileViewModel model = new UserProfileViewModel();
                            model.Id = app.Id;
                            model.Name = "";
                            model.SurName = "";
                            var countryInfo = countryService.TGetList(x => x.CountryCode == countryCode).FirstOrDefault();
                            if (countryInfo != null)
                            {
                                model.Country = countryInfo.CounrtySeqID.ToString();
                            }
                            else
                            {
                                model.Country = "2";
                            }
                            userProfileService.AddORUpdateUserProfile(model);
                            CustomerAddModel customerAddModel = new CustomerAddModel();
                            customerAddModel.email = app.Email;
                            customerAddModel.customer_def_name = "";
                            customerAddModel.customer_def_surname = "";
                            customerAddModel.UserID = app.Id;
                            customerService.CustomerAddNewCustomer(customerAddModel);
                            res.customer_def_no = app.Id;
                        }
                        catch (Exception ex) { }
                        isCreated = true;
                    }
                }
                if (isCreated)
                {
                    IdentityRole rolo = new IdentityRole
                    {
                        Name = "FreeUser"
                    };

                    var result2 = UserMeneger.AddToRoleAsync(app, rolo.Name).Result;
                    if (result2.Succeeded)
                    {
                        //Utility.SendMail("zupos@bmsproje.com", app.Email, "Kullanıcı Kaydı" + DateTime.Now.ToShortTimeString(),
                        //    string.Format("Yeni bir kullanıcı kaydı var.Kullanıcı Adı :{0}", app.Email), "smtp.gmail.com", 587, "zupos@bmsproje.com ", "zuposbms2021");

                        Utility.SendMail("info@Quki.com", "info@Quki.com", "Quki - Hesap Oluşturma : " + DateTime.Now.ToShortTimeString(), string.Format("Yeni bir kullanıcı kaydı var.Kullanıcı Adı :{0}", app.Email), "mail.Quki.com", 587, "info@Quki.com ", "Quki.34076");

                        var token = UserMeneger.GenerateEmailConfirmationTokenAsync(app).Result;
                        //var url = Url.Action("ConfirmEmail", "Account", new { userID = app.Id, token = token }, Request.Scheme);
                        var url = "www.Quki.com/Account/ConfirmEmail?userID=" + app.Id + "&token=" + token;
                        var path = Directory.GetCurrentDirectory() + "/wwwroot/MailTemplate/ActivationMessage.htm";



                        Parameters.ActivationTemplate = Parameters.ActivationTemplate.Replace("linkAktivation", url);

                        if (isCreatedWithExternel)
                        {
                            NotificationTemplatess notificationTemplatess = new NotificationTemplatess();
                            notificationTemplatess = emailTemplateService.FindTamplewithId(15);
                            string ActivationTemplate = "";
                            Random random = new Random();
                            int loginCode = random.Next(100000, 999999);
                            AppUser user2 = UserMeneger.FindByEmailAsync(app.Email).Result;
                            if (user2 != null)
                            {
                                userProfileService.UpdateAspNetUserLogins("Quki", loginCode.ToString(), user2.Id);

                            }
                            ActivationTemplate = notificationTemplatess.NotificationInstraction;

                            ActivationTemplate = ActivationTemplate.Replace("@LinkAktivasyon", url);
                            ActivationTemplate = ActivationTemplate.Replace("@LinkAktiCode", loginCode.ToString());

                            Utility.SendMail("info@Quki.com", "muhammed_heyw@hotmail.com", "Quki - Hesap Oluşturma", ActivationTemplate, "mail.Quki.com", 587, "info@Quki.com ", "Quki.34076");

                            //Utility.SendMail("info@Quki.com", app.Email, "Qukiya Hoşgeldiniz :", string.Format("Quki ailesine hoşgeldiniz."), "mail.Quki.com", 587, "info@Quki.com ", "Quki.34076");
                        }
                        else
                        {
                            NotificationTemplatess notificationTemplatess = new NotificationTemplatess();
                            notificationTemplatess = emailTemplateService.FindTamplewithId(15);
                            string ActivationTemplate = "";
                            ActivationTemplate = notificationTemplatess.NotificationInstraction;
                            Random random = new Random();
                            int loginCode = random.Next(100000, 999999);
                            AppUser user2 = UserMeneger.FindByEmailAsync(app.Email).Result;
                            if (user2 != null)
                            {
                                userProfileService.UpdateAspNetUserLogins("Quki", loginCode.ToString(), user2.Id);

                            }
                            ActivationTemplate = ActivationTemplate.Replace("@LinkAktivasyon", url); ActivationTemplate = ActivationTemplate.Replace("@LinkAktiCode", loginCode.ToString());
                            ActivationTemplate = ActivationTemplate.Replace("@LinkAktiCode", loginCode.ToString());


                            Utility.SendMail("info@Quki.com", app.Email, "Quki - Hesap Oluşturma : " + DateTime.Now.ToShortTimeString(), ActivationTemplate, "mail.Quki.com", 587, "info@Quki.com ", "Quki.34076");

                            //Utility.SendMail("info@Quki.com", app.Email, "Aktivation : " + DateTime.Now.ToShortTimeString(), Parameters.ActivationTemplate, "mail.Quki.com", 587, "info@Quki.com ", "Quki.34076");
                        }


                        if (req.ProtoectInformationGetModels != null)
                        {
                            if (req.ProtoectInformationGetModels.Count() > 0)
                                userProtoectInformationService.AddUserProtoectInformation(req.ProtoectInformationGetModels, app.Id);
                        }
                        var user = UserMeneger.FindByEmailAsync(app.Email).Result;
                        if (isCreatedWithExternel)
                        {
                            res.ResultMessage = "Qukiya Hoşgeldiniz.";

                            //string sql = "exec UpdateUserEmailConfirmed @UserID='" + user.Id + "'";
                            //try { context.UpdateUserEmailConfirmed.FromSqlRaw(sql).ToList(); } catch (Exception ex) { }
                            try { userProfileService.UpdateUserEmailConfirmed(user.Id); } catch (Exception ex) { }
                        }
                        else
                            res.ResultMessage = app.Email + " kullanıcı kaydı alındı. " + "Kullanıcıyı aktif etmek için " + app.Email + " adresine gelen linki tıklayın. ";
                        res.ResultCode = 1;
                        res.Result = true;
                        res.issubscriber = false;
                        var userInfo = userProfileService.TGetList(x => x.Id == app.Id).FirstOrDefault();
                        if (userInfo != null)
                        {
                            try
                            {
                                res.languageId = userInfo.LanguageID.Value;
                            }
                            catch (Exception)
                            {
                                res.languageId = 1;
                            }
                        }
                        else
                        {
                            res.languageId = 1;
                        }
                        var client = _clients.SingleOrDefault(x => x.Id == Request.Headers["client-id"].ToString() && x.Secret == Request.Headers["client-secret"].ToString());
                        client.Email = req.email;
                        client.Password = req.password;
                        client.DeviceType = Request.Headers["device-type"].ToString();
                        client.DeviceId = Request.Headers["client-id"].ToString();
                        client.ProviderKey = req.providerKey == null ? "" : req.providerKey;
                        client.ProviderName = req.providerName == null ? "" : req.providerName; ;
                        res.Result = true;
                        res.ResultCode = 200;
                        res.AccessToken = new TokenManager(configuration).CreateAccessTokenClient(client);
                        res.RefreshToken = new TokenManager(configuration).CreateRefreshTokenClient(client);
                        res.customer_def_no = user.Id;
                    }

                }
            }

            return res;
        }
        [HttpGet]
        [AllowAnonymous]
        LoginResponse Login(LoginRequest req,string clientId=null,string clientSecret=null)
        {
            //LoginRequest req = Functions.ToObject<LoginRequest>(JObject);
            int? languageID = req.languageId;
            LoginResponse returnModel = new LoginResponse();
            returnModel.Result = false;
            returnModel.ResultCode = 0;
            if (languageID == (int)Enums.Language.Turkish)
            { returnModel.ResultMessage = "Giriş Başarısız!"; }
            else if (languageID == (int)Enums.Language.English)
            { returnModel.ResultMessage = "Login Failed!"; }
            else if (languageID == (int)Enums.Language.German)
            { returnModel.ResultMessage = "Fehler bei der Anmeldung!"; }
            else
            { returnModel.ResultMessage = "Giriş Başarısız!"; }
            returnModel.user = new User();
            var user = UserMeneger.FindByEmailAsync(req.email).Result;
            if (user != null)
            {
                bool externalLogin = false;
                try
                {
                    var loginResult =
                         SignInManager.ExternalLoginSignInAsync(req.providerName, req.providerKey, false, false);
                    if (loginResult.Result.Succeeded)
                    {
                        externalLogin = true;
                    }
                    else
                    {
                        //string sql = "exec SearchUserByProviderKey @providerKey='" + req.providerKey + "'";
                        //var isHasList = context.UpdateUserEmailConfirmed.FromSqlRaw(sql).ToList();
                        var isHasList = userProfileService.SearchUserByProviderKey(req.providerKey);
                        if (isHasList != null)
                        {
                            if (isHasList.Count > 0)
                            {
                                if (isHasList[0].Result == "1")
                                {
                                    externalLogin = true;
                                }
                            }
                        }
                        if (!externalLogin)
                        {
                            if (req.providerKey != null)
                            {
                                if (req.providerKey != "")
                                {
                                    AppUser app = new AppUser();
                                    app.UserName = req.email;
                                    app.Email = req.email;
                                    var loginInfo = UserMeneger.AddLoginAsync(app, new UserLoginInfo(loginProvider: req.providerName, providerKey: req.providerKey, displayName: "GoogleDN")).Result;
                                    if (loginInfo.Succeeded)
                                    {

                                    }
                                    else
                                    {
                                        //sql = "exec InsertAspNetUserLogins " +
                                        //    "@providerName='" + req.providerName + "', " +
                                        //    "@providerKey='" + req.providerKey + "', " +
                                        //    "@UserId='" + user.Id + "'";
                                        //isHasList = context.UpdateUserEmailConfirmed.FromSqlRaw(sql).ToList();
                                        isHasList = userProfileService.InsertAspNetUserLogins(req.providerName, req.providerKey, user.Id);
                                        if (isHasList != null)
                                        {
                                            if (isHasList.Count > 0)
                                            {
                                                if (isHasList[0].Result == "1")
                                                {
                                                    externalLogin = true;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch { }

                if (externalLogin)
                {
                    var isSub = memberShipTypeWithCustomerService.getMemberShipTypeWithCustomers(user.Id);
                    if (isSub != null)
                        returnModel.user.issubscriber = true;
                    else
                        returnModel.user.issubscriber = false;
                    returnModel.Result = true;
                    returnModel.ResultCode = 1;
                    if (languageID == 1)
                    { returnModel.ResultMessage = "Giriş Başarılı."; }
                    else if (languageID == 2)
                    { returnModel.ResultMessage = "Login successful."; }
                    else if (languageID == 3)
                    { returnModel.ResultMessage = "Anmeldung erfolgreich."; }
                    else
                    { returnModel.ResultMessage = "Giriş Başarılı."; }
                    returnModel.user.customerDefNo = user.Id;

                    var result = userProfileService.GetUserUserProfile(returnModel.user.customerDefNo);
                    if (result != null)
                    {
                        returnModel.user.name = result.Name;
                        returnModel.user.surname = result.Surname;
                    }
                    try
                    {

                        returnModel.languageId = result.LanguageID.Value;
                    }
                    catch (Exception)
                    {

                        errorLogService.ErrorLogAdd("Dil Hatası Account/LoginApi  ");
                        returnModel.languageId = 1;
                    }
                    returnModel.user.username = user.UserName;
                    returnModel.user.email = user.Email;

                }
                else
                {
                    if (user != null && !user.EmailConfirmed && UserMeneger.CheckPasswordAsync(user, req.password).Result)
                    {
                        if (languageID == 1)
                        {
                            returnModel.ResultMessage = "Üyeliğiniz aktif değil. " +
                                  "Yeni hesap oluşturduktan sonra e-posta adresinize gelen aktivasyon linkini onaylamanız gerekli.";
                        }
                        else if (languageID == 2)
                        { returnModel.ResultMessage = "E-Mail is not active!"; }
                        else if (languageID == 3)
                        { returnModel.ResultMessage = "E-Mail ist nicht aktiv!"; }
                        else
                        {
                            returnModel.ResultMessage = "Üyeliğiniz aktif değil. " +
                                  "Yeni hesap oluşturduktan sonra e-posta adresinize gelen aktivasyon linkini onaylamanız gerekli.";
                        }
                        returnModel.ResultCode = 0;
                    }
                    else
                    {
                        var siginResult = SignInManager.PasswordSignInAsync(req.email, req.password, false, false).Result;

                        if (siginResult.Succeeded && !siginResult.IsNotAllowed)
                        {
                            var isSub = memberShipTypeWithCustomerService.getMemberShipTypeWithCustomers(user.Id);
                            if (isSub != null)
                                returnModel.user.issubscriber = true;
                            else
                                returnModel.user.issubscriber = false;
                            returnModel.Result = true;
                            returnModel.ResultCode = 1;
                            if (languageID == 1)
                            { returnModel.ResultMessage = "Giriş Başarılı."; }
                            else if (languageID == 2)
                            { returnModel.ResultMessage = "Login successful."; }
                            else if (languageID == 3)
                            { returnModel.ResultMessage = "Anmeldung erfolgreich."; }
                            else
                            { returnModel.ResultMessage = "Giriş Başarılı."; }
                            returnModel.user.customerDefNo = user.Id;
                            UserProfile result;
                            try
                            {
                                result= userProfileService.GetUserUserProfile(returnModel.user.customerDefNo);
                                if (result != null)
                                {
                                    try
                                    {
                                        returnModel.languageId = result.languageID;
                                    }
                                    catch (Exception)
                                    {
                                        returnModel.languageId = 1;
                                    }
                                    returnModel.user.name = result.Name;
                                    returnModel.user.surname = result.Surname;
                                }
                            }
                            catch (Exception)
                            {
                                try
                                {

                                    var headerIp = Request.HttpContext.Connection.RemoteIpAddress;
                                    string countryCode = Functions.GetCountryInfo(headerIp);
                                    UserProfileViewModel model = new UserProfileViewModel();
                                    model.Id = user.Id;
                                    model.Name = "";
                                    model.SurName = "";
                                    var countryInfo = countryService.TGetList(x => x.CountryCode == countryCode).FirstOrDefault();
                                    if (countryInfo != null)
                                    {
                                        model.Country = countryInfo.CounrtySeqID.ToString();
                                    }
                                    else
                                    {
                                        model.Country = "2";
                                    }
                                    model.LanguageID = req.languageId;
                                    model.Email = user.Email;
                                    returnModel.languageId=req.languageId;
                                    userProfileService.AddORUpdateUserProfile(model);
                                    CustomerAddModel customerAddModel = new CustomerAddModel();
                                    customerAddModel.LanguageID = req.languageId;
                                    customerAddModel.email = user.Email;
                                    customerAddModel.customer_def_name = "";
                                    customerAddModel.customer_def_surname = "";
                                    customerAddModel.UserID = user.Id;
                                    customerService.CustomerAddNewCustomer(customerAddModel);
                                }
                                catch (Exception ex) { }
                            }
                            
                            returnModel.user.username = user.UserName;
                            returnModel.user.email = user.Email;
                            ClientModel client2 = new ClientModel();
                            if (clientId == null && clientSecret == null)
                            {
                                client2 = _clients.SingleOrDefault(x => x.Id == Request.Headers["client-id"].ToString() && x.Secret == Request.Headers["client-secret"].ToString());
                            }
                            else
                            {
                                client2 = _clients.SingleOrDefault(x => x.Id == clientId && x.Secret == clientSecret);
                            }
                            client2.Email = req.email;
                            client2.Password = req.password;
                            client2.DeviceType = Request.Headers["device-type"].ToString();
                            client2.DeviceId = Request.Headers["client-id"].ToString();
                            client2.ProviderKey = req.providerKey==null?"":req.providerKey;
                            client2.ProviderName = req.providerName == null ? "" : req.providerName;
                            returnModel.accessToken = new TokenManager(configuration).CreateAccessTokenClient(client2);
                            returnModel.refreshToken = new TokenManager(configuration).CreateRefreshTokenClient(client2);
                            //var token = new TokenManager(configuration).CreateAccessToken(returnModel.user);

                            //returnModel.token = token;

                            //TokenManager çağrılacak
                        }
                        else if (!siginResult.Succeeded && siginResult.IsLockedOut)
                        {
                            if (languageID == 1)
                            { returnModel.ResultMessage = "Şifre Kilitli!"; }
                            else if (languageID == 2)
                            { returnModel.ResultMessage = "Password Locked!"; }
                            else if (languageID == 3)
                            { returnModel.ResultMessage = "Passwort gesperrt!"; }
                            else
                            { returnModel.ResultMessage = "Şifre Kilitli!"; }

                        }
                        else if (!siginResult.Succeeded && siginResult.IsNotAllowed)
                        {
                            returnModel.ResultCode = 200;
                            if (languageID == 1)
                            { returnModel.ResultMessage = "Giriş İzni Bulunamadı!"; }
                            else if (languageID == 2)
                            { returnModel.ResultMessage = "Login Not Found!"; }
                            else if (languageID == 3)
                            { returnModel.ResultMessage = "Anmeldung nicht gefunden!"; }
                            else
                            { returnModel.ResultMessage = "Giriş İzni Bulunamadı!"; }
                        }
                        else
                        {
                            if (languageID == 1)
                            { returnModel.ResultMessage = "Şifre Bilgisi Hatalı!"; }
                            else if (languageID == 2)
                            { returnModel.ResultMessage = "Password Information Incorrect!"; }
                            else if (languageID == 3)
                            { returnModel.ResultMessage = "Passwort-Informationen falsch!"; }
                            else
                            { returnModel.ResultMessage = "Şifre Bilgisi Hatalı!"; }
                        }
                    }
                }
            }
            else
            {
                if (languageID == 1)
                { returnModel.ResultMessage = "E-Mail Bilgisi Hatalı!"; }
                else if (languageID == 2)
                { returnModel.ResultMessage = "E-Mail Information Incorrect!"; }
                else if (languageID == 3)
                { returnModel.ResultMessage = "E-Mail-Informationen falsch!"; }
                else
                { returnModel.ResultMessage = "E-Mail Bilgisi Hatalı!"; }
            }
            try
            {

                ClientModel client = new ClientModel();
                if (clientId == null && clientSecret == null)
                {
                    client = _clients.SingleOrDefault(x => x.Id == Request.Headers["client-id"].ToString() && x.Secret == Request.Headers["client-secret"].ToString());
                }
                else
                {
                    client = _clients.SingleOrDefault(x => x.Id == clientId && x.Secret == clientSecret);
                }
                client.Email = req.email;
                client.Password = req.password;
                client.DeviceType = Request.Headers["device-type"].ToString();
                client.DeviceId = Request.Headers["client-id"].ToString();
                client.ProviderKey = req.providerKey == null ? "" : req.providerKey;
                client.ProviderName = req.providerName == null ? "" : req.providerName;
                returnModel.accessToken = new TokenManager(configuration).CreateAccessTokenClient(client);
                returnModel.refreshToken = new TokenManager(configuration).CreateRefreshTokenClient(client);

                return returnModel;
            }
            catch (Exception)
            {
                returnModel.accessToken = "";
                returnModel.refreshToken = "";
                returnModel.ResultMessage = "Token Hatası Cihaz için token oluştururken hata oluştu";
                return returnModel;
            }
        }
        [HttpPost("LoginApi")]
        [AllowAnonymous]
        public LoginResponse LoginApi([FromBody] JsonElement JObject)
        {
            LoginResponse loginRes=new LoginResponse();
            try
            {
                errorLogService.ErrorLogAdd("Account/LoginApi  " + JObject.ToString());
                LoginRequest req = Functions.ToObject<LoginRequest>(JObject);
                if (req.password == null)
                    req.password = req.providerKey;
                loginRes = Login(req);

                loginRes.setProfileActiveSecondTime = AppParameters.SetProfileActiveSecondTime;
                if (!loginRes.Result && req.providerKey != null && req.providerKey != "")
                {
                    AccountModel registerRes = Register(JObject);
                    if (registerRes.Result)
                    {
                        loginRes.Result=registerRes.Result;
                        loginRes.ResultCode=registerRes.ResultCode;
                        loginRes.ResultMessage=registerRes.ResultMessage;
                        loginRes.accessToken= registerRes.AccessToken;
                        loginRes.refreshToken=registerRes.RefreshToken;
                        return loginRes;
                    }
                    else
                    {
                        return loginRes;
                    }
                }
                else
                {
                    try
                    {

                        var client = _clients.SingleOrDefault(x => x.Id == Request.Headers["client-id"].ToString() && x.Secret == Request.Headers["client-secret"].ToString());
                        client.Email = req.email;
                        client.Password = req.password;
                        client.DeviceType = Request.Headers["device-type"].ToString();
                        client.DeviceId = Request.Headers["client-id"].ToString();

                        client.ProviderKey = req.providerKey == null ? "" : req.providerKey;
                        client.ProviderName = req.providerName == null ? "" : req.providerName;
                        loginRes.accessToken = new TokenManager(configuration).CreateAccessTokenClient(client);
                        loginRes.refreshToken = new TokenManager(configuration).CreateRefreshTokenClient(client);
                        return loginRes;
                    }
                    catch (Exception)
                    {
                        //loginRes.Result = true;
                        //loginRes.ResultMessage = "Giriş Başarılı";
                        //loginRes.ResultCode = 200;
                        //loginRes.accessToken = "";
                        //loginRes.refreshToken = "";
                        loginRes.ResultMessage = "Token Hatası Cihaz için token oluştururken hata oluştu";
                        return loginRes;
                    }
                }
            }
            catch (Exception ex)
            {
                errorLogService.ErrorLogAdd("410 Account/LoginApi  " + JObject.ToString() +" " + ex.Message);
                loginRes.ResultCode = 410;

                loginRes.ResultMessage = "İşlem Sırasında beklenmeyen hata oluştu. Hata için Lütfen bizimle irtibata geçin";
                
                loginRes.Result = false;
                return loginRes;
            }
            

        }
        [HttpPost("RegisterApi")]
        [AllowAnonymous]
        public AccountModel RegisterApi([FromBody] JsonElement JObject)
        {
            errorLogService.ErrorLogAdd("Account/RegisterApi  " + JObject.ToString());
            RegisterRequest req = Functions.ToObject<RegisterRequest>(JObject);
            AccountModel registerRes = Register(JObject);
            registerRes.setProfileActiveSecondTime = AppParameters.SetProfileActiveSecondTime;
            //if (!registerRes.Result && req.providerKey != null && req.providerKey != "")
            //{
            //    LoginResponse loginRes = Login(JObject);
            //    if (loginRes.Result)
            //    {
            //        registerRes.customer_def_no = loginRes.user.customerDefNo;
            //        registerRes.issubscriber = loginRes.user.issubscriber;
            //        registerRes.Result = loginRes.Result;
            //        registerRes.ResultCode = loginRes.ResultCode;
            //        registerRes.ResultMessage = loginRes.ResultMessage;
            //        return registerRes;
            //    }
            //    else
            //        return registerRes;
            //}
            //else
            //    return registerRes;
            
            return registerRes;
        }
        [HttpPost("CancelSubscriptionApi")]
        public Response CancelSubscriptionApi([FromBody] JsonElement JObject)
        {
            errorLogService.ErrorLogAdd("Account/CancelSubscriptionApi  " + JObject.ToString());
            Request languages = Functions.ToObject<Request>(JObject);
            int? languageID = languages.languageId;

            AccountModel appUserModel = Functions.ToObject<AccountModel>(JObject);
            Response res = new Response();
            res.ResultMessage = "İşlem Başarısız.";
            res.ResultCode = 0;
            res.Result = false;
            string message = "";
            if (customerService.CanceCustomer(languages.customerDefNo, out message))
            {
                res.ResultMessage = message;
                res.ResultCode = 1;
                res.Result = true;
            }
            else
            {
                res.ResultMessage = message;
            }

            return res;
        }
        [HttpPost("InActiveAccount")]
        public Response InActiveAccount([FromBody] JsonElement JObject)
        {
            errorLogService.ErrorLogAdd("Account/InActiveAccount  " + JObject.ToString());


            Request request = Functions.ToObject<Request>(JObject);
            Response res = new Response();
            res.ResultMessage = "İşlem Başarısız.";
            res.ResultCode = 0;
            res.Result = false;
            var customersProfile = memberShipTypeWithCustomersProfilesService.TGetList(x => x.ProfileUserID == request.customerDefNo);
            string UserId = customersProfile[0].UserID;
            var memberInfo = memberShipTypeWithCustomerService.TGetList(x => x.IsActive && x.Id == UserId).FirstOrDefault();
            if (memberInfo != null)
            {

                res.ResultMessage = "Hesabınıza tanımlı bir aboneliğiniz bulunmaktadır. hesabınızı kaldırmadan önce aboneliğinizi iptal etmeniz gerekmektedir.";
                if (request.languageId==2)
                {
                    res.ResultMessage = "You have a subscription defined to your account. You must cancel your subscription before removing your account.";
                }
                if (request.languageId == 3)
                    res.ResultMessage = "Sie haben ein Abonnement für Ihr Konto definiert. Sie müssen Ihr Abonnement kündigen, bevor Sie Ihr Konto entfernen.";
                res.ResultCode = 201;
                res.Result = false;
                return res;
            }
            var user = UserMeneger.FindByIdAsync(UserId).Result;
            user.Email = Guid.NewGuid() + "@tikutpasif.com";
            user.UserName = Guid.NewGuid() + "@tikutpasif.com";
            user.NormalizedEmail += Guid.NewGuid();
            user.NormalizedUserName += Guid.NewGuid();
            user.EmailConfirmed = false;
            var result = UserMeneger.UpdateAsync(user);

            foreach (var item in customersProfile)
            {
                item.IsActive = false;
                memberShipTypeWithCustomersProfilesService.TUpdate(item);
            }
            if (result.Result.Succeeded)
            {
                userProfileService.DeleteProviderKey(user.Id);
            }
            if (result.Result.Succeeded)
            {

                res.ResultMessage = "İşlem Başarılı";
                res.ResultCode = 202;
                res.Result = true;
            }
            else
            {
                res.ResultCode = 204;
                res.Result = true;
                res.ResultMessage = "İşlem Sırasında Bir Hata Oluştu Lütfen Tekrar Deneyiniz";
                if (request.languageId == 2)
                    res.ResultMessage = "An Error Occurred During Operation Please Try Again";
                if (request.languageId == 3)
                    res.ResultMessage = "Während des Betriebs ist ein Fehler aufgetreten. Bitte versuchen Sie es erneut";
            }

            return res;
        }

        [HttpPost("GetCustomerApi")]
        public UpdateUserResponse GetCustomerApi([FromBody] JsonElement JObject)
        {
            errorLogService.ErrorLogAdd("Account/GetCustomerApi  " + JObject.ToString());
            Request languages = Functions.ToObject<Request>(JObject);
            int? languageID = languages.languageId;

            AccountModel appUserModel = Functions.ToObject<AccountModel>(JObject);
            UpdateUserResponse res = new UpdateUserResponse();
            res.ResultMessage = "İşlem Başarısız.";
            res.ResultCode = 0;
            res.Result = false;

            var result = userProfileService.GetUserUserProfile(languages.customerDefNo);
            if (result != null)
            {
                res.name = result.Name;
                res.surname = result.Surname;
            }
            var user = UserMeneger.FindByIdAsync(languages.customerDefNo).Result;
            if (user != null)
                res.email = user.Email;

            var customer = customerService.CustomerGetByUserID(languages.customerDefNo);
            if (customer != null)
            {
                var subscriptionOrder = customerService.GetCustemerInformationWithIzico(languages.customerDefNo);
                if (subscriptionOrder.Count > 0)
                {
                    res.ResultCode = 1;
                    res.ResultMessage = "İşlem Başarılı.";
                    res.Result = true;
                }
                else
                {
                    res.ResultCode = 1;
                    res.Result = true;
                    res.ResultMessage = "Abonel Değil!";
                }

            }
            else
            {
                res.ResultCode = 1;
                res.Result = true;
                res.ResultMessage = "Abonel Değil!";
            }
            return res;
        }

        [HttpPost("ChangePasswordApi")]
        public ChangePasswordResponse ChangePasswordApi([FromBody] JsonElement JObject)
        {

            errorLogService.ErrorLogAdd("Account/ChangePasswordApi  " + JObject.ToString());
            Request languages = Functions.ToObject<Request>(JObject);
            int? languageID = languages.languageId;

            ChangePasswordRequest appUserModel = Functions.ToObject<ChangePasswordRequest>(JObject);
            ChangePasswordResponse res = new ChangePasswordResponse();
            res.ResultMessage = "Hata Oluştu!";
            res.ResultCode = 0;
            res.Result = false;


            var user = UserMeneger.FindByEmailAsync(appUserModel.Email).Result;
            if (user != null)
            {
                var result = UserMeneger.ChangePasswordAsync(user, appUserModel.OldPassword, appUserModel.NewPassword).Result;
                if (result.Succeeded)
                {
                    res.customer_def_no = user.Id;
                    res.ResultMessage = "İşlem Başarılı.";
                    res.ResultCode = 1;
                    res.Result = true;
                }
                else
                {
                    res.ResultMessage = "İşlem Başarısız.";
                }
            }
            else
            {
                res.ResultMessage = "Email Hatalıdır!";
                if (languageID == 2)
                    res.ResultMessage = "Email Incorrect";
                if (languageID == 3)
                    res.ResultMessage = "E-Mail falsch";
            }

            return res;
        }

        [HttpPost("ForgotPasswordApi")]
        public ResetPasswordResponse ForgotPasswordApi([FromBody] JsonElement JObject)
        {
            errorLogService.ErrorLogAdd("Account/ForgotPasswordApi  " + JObject.ToString());
            Request languages = Functions.ToObject<Request>(JObject);
            int? languageID = languages.languageId;

            ResetPasswordRequest appUserModel = Functions.ToObject<ResetPasswordRequest>(JObject);
            ResetPasswordResponse res = new ResetPasswordResponse();
            res.ResultMessage = "Hata Oluştu!";
            res.ResultCode = 0;
            res.Result = false;

            var user = UserMeneger.FindByEmailAsync(appUserModel.email).Result;
            if (user != null)
            {
                if (user != null && UserMeneger.IsEmailConfirmedAsync(user).Result)
                {
                    var token = UserMeneger.GeneratePasswordResetTokenAsync(user).Result;
                    //var passwordResetLink = Url.Action("ResetPassword", "Account", new { email = appUserModel.email, token = token }, Request.Scheme);
                    var passwordResetLink = "www.Quki.com/Account/ResetPassword?email=" + appUserModel.email + "&token=" + token;
                    NotificationTemplatess notificationTemplatess = new NotificationTemplatess();
                    notificationTemplatess = emailTemplateService.FindTamplewithId(17);
                    string ForgotPassword = "";
                    ForgotPassword = notificationTemplatess.NotificationInstraction;



                    ForgotPassword = ForgotPassword.Replace("@linkResetPassword", passwordResetLink);
                    Random random = new Random();
                    int loginCode = random.Next(100000, 999999);
                    AppUser user2 = UserMeneger.FindByEmailAsync(user.Email).Result;
                    if (user2 != null)
                    {
                        userProfileService.UpdateAspNetUserLogins("QukiForgetCode", loginCode.ToString(), user2.Id);

                    }
                    ForgotPassword = ForgotPassword.Replace("@LinkAktiCode", loginCode.ToString());

                    Utility.SendMail("info@Quki.com", user.Email, "Quki - Şifre Yenileme "  + DateTime.Now.ToShortTimeString(), ForgotPassword, "mail.Quki.com", 587, "info@Quki.com ", "Quki.34076");

                    res.ResultMessage = "İşlem Başarılı. Mail Adresinizi Kontrol Ediniz.";
                    if (languageID == 2)
                        res.ResultMessage = "Transaction Successful. Check Your Email Address.";
                    if (languageID == 3)
                        res.ResultMessage = "Transaktion Erfolgreich. Überprüfen Sie Ihre E-Mail-Adresse.";
                    res.ResultCode = 1;
                    res.Result = true;
                    res.Tokken = token;
                }
                else
                {
                    res.ResultMessage = "Email Aktif Edilmemiştir. Mailinizi kayıt olurken size gelen eposta adresinde aktif edebilirsiniz. veya www.Quki.com adresinden yeni aktivasyon maili talep edebilirsiniz.";
                    if (languageID == 2)
                        res.ResultMessage = "Email Not Activated. You can activate your e-mail at the e-mail address you received while registering. or you can request a new activation mail from www.Quki.com.";
                    if (languageID == 3)
                        res.ResultMessage = "E-Mail nicht aktiviert. Sie können Ihre E-Mail unter der E-Mail-Adresse aktivieren, die Sie bei der Registrierung erhalten haben. oder Sie können eine neue Aktivierungsmail von www.Quki.com anfordern.";
                }
            }
            else
            {
                res.ResultMessage = "Email Hatalıdır!";
                if (languageID == 2)
                    res.ResultMessage = "Email Incorrect";
                if (languageID == 3)
                    res.ResultMessage = "E-Mail falsch";
            }

            return res;
        }

        [HttpPost("UpdateAccountInformationApi")]
        public UpdateUserResponse UpdateAccountInformationApi([FromBody] JsonElement JObject)
        {
            errorLogService.ErrorLogAdd("Account/UpdateAccountInformationApi  " + JObject.ToString());
            Request languages = Functions.ToObject<Request>(JObject);
            int? languageID = languages.languageId;
            UserUpdate customer = Functions.ToObject<UserUpdate>(JObject);
            UpdateUserResponse res = new UpdateUserResponse();
            res.ResultMessage = "İşlem Başarısız.";
            res.ResultCode = -1;
            res.Result = false;
            string userID = customer.customerDefNo;
            var test = memberShipTypeWithCustomersProfilesService.TGetList(x => x.ProfileUserID.Equals(userID));

            if (memberShipTypeWithCustomersProfilesService.TGetList(x => x.ProfileUserID == customer.customerDefNo).FirstOrDefault() != null)
            {
                userID = memberShipTypeWithCustomersProfilesService.TGetList(x => x.ProfileUserID == customer.customerDefNo).FirstOrDefault().UserID;
            }
            var user = UserMeneger.FindByIdAsync(userID).Result;
            user.Name = customer.name;
            user.SurName = customer.surname;
            var result1 = UserMeneger.UpdateAsync(user).Result;
            if (user != null)
            {
                res.email = user.Email;
                UserProfileViewModel model = new UserProfileViewModel();
                model.Id = userID;
                model.Name = customer.name;
                model.SurName = customer.surname;
                model.LanguageID = languages.languageId;
                userProfileService.AddORUpdateUserProfile(model);
                var result = userProfileService.GetUserUserProfile(userID);
                res.name = result.Name;
                res.surname = result.Surname;
                res.ResultMessage = "İşlem Başarılı.";
                res.ResultCode = 1;
                res.Result = true;
            }
            else
            {

                res.ResultMessage = "Kullanıcı Bulunamadı!";
                if (languageID == 2)
                    res.ResultMessage = "User Not Found!";
                if (languageID == 3)
                    res.ResultMessage = "Benutzer nicht gefunden";
                res.ResultCode = -1;
                res.Result = false;
            }

            return res;
        }


        [HttpPost("SettingApi")]
        public NotificationsTypeApi SettingApi([FromBody] JsonElement JObject)
        {
            errorLogService.ErrorLogAdd("Account/SettingApi  " + JObject.ToString());
            AccountSettingRequest req = Functions.ToObject<AccountSettingRequest>(JObject);
            int? languageID = req.languageId;

            NotificationsTypeApi res = new NotificationsTypeApi();
            res = protoectInformationService.AccountSettingResponse(req.customerDefNo,req.languageId);
            res.ResultMessage = "İşlem Başarılı.";
            res.ResultCode = 1;
            res.Result = true;

            return res;
        }

        [HttpPost("SettingUpdateApi")]
        public Response SettingUpdateApi([FromBody] JsonElement JObject)
        {
            errorLogService.ErrorLogAdd("Account/SettingUpdateApi  " + JObject.ToString());
            AccountSettingUpdateRequest req = Functions.ToObject<AccountSettingUpdateRequest>(JObject);
            int? languageID = req.languageId;

            Response res = new Response();
            for (int i = 0; i < req.accountSettingList.Count; i++)
                userProtoectInformationService.SettingUpdateApi(req.customerDefNo, req.accountSettingList[i].id, req.accountSettingList[i].status);
            res.ResultMessage = "İşlem Başarılı.";
            res.ResultCode = 1;
            res.Result = true;
            return res;
        }

        [HttpPost("CreateMessageApi")]
        public Response CreateMessageApi([FromBody] JsonElement JObject)
        {
            errorLogService.ErrorLogAdd("Account/CreateMessageApi  " + JObject.ToString());
            CreateMessageRequest req = Functions.ToObject<CreateMessageRequest>(JObject);
            int? languageID = req.languageId;

            Response res = new Response();
            res.ResultMessage = "İşlem Başarısız.";
            res.ResultCode = 0;
            res.Result = false;
            return res;
        }

        [HttpPost("CheckDownloadAuthorization")]
        public Response CheckDownloadAuthorization([FromBody] JsonElement JObject)
        {
            errorLogService.ErrorLogAdd("Account/CheckDownloadAuthorization  " + JObject.ToString());
            CheckDownloadAuthorizationRequest req = Functions.ToObject<CheckDownloadAuthorizationRequest>(JObject);
            int languageID = req.languageId;

            Response res = new Response();
            var membershipStatus = service.DownloadPermissionControlSP(req.customerDefNo, languageID);
            if (membershipStatus.Result)
            {
                res.Result = true;
                res.ResultCode = 1;
                res.ResultMessage = "İşlem Başarılı.";
            }
            else
            {
                res.Result = false;
                res.ResultCode = -1;
                res.ResultMessage = membershipStatus.ResultMessage;
            }
            return res;
        }
        [HttpPost("getVersionInfo")]
        [AllowAnonymous]
        public VersionInfoModel getVersionInfo([FromBody] JsonElement JObject)
        {
            VersionInfoModel versionInfo = new VersionInfoModel();

            versionInfo.version = "1.1.24";
            versionInfo.isUpdateRequired = true;
            return versionInfo;
        }

        [HttpPost("CreateTokenByClient")]
        [AllowAnonymous]
        public ResponseTokenModel CreateTokenByClient(ClientLoginModel clientModel)
        {
            ResponseTokenModel responseTokenModel = new ResponseTokenModel();

            try
            {

                var client = _clients.SingleOrDefault(x => x.Id == clientModel.ClientId && x.Secret == clientModel.ClientSecret);

                if (client == null && client.DeviceId == null && client.DeviceType == null)
                {
                    responseTokenModel.token = null;
                }
                client.DeviceId = clientModel.DeviceId;
                client.DeviceType = clientModel.DeviceType;
                client.Email = "";
                client.Password = "";
                var token = new TokenManager(configuration).CreateAccessTokenClient(client);
                responseTokenModel.ResultMessage = "İşlme Başarılı";
                responseTokenModel.Result = true;
                responseTokenModel.ResultCode = 200;
                responseTokenModel.token = token;
                return responseTokenModel;//dönecek responsen modeli
            }
            catch (Exception)
            {
                errorLogService.ErrorLogAdd("407 Account/LoginApi  " + clientModel.Email);
                responseTokenModel.ResultMessage = "Gönderilen verilerde bir hata oluştu. Lütfen tekrar deneyiniz.";
                responseTokenModel.Result = false;
                responseTokenModel.ResultCode = 407;
                return responseTokenModel;
            }
        }
        [HttpPost("RefreshToken")]
        [AllowAnonymous]
        public LoginResponse RefreshToken(ClientRefreshTokenModel clientRefreshModel)
        {
            errorLogService.ErrorLogAdd("Account/RefreshToken  " + clientRefreshModel.token);
            LoginResponse loginResponse = new LoginResponse();
            try
            {
                var stream = clientRefreshModel.token;
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(stream);
                var tokenS = jsonToken as JwtSecurityToken;
                ClientModel clientModel = new ClientModel();
                clientModel.Id = tokenS.Payload.Sub;
                clientModel.Secret = tokenS.Payload.Jti;
                clientModel.DeviceId = tokenS.Claims.First(claim => claim.Type == "nameid").Value;
                clientModel.DeviceType = tokenS.Claims.First(claim => claim.Type == "unique_name").Value;
                clientModel.Email = tokenS.Claims.First(claim => claim.Type == "email").Value;
                clientModel.Password = tokenS.Claims.First(claim => claim.Type == "sid").Value;
                clientModel.ProviderKey = tokenS.Claims.First(claim => claim.Type == "azp").Value;
                clientModel.ProviderName = tokenS.Claims.First(claim => claim.Type == "acr").Value;
                LoginRequest loginRequest = new LoginRequest();
                loginRequest.email = clientModel.Email;
                loginRequest.password = clientModel.Password;
                loginRequest.providerKey= clientModel.ProviderKey;
                loginRequest.providerName = clientModel.ProviderName;
                loginResponse=Login(loginRequest,clientModel.Id,clientModel.Secret);
                return loginResponse;//dönecek responsen modeli}
            }
            catch
            {
                loginResponse.user = new User();
                errorLogService.ErrorLogAdd("408 Account/LoginApi  " + clientRefreshModel.token);
                loginResponse.ResultMessage = "Gönderilen verilerde bir hata oluştu. Lütfen tekrar deneyiniz.";
                loginResponse.Result = false;
                loginResponse.ResultCode = 408;
                loginResponse.user.issubscriber = false;
                return loginResponse;
            }
        }
    }
}
