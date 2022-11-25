using Microsoft.EntityFrameworkCore;
using System.Linq;
using Quki.Dal.Abstract;
using Quki.Entity.Models;

namespace Quki.Dal.Concrete.Entityframework.Repostories
{
    public class ProductWithAttributeStaticValueRepository : GenericRepository<ProductWithAttributeStaticValue>, IProductWithAttributeStaticValueRepository
    {
        public ProductWithAttributeStaticValueRepository(DbContext context) : base(context)
        {
            
        }
        public ProductWithAttributeStaticValue GetProductAttiributeStaticValue(int productSeqID, int attributeStaticValueSeqID)
        {

            return dbset.Where(p => p.AttributeStaticValueSeqID == attributeStaticValueSeqID && p.ProductSeqID == productSeqID).FirstOrDefault();
        }
    }
}
