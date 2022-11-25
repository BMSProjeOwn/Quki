using System;
using System.Collections.Generic;
using System.Linq;
using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;
namespace Quki.Dal.Abstract
{
    public interface IMembershipPropertiesRepository : IGenericRepository<MembershipProperties>
    {
        public List<MembershipProperties> GetProperties(int memberShipTypeId);
        public List<MemberShipTypeWithPropertiessAddModel> GetPropertiesAllWithValueTypes();

    }
}
