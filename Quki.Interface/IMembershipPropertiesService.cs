using System.Collections.Generic;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;
namespace Quki.Interface
{
    public interface IMembershipPropertiesService : IGenericService<MembershipProperties, MemberShipTypeWithPropertiessAddModel>
    {
        public List<MembershipProperties> GetPropertiesAll();
        public List<MemberShipTypeWithPropertiessAddModel> GetPropertiesAllWithValueTypes();
        public List<MembershipProperties> GetProperties(int memberShipTypeId);
        public bool AddMemberShipTypeProp(MemberShipTypePropertiesAddModel model);
        public void UpdateMemberShipTypeProp(MembershipProperties membershipProperties);
    }
}
