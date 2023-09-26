using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Quki.Entity.DtoModels;
using Quki.Entity.ViewModel;
using Quki.Interface;
using System;
using System.Collections.Generic;

namespace Quki.Controllers
{
    public class HomeController : Controller
    {


        private readonly IRvcMenuItemDefService rvcMenuItemDefService;
        private readonly Islu_Rvc_RelationService slu_Rvc_RelationService;
        public HomeController(IRvcMenuItemDefService rvcMenuItemDefService, Islu_Rvc_RelationService slu_Rvc_RelationService)
        {
            this.rvcMenuItemDefService = rvcMenuItemDefService;
            this.slu_Rvc_RelationService = slu_Rvc_RelationService;

        }

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
        public IActionResult Index(string id="2")
        {
            List<SluDefModel> sluDefModels = new List<SluDefModel>();
            int languageId = Common.Functions.setLanguage(Request.Cookies[".AspNetCore.Culture"]);
            var getMenuItems = rvcMenuItemDefService.GetMenuItems(languageId,Convert.ToInt32(id));
            try
            {
                sluDefModels = slu_Rvc_RelationService.GetAllSluDefRelationWithSlu(languageId, Convert.ToInt32(id));
            }
            catch
            {

            }
            MenuViewModel menuViewModel = new MenuViewModel();
            menuViewModel.getMenuItems = getMenuItems;
            menuViewModel.sluDefModels = sluDefModels;
            return View(menuViewModel);
        }

    }
}
