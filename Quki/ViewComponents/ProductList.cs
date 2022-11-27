using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Quki.Common;
using Quki.Entity.Models;
using Quki.Entity.Parameters;
using Quki.Interface;

namespace Quki.ViewComponents
{
    public class ProductList : ViewComponent
    {
        private readonly IProductService productService;
        public ProductList(IProductService productService)
        {
            this.productService = productService;
        }
        //public IViewComponentResult Invoke()
        //{
        //    var items = GetAllItemsAsync();
        //    return View(items);
        //}
        public IViewComponentResult Invoke(int ItemID)
        {
            Functions.setLanguage(Request.Cookies[".AspNetCore.Culture"]);
            var items = GetItemsAsync(ItemID);
            return View(items);
        }

        private List<Products> GetAllItemsAsync()
        {
            int languageId=Functions.setLanguage(Request.Cookies[".AspNetCore.Culture"]);
            var list = productService.GetAllActiveProduct(languageId);
            return list;
        }
        private List<Products> GetItemsAsync(int ItemID)
        {
            Functions.setLanguage(Request.Cookies[".AspNetCore.Culture"]);
            List<Products> list = productService.GetProductsByMedyaTypeID(ItemID, MediaTypes.PreLissen);
            return list;
        }
        private List<Products> GetItemsByNameAsync(string ProductName)
        {
            Functions.setLanguage(Request.Cookies[".AspNetCore.Culture"]);
            int languageId = Functions.setLanguage(Request.Cookies[".AspNetCore.Culture"]);
            List<Products> list = productService.SeachProductWeb(ProductName, languageId);
            return list;
        }
    }
}
