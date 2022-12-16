using Microsoft.EntityFrameworkCore;
using Quki.Dal.Abstract;
using Quki.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quki.Dal.Concrete.Entityframework.Repostories
{
     public class NewsAndAnnouncementRepository:GenericRepository<NewsAndAnnouncement>,INewsAndAnnouncementRepository
    {

        public NewsAndAnnouncementRepository(DbContext context) : base(context)
        {
        }

    }
}
