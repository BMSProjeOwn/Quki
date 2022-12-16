using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Quki.Common;
using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Interface;
using Quki.Dal.Abstract;
using Quki.Entity.DtoModels;
using System.Collections.Generic;

namespace Quki.ViewComponents
{
    public class AboutSlider : ViewComponent
    {
        private readonly ISliderService sliderService;


        public AboutSlider(ISliderService sliderService)
        {
            this.sliderService = sliderService;

        }
        public IViewComponentResult Invoke()
        {
            var league = Common.Functions.setLanguage(Request.Cookies[".AspNetCore.Culture"]);
            var model = sliderService.GetSliderAboutUsListWithLanguage(league);


            return View(model);
        }
    }
}
