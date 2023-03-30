using Microsoft.AspNetCore.Mvc;
using Quki.Entity.Models;
using Quki.Interface;
using System.Web.WebPages;

namespace Quki.Controllers
{
    public class ContactController : Controller
    {
        private readonly IVisitorCommentService service;

        public ContactController(IVisitorCommentService service)
        {
            this.service = service;
        }


        public IActionResult Index()
        {          


            return View();
        }

        [HttpPost]
        public IActionResult SendComment(VisitorComment visitorComment)
        {


            service.AddVisitorCommand(visitorComment);

            ViewBag.MyDiv= "<div class=\"alert alert-success\" role=\"alert\"><strong>Teşekkürler. Mesajınız iletildi.</strong></div>";

            return RedirectToAction("Index","AnaSayfa",new VisitorComment());
        }


    }
}
