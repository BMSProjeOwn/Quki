using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Quki.Dal.Abstract;
using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;

namespace Quki.Dal.Concrete.Entityframework.Repostories
{
    public class BugTrackDetailRepository : GenericRepository<BugTrackDetail>,IBugTrackDetailRepository
    {
        public BugTrackDetailRepository(DbContext context) : base(context)
        {
        }
        //public bool BugDetailTrackAdd(BugTrackDetailAddModel Item)
        //{
        //    BugTrackDetail bugTrackDetail = new BugTrackDetail();

        //    bugTrackDetail.ResponseDescription = Item.ResponseDescription;
        //    bugTrackDetail.BugTrackSeqID = Item.BugTrackSeqID;
        //    bugTrackDetail.AssignedBy = Item.AssignedBy;
        //    bugTrackDetail.Status = 1;
        //    TAdd(bugTrackDetail);

        //    return true;
        //}
    }
}
