using Microsoft.Extensions.DependencyInjection;
using System;
using Quki.Bll.Base;
using Quki.Dal.Abstract;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;
using Quki.Interface;

namespace Quki.Bll
{
    public class CustomerNotificationLogsManager : BllBase<CustomerNotificationLogs, CustomerNotificationLogsModel>, ICustomerNotificationLogsService
    {
        public readonly ICustomerNotificationLogsRepository repo;

        public CustomerNotificationLogsManager(IServiceProvider service) : base(service)
        {
            repo = service.GetService<ICustomerNotificationLogsRepository>();
        }
    }
}
