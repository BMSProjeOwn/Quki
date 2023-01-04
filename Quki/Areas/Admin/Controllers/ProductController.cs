using Microsoft.AspNetCore.Mvc;

namespace Quki.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
