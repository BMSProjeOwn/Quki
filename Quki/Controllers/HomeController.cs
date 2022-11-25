using Microsoft.AspNetCore.Mvc;

namespace Quki.Controllers
{
    public class HomeController : Controller
    {


        public IActionResult Index()
        {
            return View();
        }

    }
}
