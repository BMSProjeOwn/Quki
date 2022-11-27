using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Quki.Entity.IBase;

namespace Quki.Dal.Abstract
{
    public interface IGenericRepository<T> where T:IEntityBase
    {
        List<T> TGetList();
        IQueryable<T> TGetQueryable(Expression<Func<T, bool>> expression);
        List<T> TGetList(Expression<Func<T, bool>> expression);
        void TAdd(T entity);
        Task<T> TAddAsync(T entity);
        void TDelete(T p);
        Task<bool> TDeleteAsync(int id);
        Task<bool> TDeleteAsync(T entity);
        void TUpdate(T entity);
        Task<T> TUpdateAsync(T item);
        T TgetItemByID(int id);
        public void TAddRange(List<T> p);


        public void TUpdateRange(List<T> p);
        void SaveChange();
    }
}
