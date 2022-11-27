using System;
using System.Linq.Expressions;
using Quki.Entity.Models;

namespace Quki.Dal.Abstract
{
    public interface IProductWithCategoryRepository : IGenericRepository<ProductWithCategory>
    {
        public ProductWithCategory GetProductCategori(Expression<Func<ProductWithCategory, bool>> filter);
        public ProductWithCategory GetProductCategori(int productSeqID, int categorySeqID);
       
    }
}
