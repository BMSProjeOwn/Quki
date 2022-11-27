using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quki.Common;

using Quki.Dal.Concrete.Entityframework.Repostories;
using Quki.Interface;


namespace Quki.ViewComponents
{
    public class NewProducts : ViewComponent
    {
        IProductService productService;
        public NewProducts(IProductService productService)
        {
            this.productService = productService;
        }
        public IViewComponentResult Invoke()
        {
            int languageId = Functions.setLanguage(Request.Cookies[".AspNetCore.Culture"]);
            return View(productService.GetLastProducts(8, languageId));
        }
    }
}
