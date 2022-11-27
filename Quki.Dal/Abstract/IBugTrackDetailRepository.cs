using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;

namespace Quki.Dal.Abstract
{
    public interface IBugTrackDetailRepository : IGenericRepository<BugTrackDetail>
    {
        //public bool BugDetailTrackAdd(BugTrackDetailAddModel Item);
    }
}
