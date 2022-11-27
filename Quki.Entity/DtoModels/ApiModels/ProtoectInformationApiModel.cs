using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Base;

namespace Quki.Entity.DtoModels.ApiModels
{
    public class ProtoectInformationApiModel:DtoBase
    {
    }

    public class NotificationsTypeApi : Response
    {
        public List<NotificationsTypeItemsApi> NotificationsTypes { get; set; }
    }
    public class NotificationsTypeItemsApi
    {
        public int id { get; set; }
        public string name { get; set; }
        public string remark { get; set; }
        public bool status { get; set; }
    }
}
