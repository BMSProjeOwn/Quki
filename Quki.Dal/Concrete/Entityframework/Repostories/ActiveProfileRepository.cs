using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Quki.Dal.Abstract;
using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Entity.Models;

namespace Quki.Dal.Concrete.Entityframework.Repostories
{
    public class ActiveProfileRepository : GenericRepository<ActiveProfile>, IActiveProfileRepository
    {
        public ActiveProfileRepository(DbContext context) : base(context)
        {
        }

        //public void SetActiveProfile(string ProfileUserID, string DeviceId, string DeviceType, string Version)
        //{
        //    var result = context.ActiveProfile.Where(w => w.ProfileUserID == ProfileUserID).FirstOrDefault();
        //    if (result != null)
        //    {
        //        result.LastActiveDate = DateTime.Now;
        //        result.DeviceID = DeviceId;
        //        result.DeviceType = DeviceType;
        //        result.Version = Version;
        //        TUpdate(result);
        //    }
        //    else
        //    {
        //        ActiveProfile savemodel = new ActiveProfile();
        //        savemodel.ProfileUserID = ProfileUserID;
        //        savemodel.LastActiveDate = DateTime.Now;
        //        savemodel.DeviceID = DeviceId;
        //        savemodel.DeviceType = DeviceType;
        //        savemodel.Version = Version;
        //        TAdd(savemodel);
        //    }
        //}

        //public void SetActiveInProfile(string ProfileUserID, string DeviceId, string DeviceType, string Version)
        //{
        //    var result = context.ActiveProfile.Where(w => w.ProfileUserID == ProfileUserID).FirstOrDefault();
        //    if (result != null)
        //    {
        //        result.LastActiveDate = DateTime.Now.AddYears(-100);
        //        result.DeviceID = DeviceId;
        //        result.DeviceType = DeviceType;
        //        result.Version = Version;
        //        TUpdate(result);
        //    }
        //    else
        //    {
        //        ActiveProfile savemodel = new ActiveProfile();
        //        savemodel.ProfileUserID = ProfileUserID;
        //        savemodel.LastActiveDate = DateTime.Now.AddYears(-100);
        //        savemodel.DeviceID = DeviceId;
        //        savemodel.DeviceType = DeviceType;
        //        savemodel.Version = Version;
        //        TAdd(savemodel);
        //    }
        //}
    }
}
