using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;

namespace Quki.Dal.Abstract
{
    public interface ITestRepository
    {
        public string GetUserEmail(string userId);
        //public List<BugTrackAddModel> GetUserBugTrackList(Guid userId);
        //public List<BugTrackAddModel> GetBugTrackList();
        //public bool BugTrackAdd(BugTrackAddModel Item);
        //public bool BugTrackDeleteById(int id);
        //public List<SelectListItem> GetDropdownList(string appName);
        //public BugTrackAddModel GetBugTrack(long BugTrackSeqID);
    }
}
