using Microsoft.Extensions.DependencyInjection;
using System;
using Quki.Bll.Base;
using Quki.Dal.Abstract;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;
using Quki.Interface;

namespace Quki.Bll
{
    public class BugTrackDetailManager : BllBase<BugTrackDetail, BugTrackDetailAddModel>, IBugTrackDetailService
    {
        public readonly IBugTrackDetailRepository bugTrackDetailRepository;

        public BugTrackDetailManager(IServiceProvider service) :base(service)
        {
            bugTrackDetailRepository = service.GetService<IBugTrackDetailRepository>();
        }
        public bool BugDetailTrackAdd(BugTrackDetailAddModel Item)
        {
            BugTrackDetail bugTrackDetail = new BugTrackDetail();

            bugTrackDetail.ResponseDescription = Item.ResponseDescription;
            bugTrackDetail.BugTrackSeqID = Item.BugTrackSeqID;
            bugTrackDetail.AssignedBy = Item.AssignedBy;
            bugTrackDetail.Status = 1;
            TAdd(bugTrackDetail);

            return true;
        }
    }
}
