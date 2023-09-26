using Microsoft.EntityFrameworkCore;
using Quki.Dal.Abstract;
using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quki.Dal.Concrete.Entityframework.Repostories
{
    public class CondimentMenuItemRelationRepository : GenericRepository<CondimentMenuItemRelation>, ICondimentMenuItemRelationRepository
    {
        public CondimentMenuItemRelationRepository(ProjeDBZuposDBContext context) : base(context)
        {
        }
    }
}
