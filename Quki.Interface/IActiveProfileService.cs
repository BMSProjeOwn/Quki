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
    public interface IActiveProfileService : IGenericService<ActiveProfile, ActiveProfileModel>
    {
        public void SetActiveProfile(string ProfileUserID, string DeviceId, string DeviceType, string Version);

        public void SetActiveInProfile(string ProfileUserID, string DeviceId, string DeviceType, string Version);
        

    }
}
