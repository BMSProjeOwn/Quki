using System.Collections.Generic;
using Quki.Entity.DtoModels;
using Quki.Entity.DtoModels.ApiModels;
using Quki.Entity.Models;

namespace Quki.Interface
{
    public interface IProtoectInformationService : IGenericService<ProtoectInformation, ProtoectInformationModel>
    {
        public NotificationsTypeApi AccountSettingResponse(string customer_def_no,int languageId);
        public List<ProtoectInformation> GetProtoectInformationListwithLanguageId(int languageId);
       
    }
}
