using Microsoft.Extensions.DependencyInjection;
using Quki.Bll.Base;
using Quki.Dal.Abstract;
using Quki.Dal.Concrete.Entityframework.Repostories;
using Quki.Entity.Models;
using Quki.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quki.Entity.DtoModels;
using Quki.Entity.Parameters;
using System.IO;
using Quki.Common;

namespace Quki.Bll
{
    public class SliderManager : BllBase<Slider, SliderModel>, ISliderService
    {
        public readonly ISliderRepository repo;

        public SliderManager(IServiceProvider service) : base(service)
        {
            repo = service.GetService<ISliderRepository>();

        }

        public List<SliderModel> GetSliderList()
        {
            var items = TGetList().OrderByDescending(u => u.SliderSeqId).ToList();
            var model = ObjectMapper.Mapper.Map<List<SliderModel>>(items);
            return model;
        } 
        public List<SliderModel> GetSliderHomeListWithLanguage(int langeage)
        {
            var items = TGetList(x=>x.LanguageId== langeage && x.GroupId==0).OrderByDescending(u => u.SliderSeqId).ToList();
            var model = ObjectMapper.Mapper.Map<List<SliderModel>>(items);
            return model;
        }
        public List<SliderModel> GetSliderAboutUsListWithLanguage(int langeage)
        {
            var items = TGetList(x=>x.LanguageId== langeage && x.GroupId==1).OrderByDescending(u => u.SliderSeqId).ToList();
            var model = ObjectMapper.Mapper.Map<List<SliderModel>>(items);
            return model;
        }
        public bool SliderAdd(SliderModel sliderModel)
        {

            try
            {
                if (sliderModel.ImagePathName != null)
                {
                    var path = Path.GetExtension(sliderModel.ImagePathName.FileName);
                    var newPath = Guid.NewGuid() + path;
                    var ImagePath = Directory.GetCurrentDirectory() + "/wwwroot/AdminImage/ProductImg/" + newPath;
                    var steem = new FileStream(ImagePath, FileMode.Create);
                    sliderModel.ImagePath = "/AdminImage/ProductImg/" + newPath;

                }


                var model = ObjectMapper.Mapper.Map<Slider>(sliderModel);
                model.CreatedOn = DateTime.Now;
                TAdd(model);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool SliderDeleteById(int id)
        {
            bool result = false;

            var x = TGetList(x => x.SliderSeqId == id).FirstOrDefault();
            x.IsActive = false;

            TUpdate(x);
            result = true;
            return result;

        }
        public SliderModel GetProductDetailByID(string id)
        {
            var model = TGetList(x => x.SliderSeqId == Convert.ToInt32(id)).FirstOrDefault();
            var getupdate = ObjectMapper.Mapper.Map<SliderModel>(model);

            return getupdate;

        }
        public void SliderUpdate(SliderModel slider,int id)
        {      
            var update = ObjectMapper.Mapper.Map<Slider>(slider);

            if (slider.ImagePathName != null)
            {
                var path = Path.GetExtension(slider.ImagePathName.FileName);
                var newPath = Guid.NewGuid() + path;
                var ImagePath = Directory.GetCurrentDirectory() + "/wwwroot/AdminImage/ProductImg/" + newPath;
                var steem = new FileStream(ImagePath, FileMode.Create);
                slider.ImagePath = "/AdminImage/ProductImg/" + newPath;
            }

            TUpdate(update);

            

        }

    }
}
