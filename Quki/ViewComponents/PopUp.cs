using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Quki.Common;
using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Interface;
using Quki.Dal.Abstract;
using Quki.Entity.DtoModels;
using System.Collections.Generic;
using DocumentFormat.OpenXml.Wordprocessing;

namespace Quki.ViewComponents
{
    public class PopUp : ViewComponent
    {
        private readonly INewsAndAnnouncementService service;


        public PopUp(INewsAndAnnouncementService service)
        {
            this.service = service;

        }
        public IViewComponentResult Invoke()
        {
            var league = Common.Functions.setLanguage(Request.Cookies[".AspNetCore.Culture"]);
            var model = service.GetNewsAndAnnouncementListWithLangueage(league).OrderByDescending(x=>x.NewsAndAnnouncementSeqId).Take(1).FirstOrDefault();


            return View(model);
        }
    }
}
