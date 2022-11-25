using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Quki.Entity.Base;
using Quki.Bll;
using Quki.Interface;
using Quki.Dal.Abstract;
using Microsoft.Extensions.DependencyInjection;

namespace Quki.Bll.Base
{
    public class BllBase<T, TDto> : IGenericService<T, TDto> where T : EntityBase where TDto : DtoBase
    {
        #region Variables
        //unitofwork
        private readonly IServiceProvider service;
        private readonly IGenericRepository<T> repository;
        private readonly IUnitOfWork unitOfWork;

        public BllBase(IServiceProvider service)
        {
            unitOfWork = service.GetService<IUnitOfWork>();
            this.repository = unitOfWork.GetRepository<T>();
            this.service = service;

        }

        public void TAdd(T entity)
        {
            repository.TAdd(entity);
        }

        public Task<T> TAddAsync(T entity)
        {
            return repository.TAddAsync(entity);
        }

        public void TDelete(T p)
        {
            repository.TDelete(p);
        }

        public Task<bool> TDeleteAsync(int id)
        {
            return repository.TDeleteAsync(id);
        }

        public Task<bool> TDeleteAsync(T entity)
        {
        return repository.TDeleteAsync(entity);
        }

        public T TgetItemByID(int id)
        {
        return repository.TgetItemByID(id);
        }

        public List<T> TGetList()
        {
            return repository.TGetList();
        }

        public List<T> TGetList(Expression<Func<T, bool>> expression)
        {
            return repository.TGetList(expression);
        }

        public IQueryable<T> TGetQueryable(Expression<Func<T, bool>> expression)
        {
            return repository.TGetQueryable(expression);
        }

        public void TUpdate(T entity)
        {
            repository.TUpdate(entity);
        }

        public Task<T> TUpdateAsync(T item)
        {
            return repository.TUpdateAsync(item);
        }
        public void TAddRange(List<T> p)
        {
            repository.TAddRange(p);
        }


        public void TUpdateRange(List<T> p)
        {
            repository.TUpdateRange(p);
        }
        #endregion
    }
}
