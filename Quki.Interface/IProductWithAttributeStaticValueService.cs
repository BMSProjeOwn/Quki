using Quki.Entity.DtoModels;
using Quki.Entity.Models;

namespace Quki.Interface
{
    public interface IProductWithAttributeStaticValueService : IGenericService<ProductWithAttributeStaticValue, ProductWithAttributeStaticValueModel>
    {
        public ProductWithAttributeStaticValue GetProductAttiributeStaticValue(int productSeqID, int attributeStaticValueSeqID);       
    }
}
