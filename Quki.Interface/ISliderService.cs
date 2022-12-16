using Quki.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quki.Entity.DtoModels;

namespace Quki.Interface
{
    public interface ISliderService : IGenericService<Slider,SliderModel>
    {
        public List<SliderModel> GetSliderList();
        public bool SliderAdd(SliderModel slider);
        public bool SliderDeleteById(int id);
        public SliderModel GetProductDetailByID(string id);
        public void SliderUpdate(SliderModel sliderModel,int id);

        public List<SliderModel> GetSliderHomeListWithLanguage(int language);
        public List<SliderModel> GetSliderAboutUsListWithLanguage(int langeage);

    }
}
