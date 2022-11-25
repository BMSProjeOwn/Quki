using System.Collections.Generic;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;




namespace Quki.Interface
{
    public interface IMemberShipTypeWithCustomersProfilesService : IGenericService<MemberShipTypeWithCustomersProfiles, MemberShipTypeWithCustomersProfilesModel>
    {

        public List<GetUserProfiles> GelMemberShipTypeWithCustomersProfilesByUserID(string UserID, string DeviceID, string DeviceType, string Version);
        public GetUserProfiles GelMemberShipTypeWithCustomersProfilesByProfileUserID(string ProfileUserID, string DeviceID, string DeviceType, string Version); 
        public bool UpdateMemberShipTypeWithCustomersProfilesByProfileUserID(string ProfileUserID, string Name, string IconPhat);
        public string AddMemberShipTypeWithCustomersProfilesByProfileUserID(string UserID, string Name, string IconPhat);
        public bool DeleteMemberShipTypeWithCustomersProfilesByProfileUserID(string ProfileUserID);
        public bool CanAddNewProfile(string UserID);
       
    }
}
