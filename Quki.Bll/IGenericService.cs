using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Quki.Entity.IBase;

namespace Quki.Bll
{
    public interface IGenericManager<T, TDto> where T:IEntityBase where TDto : IDtoBase
    {
        List<TDto> TGetList();
        IQueryable<TDto> TGetList(Expression<Func<T, bool>> expression);
        void TAdd(TDto p);
        Task<TDto> TAddAsync(TDto item);
        void TDelete(TDto p);
        Task<bool> TDeleteAsync(int id);
        Task<bool> TDeleteAsync(TDto p);
        void TUpdate(TDto p);
        Task<TDto> TUpdateAsync(TDto item);
        TDto TgetItemByID(int key);
        public void TAddRange(List<T> p);
        public void TUpdateRange(List<T> p);
    }
}
