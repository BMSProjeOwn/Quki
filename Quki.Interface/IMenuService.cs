using System.Collections.Generic;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;

namespace Quki.Interface
{
    public interface IMenuService : IGenericService<Menu, MenuModel>
    {
      
        public List<Menu> GetUserMenus();
        public List<Menu> GetUserMenusForDocument();
        public List<Menu> GetMenus();

        public List<Menu> GetUpMenu(int id);


    }
}
