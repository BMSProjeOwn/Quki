using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Quki.Common;
using Quki.Dal.Concrete.Entityframework.Repostories;
using Quki.Interface;

namespace Quki.ViewComponents
{
    public class Category:ViewComponent
    {

        private readonly ICategoryService categoryService;
        public Category(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        public IViewComponentResult Invoke() {
            int languageId = Functions.setLanguage(Request.Cookies[".AspNetCore.Culture"]);
            return View(categoryService.TGetList().Where(x=>x.Status == true && x.LanguageID.Equals(languageId)).ToList());
        }
    }
}
