using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using Quki.Bll.Base;
using Quki.Dal.Abstract;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;
using Quki.Entity.Parameters;
using Quki.Interface;

namespace Quki.Bll
{
    public class MenuManager : BllBase<Menu, MenuModel>, IMenuService
    {
        public readonly IMenuRepository repo;
        public MenuManager(IServiceProvider service) : base(service)
        {
            repo = service.GetService<IMenuRepository>();
        }
        public List<Menu> GetUserMenus()
        {
            return TGetList(I => I.ContentTypeID == MenuContentType.User && I.Status == true && I.PositionID == 1).OrderBy(I => I.DisplayOrderNumber).ToList();
        } 
        public List<Menu> GetUpMenu(int id)
        {
            return TGetList(I=>I.LanguageID==id && I.Status == true && I.PositionID == 1).OrderBy(I => I.DisplayOrderNumber).ToList();
        }

        public List<Menu> GetUserMenusForDocument()
        {
            return TGetList(I => I.ContentTypeID == MenuContentType.User && I.Status == true && I.controller == "Document").OrderBy(I => I.DisplayOrderNumber).ToList();
        }

        public List<Menu> GetMenus()
        {
            return TGetList(I => I.ContentTypeID == MenuContentType.User && I.Status == true).OrderBy(I => I.DisplayOrderNumber).ToList();
        }

    }
}
