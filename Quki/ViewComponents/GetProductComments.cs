using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Quki.Common;
using Quki.Dal.Abstract;
using Quki.Entity.ViewModel;

namespace Quki.ViewComponents
{
    public class GetProductComments : ViewComponent
    {
        IVisitorCommentsRepository visitorCommentsRepository; 
        public IViewComponentResult Invoke(int productId)
        {
            Functions.setLanguage(Request.Cookies[".AspNetCore.Culture"]);
            var items = GetItemsAsync(productId);    
            return View(items);
        }


        public List<VisitorCommentsModel> GetItemsAsync(int productId)
        {
            Functions.setLanguage(Request.Cookies[".AspNetCore.Culture"]);
            List<VisitorCommentsModel> list = visitorCommentsRepository.GetProductComments(productId);
            return list;
        }

    }
}
