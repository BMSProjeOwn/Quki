using Microsoft.AspNetCore.Mvc;
using Quki.Interface;

namespace Quki.Controllers
{
    [Route("[controller]")]
    public class AboutUsController : Controller
    {

        private readonly IProductService repo;
        

        public AboutUsController(IProductService repo)
        {
            this.repo = repo;

        }


        public IActionResult Index()
        {
            
            var model = repo.GetProductList();
            
            return View(model);
        }

    }
}
