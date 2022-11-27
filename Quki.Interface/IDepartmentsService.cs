using Quki.Entity.DtoModels;
using Quki.Entity.Models;

namespace Quki.Interface
{
    public interface IDepartmentsService : IGenericService<TDepart, TDepartModel>
    {

        public bool DepartmentDeleteById(int id);
    }
}
