using Microsoft.Extensions.DependencyInjection;
using System;
using Quki.Bll.Base;
using Quki.Dal.Abstract;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;
using Quki.Interface;

namespace Quki.Bll
{
    public class CustomerIdentitysManager : BllBase<Customer, CustomersAddModel>, ICustomerIdentitysService
    {
        public readonly ICustomerIdentitysRepository repo;

        public CustomerIdentitysManager(IServiceProvider service) : base(service)
        {
            repo = service.GetService<ICustomerIdentitysRepository>();
        }
    }
}
