using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Host;
using Microsoft.EntityFrameworkCore;
using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Dal.Concrete.Entityframework.Repostories;
using Quki.Entity.DtoModels;
using Quki.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using ILanguageService = Quki.Interface.ILanguageService;

namespace Quki.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class EtkinlikController : Controller
    {
        private readonly INewsAndAnnouncementService newsAndAnnouncementService;
        private readonly ILanguageService languageService;

        public EtkinlikController(INewsAndAnnouncementService newsAndAnnouncementService, Interface.ILanguageService languageService)
        {
            this.newsAndAnnouncementService = newsAndAnnouncementService;
            this.languageService = languageService;
        }

        public IActionResult Index(int page = 1)
        {
            var items = newsAndAnnouncementService.GetNewsAndAnnouncementList().ToList();
            return View(items);
        }
        public IActionResult Delete(int id)
        {

            var a = newsAndAnnouncementService.NewsAndAnnouncementDeleteById(id);
            return RedirectToAction("Index", "Etkinlik");
        }


        [HttpGet]
        public IActionResult NewItem()
        {

            NewsAndAnnouncementModel p = new NewsAndAnnouncementModel();
            p.CreatedDate = DateTime.Now;

            List<SelectListItem> list = languageService.GetAllLanguages2();
            ViewBag.language = list;

            List<SelectListItem> Type = new List<SelectListItem>();

            SelectListItem type = new SelectListItem();
            type.Text = "Haber";
            type.Value = "0";
            Type.Add(type);

            SelectListItem type1 = new SelectListItem();
            type1.Text = "Etkinlik";
            type1.Value = "1";
            Type.Add(type1);

            ViewBag.Type = Type;

          


            return View(p);
        }

        [HttpPost]
        public IActionResult NewItem(NewsAndAnnouncementModel Item)
        {
            if (!ModelState.IsValid) // Modelde name validation eklendiği için kontorl yapıluıyor
            {
                return View("NewItem");
            }
            newsAndAnnouncementService.NewsAndAnnouncementAdd(Item);


            return RedirectToAction("Index");
        }





        public IActionResult Update(string id)
        {
            NewsAndAnnouncementModel mymodel = new NewsAndAnnouncementModel();

            mymodel = newsAndAnnouncementService.GetProductDetailByID(id);
            TempData["ProductID"] = mymodel.NewsAndAnnouncementSeqId;

            List<SelectListItem> list = languageService.GetAllLanguages2();
            ViewBag.language = list;

            List<SelectListItem> Type = new List<SelectListItem>();

            SelectListItem type = new SelectListItem();
            type.Text = "Haber";
            type.Value = "0";
            Type.Add(type);

            SelectListItem type1 = new SelectListItem();
            type1.Text = "Etkinlik";
            type1.Value = "1";
            Type.Add(type1);

            ViewBag.Type = Type;


            //var ImagePath = Directory.GetCurrentDirectory() + "/wwwroot" + mymodel.ImagePath;
            //var steem = new FileStream(ImagePath, FileMode.Create);    
            //mymodel.ImagePathName = steem;


            return View("Update", mymodel);
        }

        [HttpPost]
        public IActionResult Update(NewsAndAnnouncementModel model)
        {

            int productID = (int)TempData["ProductID"];
            TempData.Keep("ProductID");
            newsAndAnnouncementService.NewsAndAnnouncementUpdate(model, productID);


            return RedirectToAction("Index");
        }


    }
}
