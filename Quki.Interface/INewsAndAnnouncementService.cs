using Quki.Entity.DtoModels;
using Quki.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quki.Interface
{
    public interface INewsAndAnnouncementService:IGenericService<NewsAndAnnouncement, NewsAndAnnouncementModel>
    {
        public List<NewsAndAnnouncementModel> GetNewsAndAnnouncementList();       
        public List<NewsAndAnnouncementModel> GetNewsAndAnnouncementListWithLangueage(int language);       
        public bool NewsAndAnnouncementAdd(NewsAndAnnouncementModel newsAndAnnouncementModel);
        public bool NewsAndAnnouncementDeleteById(int id);
        public NewsAndAnnouncementModel GetProductDetailByID(string id);
        public void NewsAndAnnouncementUpdate(NewsAndAnnouncementModel newsAndAnnouncementModel, int id);


    }
}
