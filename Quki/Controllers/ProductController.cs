﻿using DocumentFormat.OpenXml.Office2010.ExcelAc;
using Microsoft.AspNetCore.Mvc;
using Quki.Entity.DtoModels;
using Quki.Entity.DtoModels.ApiModels;
using Quki.Interface;
using Quki.Models;
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


            return View();
        }



        [HttpGet]
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


        [HttpGet]
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
                ViewBag.Pic = "/icons/1tumu.png";

            }

            return View();
        }
    }
}