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
    public class DepartmentsManager : BllBase<TDepart, TDepartModel>, IDepartmentsService
    {
        public readonly IDepartmentsRepository repo;

        public DepartmentsManager(IServiceProvider service) : base(service)
        {
            repo = service.GetService<IDepartmentsRepository>();
        }
        public bool DepartmentDeleteById(int id)
        {
            bool result = false;

            var x = TGetList(x => x.DepartmanSeqID == id).FirstOrDefault();

            x.Status = false;

            TUpdate(x);
            result = true;
            return result;
        }
    }
}
