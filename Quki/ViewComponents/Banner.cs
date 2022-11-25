using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Quki.Common;
using Quki.Dal.Concrete.Entityframework.Context;

namespace Quki.ViewComponents
{
    public class Banner : ViewComponent
    {
        public IViewComponentResult Invoke(int menuId)
        {
            int languageId=Functions.setLanguage(Request.Cookies[".AspNetCore.Culture"]);
            var context = new ProjeDBContext();
            var menuList = context.Menu.Where(x => x.MenuID == menuId && x.LanguageID== languageId).FirstOrDefault();
            return View(menuList);
        }
    }
}
