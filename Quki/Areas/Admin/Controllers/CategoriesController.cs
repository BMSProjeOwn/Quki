using Microsoft.AspNetCore.Mvc;

namespace Quki.Areas.Admin.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
