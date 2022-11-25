using Quki.Entity.Models;
using Quki.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quki.Dal.Abstract
{
    public interface IRvcMenuItemDefRepository :IGenericRepository<RvcMenuItemDef>
    {
        public List<RvcMenuItemDef> GetAll();
       // public List<GetMenuItems> GetAllProductAndProp();
    }
}
