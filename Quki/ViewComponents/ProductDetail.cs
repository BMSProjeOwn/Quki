using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Quki.Common;
using Quki.Dal.Concrete.Entityframework.Repostories;
using Quki.Entity.ViewModel;
using Quki.Interface;

namespace Quki.ViewComponents
{
    public class ProductDetail : ViewComponent
    {
        private readonly IProductService productService;

        public ProductDetail(IProductService productService)
        {
            this.productService = productService;
        }
        //    public IViewComponentResult Invoke(
        //int ProductID, bool isDone)
        //    {
        //        var items = GetItemsAsync(ProductID, isDone);
        //        return View(items);
        //    }
        //    private List<ProductAttributeModel> GetItemsAsync(int ProductID, bool isDone)
        //    {
        //        List<ProductAttributeModel> list = productsRepository.GetAttributeModel(ProductID);
        //        return list;


        //    }
        public IViewComponentResult Invoke(int ProductID)
        {
            Functions.setLanguage(Request.Cookies[".AspNetCore.Culture"]);
            var items = GetItemsAsync(ProductID);
            return View(items);
        }
        private List<ProductAttributeModel> GetItemsAsync(int ProductID)
        {
            Functions.setLanguage(Request.Cookies[".AspNetCore.Culture"]);
            List<ProductAttributeModel> list = productService.GetAttributeModel(ProductID);
            return list;


        }
    }
}
