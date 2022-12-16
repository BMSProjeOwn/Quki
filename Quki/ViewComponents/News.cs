using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Quki.Common;
using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Interface;
using Quki.Dal.Abstract;

namespace Quki.ViewComponents
{
    public class News : ViewComponent
    {
        private readonly INewsAndAnnouncementService service;
        public News(INewsAndAnnouncementService service)
        {
            this.service = service;
        }
        public IViewComponentResult Invoke()
        {
            int languageId=Functions.setLanguage(Request.Cookies[".AspNetCore.Culture"]);
            var model = service.GetNewsAndAnnouncementListWithLangueage(languageId);
            return View(model);
        }
    }
}
