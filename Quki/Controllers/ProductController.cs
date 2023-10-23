using DocumentFormat.OpenXml.Office2010.ExcelAc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Quki.Entity.DtoModels;
using Quki.Entity.DtoModels.ApiModels;
using Quki.Interface;
using Quki.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Quki.Controllers
{
    //[Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly IRvcMenuItemDefService rvcMenuItemDefService;
        private readonly Islu_Rvc_RelationService slu_Rvc_RelationService;
        private readonly ISluDefService slu_DefService;

        public ProductController(IRvcMenuItemDefService rvcMenuItemDefService, Islu_Rvc_RelationService slu_Rvc_RelationService,ISluDefService sluDefService)
        {
            this.rvcMenuItemDefService = rvcMenuItemDefService;
            this.slu_Rvc_RelationService = slu_Rvc_RelationService;
            this.slu_DefService = sluDefService;

        }




        public IActionResult Index()
        {


            
            return RedirectToAction("gorgulu-menu", "menu");
        }
        [Route("menu/gorgulu-menu")]
        public IActionResult Index2()
        {

            Common.Functions.setLanguage(Request.Cookies[".AspNetCore.Culture"]);
            return View("index");
        }



        [HttpGet]
        [Route("menu/gorgulu-menu-kategori")]
        public IActionResult SluDef(int id=0)
        {
            //https://localhost:44377/product/sludef
            
            List<SluDefModel> sluDefModels = new List<SluDefModel>();
            
            int languageId=Common.Functions.setLanguage(Request.Cookies[".AspNetCore.Culture"]);
            try
            {
                sluDefModels = slu_Rvc_RelationService.GetAllSluDefRelationWithSlu(languageId,id);
            }
            catch (Exception ex)
            {

            }
            @ViewBag.ID = id;
            
            return View(sluDefModels);
        }


        [HttpPost]
        public IActionResult CultureManegmant(string culture)
        {
            try
            {
                Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                    new CookieOptions { Expires = DateTimeOffset.Now.AddDays(30) });
                MultiLanguageOmni.ReadResourceKey.cultureName = culture;
                return RedirectToAction(nameof(Index2));

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
        [HttpGet]
        [Route("menu/gorgulu-urun/{id?}")]
        public IActionResult GetMenuItem(long id)
        {

            int languageId = Common.Functions.setLanguage(Request.Cookies[".AspNetCore.Culture"]);
            if (id == 0)
            {
                List<Condiment> condimentRequired = new List<Condiment>();
                List<Condiment> condimentNonRequired = new List<Condiment>();
                var getMenuItems = rvcMenuItemDefService.GetMenuItems(out condimentRequired,out condimentNonRequired,languageId);
                ViewBag.ProductItems = getMenuItems;
                ViewBag.condimentRequired = condimentRequired;
                ViewBag.condimentNonRequired = condimentNonRequired;
                ViewBag.MenuItems = MultiLanguageOmni.ReadResourceKey.GetString("All", "MultiLanguageOmni.Index");
                ViewBag.Pic = "/icons/1tumu.png";
            }
            else
            {

                List<Condiment> condimentRequired = new List<Condiment>();
                List<Condiment> condimentNonRequired = new List<Condiment>();
                var getMenuItems = rvcMenuItemDefService.GetMenuItemsWithId(id,out condimentRequired,out condimentNonRequired,languageId);
                ViewBag.ProductItems = getMenuItems;
                try
                {
                    var items = slu_Rvc_RelationService.GetAllSluDefRelationWithSlu(languageId).Where(x => x.slu_def_seq == id).FirstOrDefault();
                    ViewBag.MenuItems = items.slu_def_name;
                    ViewBag.condimentRequired = condimentRequired;
                    ViewBag.condimentNonRequired = condimentNonRequired;
                    ViewBag.Pic = getMenuItems[0].slu_type_slu_image;
                    ViewBag.ID = items.parent_slu_def_no;
                }
                catch (Exception)
                {
                    ViewBag.MenuItems = slu_Rvc_RelationService.GetAllSluDefRelationWithSlu(languageId).Where(x=>x.slu_def_seq==id).FirstOrDefault().slu_def_name;
                }

            }

            return View();
        }
    }
}
