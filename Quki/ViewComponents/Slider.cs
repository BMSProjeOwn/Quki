using Microsoft.AspNetCore.Mvc;
using Quki.Common;

namespace Quki.ViewComponents
{
    public class Slider : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            Functions.setLanguage(Request.Cookies[".AspNetCore.Culture"]);
            return View();
        }
    }
}
