using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Quki.Common;
using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Dal.Concrete.Entityframework.Repostories;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;
using Quki.Entity.ViewModel;
using Quki.Interface;
using Quki.Models;
using log4net.Repository.Hierarchy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;

namespace Quki.Controllers
{
    public class AccountController : Controller
    {
        public UserManager<AppUser> UserMeneger { get; }
        public SignInManager<AppUser> SignInManager { get; }
        public RoleManager<IdentityRole> RoleManager { get; }
        public ILogger<AccountController> Logger { get; }


        private readonly AppleSettings _appSettings;
        ProjeDBContext context = new ProjeDBContext();
       


        public AccountController(UserManager<AppUser> userMeneger, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager,
            ILogger<AccountController> logger, IOptions<AppleSettings> appSettings)
        {
            UserMeneger = userMeneger;
            SignInManager = signInManager;
            RoleManager = roleManager;
            Logger = logger;
            _appSettings = appSettings.Value;

        }
        [HttpGet]

        [HttpPost]
        public IActionResult CultureManegmant(string culture)
        {
            try
            {
                Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                    new CookieOptions { Expires = DateTimeOffset.Now.AddDays(30) });
                return RedirectToAction(nameof(Index));

            }

            catch (Exception ex)
            {
                Log.LogProcess.LogClass.LogType = Log.LogProcess.LogType.Login;
                Log.LogProcess.LogClass.LogLevel = Log.LogProcess.LogLevel.Error;
                Log.LogProcess.LogClass.Message = "GET CultureManegmant yüklenirken hata oluştu: \n" +
                    ex.Message;
                Log.LogProcess.setLogForError();
                return View("Error");
            }

        }
        public IActionResult AdminLogin()
        {
            try
            {
                return View(new LoginViewModel());
            }
            catch (Exception ex)
            {
                Log.LogProcess.LogClass.LogType = Log.LogProcess.LogType.Login;
                Log.LogProcess.LogClass.LogLevel = Log.LogProcess.LogLevel.Error;
                Log.LogProcess.LogClass.Message = " Admin sayfası yüklenirken hata oluştu \n" +
                    ex.Message;
                Log.LogProcess.setLogForError();
                return View(new LoginViewModel());
            }
        }
        [HttpPost]
        public IActionResult AdminLogin(LoginViewModel appUserModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = UserMeneger.FindByEmailAsync(appUserModel.Email).Result;

                    if (user != null && !user.EmailConfirmed && UserMeneger.CheckPasswordAsync(user, appUserModel.Password).Result)
                    {
                        Log.LogProcess.LogClass.LogType = Log.LogProcess.LogType.Login;
                        Log.LogProcess.LogClass.LogLevel = Log.LogProcess.LogLevel.Info;
                        Log.LogProcess.LogClass.UserID = new Guid(user.Id);
                        Log.LogProcess.LogClass.Message = " Email aktif değil. Girilen Mail Bilgisi : " + appUserModel.Email;
                        Log.LogProcess.setLogForTranstion();
                        ModelState.AddModelError("", " Email aktif değil.");
                        return View(appUserModel);
                    }
                    var siginResult = SignInManager.PasswordSignInAsync(appUserModel.Email, appUserModel.Password, appUserModel.RemmemberMe, false).Result;
                    if (siginResult.Succeeded)
                    {
                        Log.LogProcess.LogClass.LogType = Log.LogProcess.LogType.Login;
                        Log.LogProcess.LogClass.LogLevel = Log.LogProcess.LogLevel.Info;
                        Log.LogProcess.LogClass.UserID = new Guid(user.Id);
                        Log.LogProcess.LogClass.Message = " Giriş Başarılı. Girilen Mail Bilgisi : " + appUserModel.Email;
                        Log.LogProcess.setLogForTranstion();
                        return RedirectToAction("Index", "Home", new { area = "Admin" });
                        //   return RedirectToAction("EntryDashBoard", "Reports", new { area = "Admin" });
                    }
                    else
                    {
                        Log.LogProcess.LogClass.LogType = Log.LogProcess.LogType.Login;
                        Log.LogProcess.LogClass.LogLevel = Log.LogProcess.LogLevel.Info;
                        Log.LogProcess.LogClass.Message = " Giriş bilgileri hatalı. Girilen Mail Bilgisi : " + appUserModel.Email;
                        Log.LogProcess.setLogForTranstion();
                        ModelState.AddModelError("", "Giriş bilgileri hatalı.");
                        return View(appUserModel);
                    }

                }
                catch (Exception ex)
                {
                    Log.LogProcess.LogClass.LogType = Log.LogProcess.LogType.Login;
                    Log.LogProcess.LogClass.LogLevel = Log.LogProcess.LogLevel.Error;
                    Log.LogProcess.LogClass.Message = " Admin Girişinde Hata Oluştu : " + appUserModel.Email + "\n" +
                        ex.Message;
                    Log.LogProcess.setLogForError();
                    return View(appUserModel);
                }

            }
            else
            {
                return View(appUserModel);
            }
        }
    }

}
