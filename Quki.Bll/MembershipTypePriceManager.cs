using Microsoft.Extensions.DependencyInjection;
using System;
using Quki.Bll.Base;
using Quki.Dal.Abstract;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;

namespace Quki.Bll
{
    public class MembershipTypePriceManager : BllBase<MediaType, MediaTypeModel>, IMembershipTypePriceRepository
    {
        public readonly IMembershipTypePriceRepository repo;
        public MembershipTypePriceManager(IServiceProvider service) : base(service)
        {
            repo = service.GetService<IMembershipTypePriceRepository>();
        }
    }
}
