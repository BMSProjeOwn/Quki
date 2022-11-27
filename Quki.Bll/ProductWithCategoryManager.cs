using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Linq.Expressions;
using Quki.Bll.Base;
using Quki.Dal.Abstract;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;
using Quki.Interface;

namespace Quki.Bll
{
    public class ProductWithCategoryManager : BllBase<ProductWithCategory, ProductWithCategoryModel>, IProductWithCategoryService
    {
        public readonly IProductWithCategoryRepository repo;
        public ProductWithCategoryManager(IServiceProvider service) : base(service)
        {
            repo = service.GetService<IProductWithCategoryRepository>();
        }
        public ProductWithCategory GetProductCategori(Expression<Func<ProductWithCategory, bool>> filter)
        {
            return repo.GetProductCategori(filter);
        }
        public ProductWithCategory GetProductCategori(int productSeqID, int categorySeqID)
        {
            return TGetList(p => p.CategorySeqID == categorySeqID && p.ProductSeqID == productSeqID).FirstOrDefault();

        }

    }
}
