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
    public class DepartmentsRepository : GenericRepository<TDepart>, IDepartmentsRepository
    {
        public DepartmentsRepository(DbContext context):base(context)
        {
            
        }
        //public bool DepartmentDeleteById(int id)
        //{
        //    bool result = false;

        //    var x = dbset.Where(x => x.DepartmanSeqID == id).FirstOrDefault();

        //    x.Status = false;

        //    TUpdate(x);
        //    result = true;
        //    return result;
        //}
    }
}
