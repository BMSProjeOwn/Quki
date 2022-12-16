using Microsoft.AspNetCore.Mvc;
using Quki.Interface;

namespace Quki.Controllers
{
    [Route("[controller]")]
    public class GaleriController : Controller
    {

        private readonly IProductService repo;
        

        public GaleriController(IProductService repo)
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
