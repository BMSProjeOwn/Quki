using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Quki.Common;
using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Interface;

namespace Quki.ViewComponents
{
    public class UpMenu : ViewComponent
    {

        private readonly IMenuService menuService;
        public UpMenu(IMenuService menuService)
        {
            this.menuService = menuService;
        }
        public IViewComponentResult Invoke(int menuId)
        {
            int leaguage=Functions.setLanguage(Request.Cookies[".AspNetCore.Culture"]);
            var menu = menuService.GetUpMenu(leaguage);
            return View(menu);
            
        }
    }
}
