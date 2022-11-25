using System.Collections.Generic;
using Quki.Entity.DtoModels;
using Quki.Entity.DtoModels.ApiModels;
using Quki.Entity.Models;

namespace Quki.Dal.Abstract
{

    public interface IAttributeStaticValueRepository : IGenericRepository<AttributeStaticValue>
    {

        //public List<AttributeStaticValue> GetAttributeStaticValuesById(int id);

        public List<ProductAttributeModelApi> GetProductAttribute(int ProductID);

        public List<ProductAttribute> GetHomeProductAttribute(int ProductID);
        
        

    }
}
