using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Quki.Dal.Abstract;
using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;

namespace Quki.Dal.Concrete.Entityframework.Repostories
{
    public class TestRepository : GenericRepository<BugTrack>, ITestRepository
    {
        public TestRepository(DbContext context) : base(context)
        {
            
        }

        public string GetUserEmail(string userId)
        {

            string Email = context.Set<AppUser>().Where(w => w.Id == userId).FirstOrDefault().Email;
            return Email;   
        }


        //public List<BugTrackAddModel> GetBugTrackList()
        //{
        //    UserProfileRepository userProfileRepository = new UserProfileRepository(context);

        //    var items =dbset.Where(a => a.Status == 1).Select(x => new BugTrackAddModel
        //    {
        //        BugTrackTitle = x.BugTrackTitle,
        //        ApplicationName = x.ApplicationName,
        //        Status = x.Status,
        //        Email = context.Set<AppUser>().Where(w=> w.Id== x.TesterSeqID.ToString()).FirstOrDefault().Email,
        //        AssignedBy = context.Set<AppUser>().Where(w => w.Id == context.Set<BugTrackDetail>().Where(w => w.BugTrackSeqID == x.BugTrackSeqID).FirstOrDefault().AssignedBy.ToString()).FirstOrDefault().Email,
        //        ResponseDescription = context.Set<BugTrackDetail>().Where(w => w.BugTrackSeqID == x.BugTrackSeqID).FirstOrDefault().ResponseDescription,
        //        BugTrackSeqID = x.BugTrackSeqID,
        //        VersionNumber = x.VersionNumber,
        //        ImagePathName = x.ImagePath
        //    });

        //    return items.ToList().OrderByDescending(u => u.BugTrackSeqID).ToList();
        //}


        //public bool BugTrackAdd(BugTrackAddModel Item)
        //{
        //    BugTrack bugTrack = new BugTrack();
        //    if (Item.ImagePath != null)
        //    {
        //        var path = Path.GetExtension(Item.ImagePath.FileName);
        //        var newPath = Guid.NewGuid() + path;
        //        var ImagePath = Directory.GetCurrentDirectory() + "/wwwroot/AdminImage/BugImg/" + newPath;
        //        var steem = new FileStream(ImagePath, FileMode.Create);
        //        Item.ImagePath.CopyTo(steem);
        //        bugTrack.ImagePath = "/AdminImage/BugImg/" + newPath;
        //    }

        //    bugTrack.BugTrackTitle = Item.BugTrackTitle;
        //    bugTrack.Description = Item.Description;
        //    bugTrack.ApplicationName = Item.ApplicationName;
        //    bugTrack.TesterSeqID = Item.TesterSeqID;
        //    bugTrack.VersionNumber = Item.VersionNumber;
        //    bugTrack.Status = 1;
        //    bugTrack.CreatedDateTime = DateTime.Now;

        //    TAdd(bugTrack);

        //    return true;
        //}

        //public bool BugTrackDeleteById(int id)
        //{
        //    bool result = false;

        //    var x = dbset.Where(x => x.BugTrackSeqID == id).FirstOrDefault();

        //    x.Status = 0;
            
        //    TUpdate(x);
        //    result = true;
        //    return result;
        //}


        //public List<SelectListItem> GetDropdownList(string appName)
        //{

        //    List<SelectListItem> list = (from x in dbset.Where(i => i.Status == 1 && i.ApplicationName == appName)
        //                                 select new SelectListItem
        //                                 {
        //                                     Value = x.ApplicationName
        //                                 }).ToList();
        //    return list;
        //}

        //public BugTrackAddModel GetBugTrack(long BugTrackSeqID)
        //{
        //    UserProfileRepository userProfileRepository = new UserProfileRepository(context);

        //    var items = dbset.Where(a => a.Status == 1 && a.BugTrackSeqID== BugTrackSeqID).Select(x => new BugTrackAddModel
        //    {
        //        BugTrackTitle = x.BugTrackTitle,
        //        ApplicationName = x.ApplicationName,
        //        Description = x.Description,
        //        CreatedDateTime = x.CreatedDateTime,
        //        Status = x.Status,
        //        Email = context.Set<AppUser>().Where(w => w.Id == x.TesterSeqID.ToString()).FirstOrDefault().Email,
        //        AssignedBy = context.Set<AppUser>().Where(w => w.Id == context.Set<BugTrackDetail>().Where(w => w.BugTrackSeqID == x.BugTrackSeqID).FirstOrDefault().AssignedBy.ToString()).FirstOrDefault().Email,
        //        ResponseDescription = context.Set<BugTrackDetail>().Where(w => w.BugTrackSeqID == x.BugTrackSeqID).FirstOrDefault().ResponseDescription,
        //        BugTrackSeqID = x.BugTrackSeqID,
        //        VersionNumber = x.VersionNumber,
        //        ImagePathName = x.ImagePath
        //    });

        //    return items.FirstOrDefault();
        //}

    }
}
