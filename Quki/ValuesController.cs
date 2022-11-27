using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Quki.Dal.Concrete.Entityframework.Repostories;
using Quki.Entity.Models;
using Quki.Interface;

namespace Quki
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ICustomerService customerService;
        public ValuesController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }
        public List<Customer> CustomerGetAllList()
        {
            return customerService.CustomerGetAll();
        }

    }
}
