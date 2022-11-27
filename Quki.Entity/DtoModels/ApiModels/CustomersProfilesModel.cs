using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Base;
using Quki.Entity.Models;

namespace Quki.Entity.DtoModels.ApiModels
{
    public class CustomersProfilesModelList : Response
    {
        public int createProfileRightCount { get; set; }
        public List<GetUserProfiles> profileList { get; set; }
    }

    public class CustomersProfilesModelResponse : Response
    {
        public GetUserProfiles profile { get; set; }
    }
    public class CustomersProfilesRequest:DtoBase
    {
        public string profileUserID { get; set; }
        public string userID { get; set; }
        public string name { get; set; }
        public string iconPhat { get; set; }
        public int languageId { get; set; }

    }

    public class ProfileIconsModel : Response
    {
        public List<IconsModel> iconsList { get; set; }
    }
    public class IconsModel : DtoBase
    {
        public int iconId { get; set; }
        public string iconName { get; set; }
        public string iconPath { get; set; }
    }
}
