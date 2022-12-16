using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Quki.Common;
using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Interface;
using Quki.Dal.Abstract;
using System;

namespace Quki.ViewComponents
{
    public class NewsBlogPage : ViewComponent
    {
        private readonly INewsAndAnnouncementService service;
        public NewsBlogPage(INewsAndAnnouncementService service)
        {
            this.service = service;
        }
        public IViewComponentResult Invoke()
        {
            int languageId=Functions.setLanguage(Request.Cookies[".AspNetCore.Culture"]);
            var model = service.GetNewsAndAnnouncementListWithLangueage(languageId);

            double count = (10 / 9);

            var pagecount = Math.Round(count, MidpointRounding.AwayFromZero);
            pagecount++;
            model[0].PageCount=(int)pagecount;
            
            return View(model);
        }
    }
}
