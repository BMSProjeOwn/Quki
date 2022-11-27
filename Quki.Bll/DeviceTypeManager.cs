using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using Quki.Bll.Base;
using Quki.Dal.Abstract;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;
using Quki.Interface;

namespace Quki.Bll
{
    public class DeviceTypeManager : BllBase<DeviceType, DeviceTypeModel>, IDeviceTypeService
    {
        public readonly IDeviceTypeRepository repo;
        public DeviceTypeManager(IServiceProvider service) : base(service)
        {
            repo = service.GetService<IDeviceTypeRepository>();
        }
        

    }
}
