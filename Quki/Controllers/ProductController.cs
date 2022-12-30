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

namespace Quki.Controllers
{
    //[Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly IRvcMenuItemDefService rvcMenuItemDefService;
        private readonly Islu_Rvc_RelationService slu_Rvc_RelationService;

        public ProductController(IRvcMenuItemDefService rvcMenuItemDefService, Islu_Rvc_RelationService slu_Rvc_RelationService)
        {
            this.rvcMenuItemDefService = rvcMenuItemDefService;
            this.slu_Rvc_RelationService = slu_Rvc_RelationService;

        }



       
        public IActionResult Index()
        {


            return View("AnaSayfa");
        }
        [Route("westchocolate-menu")]
        public IActionResult Index2()
        {


            return View("index");
        }



        [HttpGet]
        [Route("westchocolate-menu-kategori")]
        public IActionResult SluDef()
        {
            //https://localhost:44377/product/sludef
            List<SluDefModel> sluDefModels = new List<SluDefModel>();

            try
            {
                sluDefModels = slu_Rvc_RelationService.GetAllSluDefRelationWithSlu();
            }
            catch
            {

            }
            return View(sluDefModels);
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
        [HttpGet]
        [Route("westchocolate-urun/{id?}")]
        public IActionResult GetMenuItem(long id)
        {
            
           
            if (id == 0)
            {
                var getMenuItems = rvcMenuItemDefService.GetMenuItems();
                ViewBag.ProductItems = getMenuItems;
                ViewBag.MenuItems = "TÜMÜ";
                ViewBag.Pic = "/icons/1tumu.png";
            }
            else
            {
                var getMenuItems = rvcMenuItemDefService.GetMenuItemsWithId(id);
                ViewBag.ProductItems = getMenuItems;
                ViewBag.MenuItems = getMenuItems[0].slu_def_name;
                ViewBag.Pic = getMenuItems[0].slu_type_slu_image;

            }

            return View();
        }
    }
}
