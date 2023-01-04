﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Quki.Interface;
using System;

namespace Quki.Controllers
{
    [Route("[controller]")]
    public class GaleriController : Controller
    {

        private readonly IProductService repo;
        

        public GaleriController(IProductService repo)
        {
            this.repo = repo;

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

        public IActionResult Index()
        {
            
            var model = repo.GetProductList();
            
            return View(model);
        }

    }
}