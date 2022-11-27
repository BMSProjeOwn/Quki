using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Entity.DtoModels.ApiModels;
using Quki.Entity.Models;

namespace Quki.Dal.Abstract
{
    public interface IProtoectInformationRepository
    {
        public NotificationsTypeApi AccountSettingResponse(string customer_def_no);
        public List<ProtoectInformation> GetProtoectInformationListwithLanguageId(int languageId);
       
    }
}
