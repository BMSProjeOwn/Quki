using Quki.Entity.DtoModels;
using Quki.Entity.Models;
using Quki.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quki.Interface
{
    public interface IRvcMenuItemDefService : IGenericService<RvcMenuItemDef, RvcMenuItemDefModel>
    {
        public List<RvcMenuItemDef> GetAllRvcMenuItems();
        public List<GetMenuItems> GetMenuItems(int languageId);
        public List<GetMenuItems> GetMenuItems();
        public List<GetMenuItems> GetMenuItemsWithId(long id,int languageId);
        public List<GetMenuItems> GetMenuItemsWithId(long id);

    }
}
