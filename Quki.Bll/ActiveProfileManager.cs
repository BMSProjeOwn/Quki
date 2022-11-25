using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using Quki.Bll.Base;
using Quki.Dal.Abstract;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;
using Quki.Interface;

namespace Quki.Bll
{
    public class ActiveProfileManager : BllBase<ActiveProfile, ActiveProfileModel>, IActiveProfileService
    {
        public readonly IActiveProfileRepository activeProfileRepository;

        public ActiveProfileManager(IServiceProvider service) : base(service)
        {
            activeProfileRepository = service.GetService<IActiveProfileRepository>();
        }

        public void SetActiveProfile(string ProfileUserID, string DeviceId, string DeviceType, string Version)
        {
            var result = TGetList(w => w.ProfileUserID == ProfileUserID).FirstOrDefault();
            if (result != null)
            {
                result.LastActiveDate = DateTime.Now;
                result.DeviceID = DeviceId;
                result.DeviceType = DeviceType;
                result.Version = Version;
                TUpdate(result);
            }
            else
            {
                ActiveProfile savemodel = new ActiveProfile();
                savemodel.ProfileUserID = ProfileUserID;
                savemodel.LastActiveDate = DateTime.Now;
                savemodel.DeviceID = DeviceId;
                savemodel.DeviceType = DeviceType;
                savemodel.Version = Version;
                TAdd(savemodel);
            }
        }

        public void SetActiveInProfile(string ProfileUserID, string DeviceId, string DeviceType, string Version)
        {
            var result = TGetList(w => w.ProfileUserID == ProfileUserID).FirstOrDefault();
            if (result != null)
            {
                result.LastActiveDate = DateTime.Now.AddYears(-100);
                result.DeviceID = DeviceId;
                result.DeviceType = DeviceType;
                result.Version = Version;
                TUpdate(result);
            }
            else
            {
                ActiveProfile savemodel = new ActiveProfile();
                savemodel.ProfileUserID = ProfileUserID;
                savemodel.LastActiveDate = DateTime.Now.AddYears(-100);
                savemodel.DeviceID = DeviceId;
                savemodel.DeviceType = DeviceType;
                savemodel.Version = Version;
                TAdd(savemodel);
            }
        }
    
    }
}
