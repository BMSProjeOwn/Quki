using Microsoft.AspNetCore.Mvc;
using Quki.Common;
using Quki.Dal.Concrete.Entityframework.Repostories;
using Quki.Interface;

namespace Quki.ViewComponents
{
    public class GetVisitorComments : ViewComponent
    {

        private readonly IVisitorCommentService visitorCommentService;
        public GetVisitorComments(IVisitorCommentService visitorCommentService)
        {
            this.visitorCommentService = visitorCommentService;
        }
        public IViewComponentResult Invoke()
        {
            //Functions.setLanguage(Request.Cookies[".AspNetCore.Culture"]);
            var model = visitorCommentService.GetUserComment();
            return View(model); 
        }
    }
}
