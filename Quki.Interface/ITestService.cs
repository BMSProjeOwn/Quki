using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;

namespace Quki.Interface
{
    public interface ITestService : IGenericService<BugTrack, BugTrackAddModel>
    {
        public List<BugTrackAddModel> GetUserBugTrackList(Guid userId);
        public List<BugTrackAddModel> GetBugTrackList();
        public bool BugTrackAdd(BugTrackAddModel Item);
        public bool BugTrackDeleteById(int id);
        public List<SelectListItem> GetDropdownList(string appName);
        public BugTrackAddModel GetBugTrack(long BugTrackSeqID);
    }
}
