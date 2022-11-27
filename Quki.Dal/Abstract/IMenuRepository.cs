using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Entity.Models;
using Quki.Entity.Parameters;

namespace Quki.Dal.Abstract
{
    public interface IMenuRepository : IGenericRepository<Menu>
    {
      
        //public List<Menu> GetUserMenus();
        //public List<Menu> GetUserMenusForDocument();
        //public List<Menu> GetMenus();
        
    }
}
