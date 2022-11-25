using Microsoft.Extensions.DependencyInjection;
using System;
using Quki.Bll.Base;
using Quki.Dal.Abstract;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;
using Quki.Interface;

namespace Quki.Bll
{
    public class MemberShipPaymentPlanWithPaymentChannelManager : BllBase<MemberShipPaymentPlanWithPaymentChannel, MemberShipPaymentPlanWithPaymentChannelModel>, IMemberShipPaymentPlanWithPaymentChannelService
    {
        public readonly IMemberShipPaymentPlanWithPaymentChannelRepository repo;
        public MemberShipPaymentPlanWithPaymentChannelManager(IServiceProvider service) : base(service)
        {
            repo = service.GetService<IMemberShipPaymentPlanWithPaymentChannelRepository>();
        }
        public MemberShipPaymentPlanWithPaymentChannel GetLast() { return repo.GetLast(); }
    }
}