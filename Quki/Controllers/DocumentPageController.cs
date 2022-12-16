using Microsoft.AspNetCore.Mvc;
using Quki.Common;
using Quki.Interface;
using System;

namespace Quki.Controllers
{
    public class DocumentPageController : Controller
    {

        private readonly IDocumentsService documentsService;
        public DocumentPageController(IDocumentsService documentsService)
        {
            this.documentsService = documentsService;
        }


        public IActionResult Index()
        {
            return View();
        }


       // [Route("/{name?}/{id?}")]
        public IActionResult AboutUs()
        {
            int id = 5;
            int languageId = Functions.setLanguage(Request.Cookies[".AspNetCore.Culture"]);
            var Value = documentsService.GetDocumentByMenuId(id, languageId);


            return View(Value);
        }
    }
}