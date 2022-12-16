using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Dal.Concrete.Entityframework.Repostories;
using Quki.Entity.DtoModels;
using Quki.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Quki.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class MedyaController : Controller
    {
        
        private readonly IAttributeStaticService attributeStaticService; // kaldırılıp product repositorye eklenecek
        private readonly IAttributeStaticValueService attributeStaticValueService;// kaldırılıp product repositorye eklenecek
        private readonly IProductService productsService;
        private readonly ICategoryService categoryService;
        private readonly ILanguageService languageService;
        private readonly IMediaTypesService mediaTypesService;
        private readonly IProductImagesService productImagesService;
        private readonly IProducersService producersService;
        private readonly IProductWithProducersService productWithProducersService;
        public MedyaController(IAttributeStaticService attributeStaticService, IAttributeStaticValueService attributeStaticValueService,
            IProductService productsService, ICategoryService categoryService, ILanguageService languageService, IMediaTypesService mediaTypesService,
            IProductImagesService productImagesService, IProducersService producersService, IProductWithProducersService productWithProducersService)
        {
            this.categoryService = categoryService;
            this.attributeStaticService = attributeStaticService;
            this.attributeStaticValueService = attributeStaticValueService;
            this.productsService = productsService;
            this.languageService = languageService;
            this.mediaTypesService = mediaTypesService;
            this.productImagesService = productImagesService;
            this.producersService = producersService;
            this.productWithProducersService = productWithProducersService;

        }

        public IActionResult Index(int page = 1)
        {
            var items = productsService.GetProductList().ToList();
            return View(items);
        }


        public IActionResult Delete(int id)
        {
            var a = productsService.ProductDeleteById(id);
            return RedirectToAction("Index", "Medya");
        }


        [HttpGet]
        public IActionResult NewItem()
        {
            ProductAddModel p = new ProductAddModel();
            p.ReleaseDate = DateTime.Now;

           
            List<SelectListItem> MedyaType = new List<SelectListItem>();

            SelectListItem type = new SelectListItem();
            type.Text = "Resim";
            type.Value = "0";
            MedyaType.Add(type);

            SelectListItem type1 = new SelectListItem();
            type1.Text = "Video";
            type1.Value = "1";
            MedyaType.Add(type1);
   
            ViewBag.Media = MedyaType;
            return View(p);
        }

        [HttpPost]
        public IActionResult NewItem(ProductAddModel Item)
        {
            //Item.LanguageID = 1;  

            if (!ModelState.IsValid) // Modelde name validation eklendiği için kontorl yapıluıyor
            {
                return View("NewItem");
            }
            productsService.ProductAdd(Item);
            return RedirectToAction("Index");
        }

        public IActionResult Update(string id)
        {
            ProductMergeModel mymodel = new ProductMergeModel();
            if (id.Split('-').Length > 1)
            {
                mymodel = productsService.GetProductDetailForAdd(Convert.ToInt32(id.Split('-')[1]), Convert.ToInt32(id.Split('-')[0]));
                TempData["ProductID"] = mymodel.ProductUpdateModel.ProductSeqID;
                mymodel.ProductUpdateModel.LanguageID = Convert.ToInt32(id.Split('-')[0]);
            }
            else
            {
                TempData["ProductID"] = Convert.ToInt32(id);
                mymodel = productsService.GetProductDetailForAdd(Convert.ToInt32(TempData["ProductID"]), 0);
            }
            TempData.Keep("ProductID");
            //var imagePath = mymodel.ProductUpdateModel.ImagePath.ToString();

            mymodel.ProductUpdateModel.ImagePathName = productsService.GetProductDetail(Convert.ToInt32(TempData["ProductID"])).ImagePath;


            List<SelectListItem> MedyaType = new List<SelectListItem>();

            SelectListItem type = new SelectListItem();
            type.Text = "Resim";
            type.Value = "0";
            MedyaType.Add(type);

            SelectListItem type1 = new SelectListItem();
            type1.Text = "Video";
            type1.Value = "1";
            MedyaType.Add(type1);

            ViewBag.Media = MedyaType;
            return View("Update", mymodel);
        }

        [HttpPost]
        public IActionResult Update(ProductMergeModel model)
        {
            
            int productID = (int)TempData["ProductID"];
            TempData.Keep("ProductID");
            productsService.ProductUpdate(model, productID);


            return RedirectToAction("Index");
        }


    }
}
