using Microsoft.AspNetCore.Mvc;
using Quki.Dal.Concrete.Entityframework.Repostories;
using Quki.Interface;

namespace Quki.Areas.Admin.ViewComponents
{
    public class AdminMenu: ViewComponent
    {
        private readonly ICategoryService categoryService;
        public AdminMenu(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
