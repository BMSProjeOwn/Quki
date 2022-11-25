using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quki.Entity.DtoModels;
using Quki.Entity.DtoModels.ApiModels;
using Quki.Entity.Models;

namespace Quki.Interface
{
    public interface IAttributeStaticValueService : IGenericService<AttributeStaticValue, AttributeStaticValueModel>
    {
        public List<AttributeStaticValue> GetAttributeStaticValuesById(int id);

        public List<ProductAttributeModelApi> GetProductAttribute(int ProductID);

        public List<ProductAttribute> GetHomeProductAttribute(int ProductID);
    }
}
