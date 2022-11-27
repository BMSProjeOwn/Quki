using Quki.Entity.DtoModels;
using Quki.Entity.Models;

namespace Quki.Interface
{
    public interface IMemberShipPaymentPlanWithPaymentChannelService : IGenericService<MemberShipPaymentPlanWithPaymentChannel, MemberShipPaymentPlanWithPaymentChannelModel>
    {
        public MemberShipPaymentPlanWithPaymentChannel GetLast();
    }
}