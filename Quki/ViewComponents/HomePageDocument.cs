using Microsoft.AspNetCore.Mvc;
using Quki.Common;
using Quki.Dal.Concrete.Entityframework.Repostories;
using Quki.Entity.Models;
using Quki.Interface;

namespace Quki.ViewComponents
{
    public class HomePageDocument : ViewComponent
    {
        private readonly IDocumentsService documentsService;
        public HomePageDocument(IDocumentsService documentsService)
        {
            this.documentsService = documentsService;
        }
        public IViewComponentResult Invoke(
   int ItemID)
        {
            var items = GetItemsAsync(ItemID);
            return View(items);
        }
        private Document GetItemsAsync(int ProductID)
        {
            int languageId = Functions.setLanguage(Request.Cookies[".AspNetCore.Culture"]);
            Document documnet = documentsService.GetDocumentByMenuId(ProductID,languageId);
            return documnet;


        }
    }
}
