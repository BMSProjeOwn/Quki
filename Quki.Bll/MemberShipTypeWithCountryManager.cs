using System;
using Quki.Bll.Base;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;
using Quki.Interface;

namespace Quki.Bll
{
    public class MemberShipTypeWithCountryManager : BllBase<MemberShipTypeWithCountry, MemberShipTypeWithCountryModel>, IMemberShipTypeWithCountryService
    {
        public MemberShipTypeWithCountryManager(IServiceProvider service) : base(service)
        {
        }
    }
}
