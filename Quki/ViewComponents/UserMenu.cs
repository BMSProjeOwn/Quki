using Microsoft.AspNetCore.Mvc;
using Quki.Common;
using Quki.Dal.Concrete.Entityframework.Repostories;
using Quki.Interface;

namespace Quki.ViewComponents
{
    public class UserMenu : ViewComponent
    {
        private readonly IMenuService menuService;
            public UserMenu(IMenuService menuService)
        {
                this.menuService = menuService;
        }
        public IViewComponentResult Invoke()
        {
            Functions.setLanguage(Request.Cookies[".AspNetCore.Culture"]);
            var menu = menuService.GetUserMenus();
            return View(menu);
        }
    }
}
