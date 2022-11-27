using Microsoft.AspNetCore.Mvc;
using Quki.Common;
using Quki.Dal.Concrete.Entityframework.Repostories;
using Quki.Interface;

namespace Quki.ViewComponents
{
    public class GetVisitorCommentWithProduct : ViewComponent
    {
        IVisitorCommentService visitorCommentService;
        public IViewComponentResult Invoke()
        {
            Functions.setLanguage(Request.Cookies[".AspNetCore.Culture"]);
            var model = visitorCommentService.GetVisitorCommentsWithProduct(6);
            return View(model);
        }
    }
}
