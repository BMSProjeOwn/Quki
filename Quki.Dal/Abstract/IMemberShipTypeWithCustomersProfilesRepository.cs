using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Entity.Models;
using Quki.Entity.Parameters;




namespace Quki.Dal.Abstract
{
    public interface IMemberShipTypeWithCustomersProfilesRepository : IGenericRepository<MemberShipTypeWithCustomersProfiles>
    {

        public List<GetUserProfiles> GelMemberShipTypeWithCustomersProfilesByUserID(string UserID, string DeviceID, string DeviceType, string Version);
        public GetUserProfiles GelMemberShipTypeWithCustomersProfilesByProfileUserID(string ProfileUserID, string DeviceID, string DeviceType, string Version);
        //public bool UpdateMemberShipTypeWithCustomersProfilesByProfileUserID(string ProfileUserID, string Name, string IconPhat);
        //public string AddMemberShipTypeWithCustomersProfilesByProfileUserID(string UserID, string Name, string IconPhat);
        //public bool DeleteMemberShipTypeWithCustomersProfilesByProfileUserID(string ProfileUserID);
        //public bool CanAddNewProfile(string UserID);

    }
}
