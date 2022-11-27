using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quki.Bll.Base;
using Quki.Dal.Abstract;
using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;
using Quki.Interface;
using Microsoft.Extensions.DependencyInjection;
namespace Quki.Bll
{
    public class MemberShipTypesWithPaymentChanelsManager : BllBase<MemberShipTypesWithPaymentChanel, MemberShipTypesWithPaymentChanelModel>, IMemberShipTypesWithPaymentChanelsService
    {
        public readonly IMemberShipTypesWithPaymentChanelsRepository repo;
        public MemberShipTypesWithPaymentChanelsManager(IServiceProvider service) : base(service)
        {
            repo = service.GetService<IMemberShipTypesWithPaymentChanelsRepository>();

        }

    }
}
