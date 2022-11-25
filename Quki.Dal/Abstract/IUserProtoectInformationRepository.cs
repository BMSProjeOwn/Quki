using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Entity.Models;
using Quki.Entity.ViewModel;

namespace Quki.Dal.Abstract
{
    public interface IUserProtoectInformationRepository : IGenericRepository<UserProtoectInformation>
    {
        public void AddUserProtoectInformation(List<ProtoectInformationGetModel> list, string userID);
        public bool SettingUpdateApi(string customer_def_no, int id, bool status);
    }
}
