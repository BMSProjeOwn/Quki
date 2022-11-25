using System;
using System.Linq.Expressions;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;

namespace Quki.Interface
{
    public interface IProductWithCategoryService : IGenericService<ProductWithCategory, ProductWithCategoryModel>
    {
        public ProductWithCategory GetProductCategori(Expression<Func<ProductWithCategory, bool>> filter);
        public ProductWithCategory GetProductCategori(int productSeqID, int categorySeqID);
       
    }
}
