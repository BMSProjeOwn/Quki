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
using System.IO;
using System.Linq;
using ILanguageService = Quki.Interface.ILanguageService;

namespace Quki.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SliderController : Controller
    {
        private readonly ISliderService sliderService;
        private readonly ILanguageService languageService;

        public SliderController(ISliderService sliderService, Interface.ILanguageService languageService)
        {
            this.sliderService = sliderService;
            this.languageService = languageService;
        }

        public IActionResult Index(int page = 1)
        {
            var items = sliderService.GetSliderList().ToList();
            return View(items);
        }
        public IActionResult Delete(int id)
        {
            var a = sliderService.SliderDeleteById(id);
            return RedirectToAction("Index", "Slider");
        }


        [HttpGet]
        public IActionResult NewItem()
        {
            SliderModel p = new SliderModel();
            p.CreatedOn = DateTime.Now;

            List<SelectListItem> list = languageService.GetAllLanguages2();
            ViewBag.language = list;

            List<SelectListItem> SliderType = new List<SelectListItem>();

            SelectListItem type = new SelectListItem();
            type.Text = "Ana Sayfa";
            type.Value = "0";
            SliderType.Add(type);

            SelectListItem type1 = new SelectListItem();
            type1.Text = "Hakkımızda";
            type1.Value = "1";
            SliderType.Add(type1);

            ViewBag.Type = SliderType;

            return View(p);
        }

        [HttpPost]
        public IActionResult NewItem(SliderModel Item)
        {
            if (!ModelState.IsValid) // Modelde name validation eklendiği için kontorl yapıluıyor
            {
                return View("NewItem");
            }
            sliderService.SliderAdd(Item);


            return RedirectToAction("Index");
        }


        public IActionResult Update(string id)
        {
            SliderModel mymodel = new SliderModel();

            mymodel = sliderService.GetProductDetailByID(id);
            TempData["ProductID"] = mymodel.SliderSeqId;

            List<SelectListItem> list = languageService.GetAllLanguages2();
            ViewBag.language = list;

            List<SelectListItem> SliderType = new List<SelectListItem>();

            SelectListItem type = new SelectListItem();
            type.Text = "Ana Sayfa";
            type.Value = "0";
            SliderType.Add(type);

            SelectListItem type1 = new SelectListItem();
            type1.Text = "Hakkımızda";
            type1.Value = "1";
            SliderType.Add(type1);

            ViewBag.Type = SliderType;


            //var ImagePath = Directory.GetCurrentDirectory() + "/wwwroot" + mymodel.ImagePath;
            //var steem = new FileStream(ImagePath, FileMode.Create);    
            //mymodel.ImagePathName = steem;


            return View("Update", mymodel);
        }

        [HttpPost]
        public IActionResult Update(SliderModel model)
        {
            int productID = (int)TempData["ProductID"];
            TempData.Keep("ProductID");
            sliderService.SliderUpdate(model, productID);


            return RedirectToAction("Index");
        }


    }
}
