using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quki.Dal.Abstract;
using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Entity.Models;
using Quki.Entity.Parameters;

namespace Quki.Dal.Concrete.Entityframework.Repostories
{
    public class MenuRepository : GenericRepository<Menu>, IMenuRepository
    {
        public MenuRepository(DbContext context) : base(context)
        {
            
        }
        //public List<Menu> GetUserMenus()
        //{
        //    return dbset.Where(I => I.ContentTypeID == MenuContentType.User && I.Status == true&&I.PositionID==1).OrderBy(I=>I.DisplayOrderNumber).ToList();
        //}

        //public List<Menu> GetUserMenusForDocument()
        //{
        //    return dbset.Where(I => I.ContentTypeID == MenuContentType.User && I.Status == true&& I.controller== "Document").OrderBy(I => I.DisplayOrderNumber).ToList();
        //}

        //public List<Menu> GetMenus()
        //{
        //    return dbset.Where(I => I.ContentTypeID == MenuContentType.User && I.Status == true).OrderBy(I => I.DisplayOrderNumber).ToList();
        //}
    }
}
