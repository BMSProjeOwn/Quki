using Microsoft.Extensions.DependencyInjection;
using Quki.Bll.Base;
using Quki.Common;
using Quki.Dal.Abstract;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;
using Quki.Entity.Parameters;
using Quki.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Quki.Bll
{
    public class NewsAndAnnouncementManager :BllBase<NewsAndAnnouncement, NewsAndAnnouncementModel>, INewsAndAnnouncementService
    {
        public readonly INewsAndAnnouncementRepository repo;

        public NewsAndAnnouncementManager(IServiceProvider service) : base(service)
        {
            repo = service.GetService<INewsAndAnnouncementRepository>();
        }

        public List<NewsAndAnnouncementModel>GetNewsAndAnnouncementList()
        {

            var items = TGetList().OrderByDescending(u => u.NewsAndAnnouncementSeqId).ToList();
            var model = ObjectMapper.Mapper.Map<List<NewsAndAnnouncementModel>>(items);
            return model;
        }
        public List<NewsAndAnnouncementModel> GetNewsAndAnnouncementListWithLangueage(int langueage)
        {

            var items = TGetList(x=>x.LanguageId==langueage && x.Status==true).OrderByDescending(u => u.NewsAndAnnouncementSeqId).ToList();
            var model = ObjectMapper.Mapper.Map<List<NewsAndAnnouncementModel>>(items);
            return model;
        }

        public bool NewsAndAnnouncementAdd(NewsAndAnnouncementModel newsAndAnnouncementModel)
        {

            try
            {
                var model = ObjectMapper.Mapper.Map<NewsAndAnnouncement>(newsAndAnnouncementModel);
                if (newsAndAnnouncementModel.ImagePathName != null)
                {
                //    var path = Path.GetExtension(NewsAndAnnouncementModel.ImagePathName.FileName);
                //    var newPath = Guid.NewGuid() + path;
                //    var ImagePath = Directory.GetCurrentDirectory() + "/wwwroot/AdminImage/ProductImg/" + newPath;
                //    var steem = new FileStream(ImagePath, FileMode.Create);
                //    NewsAndAnnouncementModel.ImagePath = "/AdminImage/ProductImg/" + newPath;


                    var path = Path.GetExtension(newsAndAnnouncementModel.ImagePathName.FileName);
                    var newPath = Guid.NewGuid() + path;
                    var ImagePath = Directory.GetCurrentDirectory() + "/wwwroot/AdminImage/ProductImg/" + newPath;
                    var ThumbImagePath = Directory.GetCurrentDirectory() + "/wwwroot/AdminImage/ProductImg/Thump" + newPath;
                    var steem = new FileStream(ImagePath, FileMode.Create);
                    newsAndAnnouncementModel.ImagePathName.CopyTo(steem);
                    Utility.ResizeImage(newsAndAnnouncementModel.ImagePathName, ProductImageSize.Height, ProductImageSize.Width, ThumbImagePath);
                    model.ImagePath = "/AdminImage/ProductImg/" + newPath;
                    model.ThumbPath = "/AdminImage/ProductImg/Thump" + newPath;



                }


                
                model.CreatedDate = DateTime.Now;
                TAdd(model);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool NewsAndAnnouncementDeleteById(int id)
        {
            bool result = false;

            var x = TGetList(x => x.NewsAndAnnouncementSeqId == id).FirstOrDefault();
            x.Status = false;

            TUpdate(x);
            result = true;
            return result;

        }
        public NewsAndAnnouncementModel GetProductDetailByID(string id)
        {
            var model = TGetList(x => x.NewsAndAnnouncementSeqId == Convert.ToInt32(id)).FirstOrDefault();
            var getupdate = ObjectMapper.Mapper.Map<NewsAndAnnouncementModel>(model);

            return getupdate;

        }
        public void NewsAndAnnouncementUpdate(NewsAndAnnouncementModel newsAndAnnouncement, int id)
        {
            var update = ObjectMapper.Mapper.Map<NewsAndAnnouncement>(newsAndAnnouncement);

            if (newsAndAnnouncement.ImagePathName != null)
            {
                var path = Path.GetExtension(newsAndAnnouncement.ImagePathName.FileName);
                var newPath = Guid.NewGuid() + path;
                var ImagePath = Directory.GetCurrentDirectory() + "/wwwroot/AdminImage/ProductImg/" + newPath;
                var ThumbImagePath = Directory.GetCurrentDirectory() + "/wwwroot/AdminImage/ProductImg/Thump" + newPath;
                var steem = new FileStream(ImagePath, FileMode.Create);
                newsAndAnnouncement.ImagePathName.CopyTo(steem);
                Utility.ResizeImage(newsAndAnnouncement.ImagePathName, ProductImageSize.Height, ProductImageSize.Width, ThumbImagePath);
                update.ImagePath = "/AdminImage/ProductImg/" + newPath;
                update.ThumbPath = "/AdminImage/ProductImg/Thump" + newPath;
            }

            TUpdate(update);



        }


    }

}
