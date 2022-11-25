using Microsoft.Extensions.DependencyInjection;
using System;
using Quki.Bll.Base;
using Quki.Dal.Abstract;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;
using Quki.Interface;

namespace Quki.Bll
{
    public class MemberShipTypeWithCustomersPaymentChanelManager : BllBase<MemberShipTypeWithCustomersPaymentChanel, MemberShipTypeWithCustomersPaymentChanelModel>, IMemberShipTypeWithCustomersPaymentChanelService
    {
        public readonly IMemberShipTypeWithCustomersPaymentChanelRepository repo;
        public MemberShipTypeWithCustomersPaymentChanelManager(IServiceProvider service) : base(service)
        {
            repo = service.GetService<IMemberShipTypeWithCustomersPaymentChanelRepository>();
        }
    }
}
