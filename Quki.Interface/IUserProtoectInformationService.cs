using System.Collections.Generic;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;
using Quki.Entity.ViewModel;

namespace Quki.Interface
{
    public interface IUserProtoectInformationService : IGenericService<UserProtoectInformation, UserProtoectInformationModel>
    {
        public void AddUserProtoectInformation(List<ProtoectInformationGetModel> list, string userID);
        public bool SettingUpdateApi(string customer_def_no, int id, bool status);
    }
}
