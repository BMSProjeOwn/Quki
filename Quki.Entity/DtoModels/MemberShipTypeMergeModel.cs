using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Base;

namespace Quki.Entity.DtoModels
{
    public class MemberShipTypeMergeModel : DtoBase
    {
        public MemberShipTypeAddModel MemberShipTypeAddModel { get; set; }
       
        public List<MemberShipPropertiesGroupModel> MemberShipPropertiesGroupModel { get; set; }
        public List<MembershipTypePricePlaneModel> MembershipTypePricePlane { get; set; }

        public List<MemberShipTypeWithPropertiessAddModel> MemberShipTypeWithPropertiessAddModel { get; set; }
       // public List<MemberShipTypeWithPropertiessAddModel> MemberShipTypeWithPropertiessAddModelNon { get; set; }

        //public List<MemberShipTypeWithCountryModel> MemberShipTypeWithCountryModels { get; set; }

        public List<CountryModel> CountryModel { get; set; }

    }

    public class MemberShipPropertiesGroupModel
    {
        public int GroupID { get; set; }
        public string GroupName { get; set; }
        public List<MemberShipTypeWithPropertiessAddModel> MemberShipTypeWithPropertiessAddModel { get; set; }

        public List<CountryModel> CountryModel { get; set; }
    }
}
