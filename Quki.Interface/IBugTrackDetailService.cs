using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quki.Entity.DtoModels;
using Quki.Entity.DtoModels.ApiModels;
using Quki.Entity.Models;

namespace Quki.Interface
{
    public interface IBugTrackDetailService : IGenericService<BugTrackDetail, BugTrackDetailAddModel>
    {
        public bool BugDetailTrackAdd(BugTrackDetailAddModel Item);
    }
}
