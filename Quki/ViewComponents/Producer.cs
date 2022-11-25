using Microsoft.AspNetCore.Mvc;
using Quki.Common;
using Quki.Dal.Concrete.Entityframework.Repostories;
using Quki.Interface;

namespace Quki.ViewComponents
{
    public class Producer : ViewComponent
    {

        private readonly IProducersService producersService;
        public Producer(IProducersService producersService)
        {
            this.producersService = producersService;
        }
        public IViewComponentResult Invoke()
        {
            Functions.setLanguage(Request.Cookies[".AspNetCore.Culture"]);
            var producer = producersService.GetLastProducer(20); //TO DO: Propertieslere eklemek lazım kaç tane Seslendiren Göstermek istersiniz diye
            return View(producer);
        }
    }
}
