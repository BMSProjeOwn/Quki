using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Quki.Common;
using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Interface;
using Quki.Entity.DtoModels;
using System.Collections.Generic;

namespace Quki.ViewComponents
{
    public class HomeSlider : ViewComponent
    {
        private readonly ISliderService sliderService;


        public HomeSlider(ISliderService sliderService)
        {
            this.sliderService = sliderService;

        }
        public IViewComponentResult Invoke()
        {
            var league = Common.Functions.setLanguage(Request.Cookies[".AspNetCore.Culture"]);
            List<SliderModel> s = new List<SliderModel>();

            var model = sliderService.GetSliderHomeListWithLanguage(league);


            return View(model);
        }
    }
}
