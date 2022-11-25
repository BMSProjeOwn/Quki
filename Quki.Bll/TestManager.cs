using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Quki.Bll.Base;
using Quki.Dal.Abstract;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;
using Quki.Interface;

namespace Quki.Bll
{
    public class TestManager : BllBase<BugTrack, BugTrackAddModel>, ITestService
    {
        public readonly ITestRepository repo;
        public readonly IUserProfileRepository userProfileRepository;
        public readonly IBugTrackDetailRepository bugTrackDetailRepository;
        public TestManager(IServiceProvider service) : base(service)
        {
            repo = service.GetService<ITestRepository>();
            userProfileRepository = service.GetService<IUserProfileRepository>();
            bugTrackDetailRepository = service.GetService<IBugTrackDetailRepository>();
        }

        public List<BugTrackAddModel> GetUserBugTrackList(Guid userId)
        {
            
            var items = TGetList(x => x.TesterSeqID == userId && x.Status == 1).Select(x => new BugTrackAddModel
            {
                BugTrackTitle = x.BugTrackTitle,
                ApplicationName = x.ApplicationName,
                Status = x.Status,
                Description = x.Description,
                Email = repo.GetUserEmail(x.TesterSeqID.ToString()),
                BugTrackSeqID = x.BugTrackSeqID,
                ImagePathName = x.ImagePath,
                VersionNumber = x.VersionNumber
            });

            return items.ToList();
        }


        public List<BugTrackAddModel> GetBugTrackList()
        {
            
            var items = TGetList(a => a.Status == 1).Select(x => new BugTrackAddModel
            {
                BugTrackTitle = x.BugTrackTitle,
                ApplicationName = x.ApplicationName,
                Status = x.Status,
                Email = repo.GetUserEmail(x.TesterSeqID.ToString()),
                AssignedBy = repo.GetUserEmail(bugTrackDetailRepository.TGetList(w => w.BugTrackSeqID == x.BugTrackSeqID).FirstOrDefault().AssignedBy.ToString()),
                ResponseDescription = bugTrackDetailRepository.TGetList(w => w.BugTrackSeqID == x.BugTrackSeqID).FirstOrDefault().ResponseDescription,
                BugTrackSeqID = x.BugTrackSeqID,
                VersionNumber = x.VersionNumber,
                ImagePathName = x.ImagePath
            });

            return items.ToList().OrderByDescending(u => u.BugTrackSeqID).ToList();
        }


        public bool BugTrackAdd(BugTrackAddModel Item)
        {
            BugTrack bugTrack = new BugTrack();
            if (Item.ImagePath != null)
            {
                var path = Path.GetExtension(Item.ImagePath.FileName);
                var newPath = Guid.NewGuid() + path;
                var ImagePath = Directory.GetCurrentDirectory() + "/wwwroot/AdminImage/BugImg/" + newPath;
                var steem = new FileStream(ImagePath, FileMode.Create);
                Item.ImagePath.CopyTo(steem);
                bugTrack.ImagePath = "/AdminImage/BugImg/" + newPath;
            }

            bugTrack.BugTrackTitle = Item.BugTrackTitle;
            bugTrack.Description = Item.Description;
            bugTrack.ApplicationName = Item.ApplicationName;
            bugTrack.TesterSeqID = Item.TesterSeqID;
            bugTrack.VersionNumber = Item.VersionNumber;
            bugTrack.Status = 1;
            bugTrack.CreatedDateTime = DateTime.Now;

            TAdd(bugTrack);

            return true;
        }

        public bool BugTrackDeleteById(int id)
        {
            bool result = false;

            var x = TGetList(x => x.BugTrackSeqID == id).FirstOrDefault();

            x.Status = 0;

            TUpdate(x);
            result = true;
            return result;
        }


        public List<SelectListItem> GetDropdownList(string appName)
        {

            List<SelectListItem> list = (from x in TGetList(i => i.Status == 1 && i.ApplicationName == appName)
                                         select new SelectListItem
                                         {
                                             Value = x.ApplicationName
                                         }).ToList();
            return list;
        }

        public BugTrackAddModel GetBugTrack(long BugTrackSeqID)
        {


            var items = TGetList(a => a.Status == 1 && a.BugTrackSeqID == BugTrackSeqID).Select(x => new BugTrackAddModel
            {
                BugTrackTitle = x.BugTrackTitle,
                ApplicationName = x.ApplicationName,
                Description = x.Description,
                CreatedDateTime = x.CreatedDateTime,
                Status = x.Status,
                Email = repo.GetUserEmail(x.TesterSeqID.ToString()),
                AssignedBy = repo.GetUserEmail(bugTrackDetailRepository.TGetList(w => w.BugTrackSeqID == x.BugTrackSeqID).FirstOrDefault().AssignedBy.ToString()),
                ResponseDescription = bugTrackDetailRepository.TGetList(w => w.BugTrackSeqID == x.BugTrackSeqID).FirstOrDefault().ResponseDescription,
                BugTrackSeqID = x.BugTrackSeqID,
                VersionNumber = x.VersionNumber,
                ImagePathName = x.ImagePath
            });

            return items.FirstOrDefault();
        }

    }
}
