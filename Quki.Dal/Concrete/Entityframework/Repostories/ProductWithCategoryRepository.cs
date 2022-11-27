using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Quki.Dal.Abstract;
using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Entity.Models;

namespace Quki.Dal.Concrete.Entityframework.Repostories
{
    public class ProductWithCategoryRepository : GenericRepository<ProductWithCategory>, IProductWithCategoryRepository
    {
        public ProductWithCategoryRepository(DbContext context) : base(context)
        {

        }
        public ProductWithCategory GetProductCategori(Expression<Func<ProductWithCategory, bool>> filter)
        {
            return context.Set<ProductWithCategory>().FirstOrDefault(filter);
        }
        public ProductWithCategory GetProductCategori(int productSeqID, int categorySeqID)
        {
            return dbset.Where(p => p.CategorySeqID == categorySeqID && p.ProductSeqID == productSeqID).FirstOrDefault();

        }
    }
}
