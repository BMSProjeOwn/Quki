using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Quki.Common;
using Quki.Interface;
using System;

namespace Quki.Controllers
{
    public class DocumentController : Controller
    {
        private readonly IDocumentsService documentsService;
        public DocumentController(IDocumentsService documentsService)
        {
            this.documentsService = documentsService;
        }


        public IActionResult Index()
        {
            return View();
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

        // [Route("/{name?}/{id?}")]
        public IActionResult GetDocument(int id)
        {
            int languageId = Functions.setLanguage(Request.Cookies[".AspNetCore.Culture"]);
            var Value = documentsService.GetDocumentByMenuId(id, languageId);


            return View(Value);
        }
    }
}
