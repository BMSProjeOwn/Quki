using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Quki.Dal.Abstract;
using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Entity.Base;

namespace Quki.Dal.Concrete.Entityframework.Repostories
{
    public class GenericRepository<T> : IGenericRepository<T> where T:EntityBase
    {
        #region Variables
        protected DbContext context;
        protected DbSet<T> dbset;
        #endregion

        public GenericRepository(DbContext context)
        {
            this.context = context;
            this.dbset = this.context.Set<T>();

            this.context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public List<T> TGetList()
        {
            return dbset.ToList();
        }
        public void TAdd(T p)
        {
            context.Entry(p).State = EntityState.Added;
            dbset.Add(p);
            context.SaveChanges();
        }
        public void TAddRange(List<T> p)
        {
            //context.Entry(p).State = EntityState.Added;
            dbset.AddRange(p);
            context.SaveChanges();
        }


        public void TDelete(T p)
        {
            if(context.Entry(p).State == EntityState.Detached)
            {
                context.Attach(p);
            }
            context.Entry(p).State = EntityState.Deleted;
            dbset.Remove(p);
            context.SaveChanges();
        }
        public void TUpdate(T p)
        {
            //if (context.Entry(p).State == EntityState.Modified)
            //{
            //    context.Attach(p);
            //}
            dbset.Update(p);
            context.SaveChanges();
        }
        public void TUpdateRange(List<T> p)
        {
            //if (context.Entry(p).State == EntityState.Modified)
            //{
            //    context.Attach(p);
            //}
            dbset.UpdateRange(p);
            context.SaveChanges();
        }

        public List<T> TGetList(Expression<Func<T, bool>> expression)
        {
            return dbset.Where(expression).ToList();
        }
        public T TgetItemByID(int key)
        {
            return dbset.Find(key);
        }

        public IQueryable<T> TGetQueryable(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<T> TAddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> TDeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> TDeleteAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> TUpdateAsync(T item)
        {
            throw new NotImplementedException();
        }

        public void SaveChange()
        {
            context.SaveChanges();
        }


        //public List[T] Tliddst(string key)
        //{
        //   return context.Set<T>().Include(key).ToList();
        //}
    }
}
