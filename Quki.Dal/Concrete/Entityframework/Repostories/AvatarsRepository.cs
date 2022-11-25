using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quki.Dal.Abstract;
using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Entity.Models;

namespace Quki.Dal.Concrete.Entityframework.Repostories
{
    public class AvatarsRepository : GenericRepository<Avatars>, IAvatarsRepository
    {

        public AvatarsRepository(DbContext context) : base(context)
        {
            
        }

        //public List<Avatars> GetAllProfileAvatars()
        //{
        //    var result = context.Set<Avatars>().Where(w => w.IsActive == true && w.TypeID == 1).ToList();
        //    return result;
        ////}
    }
}
