using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quki.Dal.Abstract;
using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Entity.Models;

namespace Quki.Dal.Concrete.Entityframework.Repostories
{
    public class MemberShipTypeWithCountryRepository : GenericRepository<MemberShipTypeWithCountry>, IMemberShipTypeWithCountryRepository
    {
        public MemberShipTypeWithCountryRepository(DbContext context):base(context)
        {
            
        }
    }
}
