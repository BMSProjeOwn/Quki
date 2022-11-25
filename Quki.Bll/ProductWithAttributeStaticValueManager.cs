using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using Quki.Bll.Base;
using Quki.Dal.Abstract;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;
using Quki.Interface;

namespace Quki.Bll
{
    public class ProductWithAttributeStaticValueManager : BllBase<ProductWithAttributeStaticValue, ProductWithAttributeStaticValueModel>, IProductWithAttributeStaticValueService
    {
        public readonly IProductWithAttributeStaticValueRepository repo;
        public ProductWithAttributeStaticValueManager(IServiceProvider service) : base(service)
        {
            repo = service.GetService<IProductWithAttributeStaticValueRepository>();
        }

        public ProductWithAttributeStaticValue GetProductAttiributeStaticValue(int productSeqID, int attributeStaticValueSeqID)
        {

            return TGetList(p => p.AttributeStaticValueSeqID == attributeStaticValueSeqID && p.ProductSeqID == productSeqID).FirstOrDefault();
        }
    }
}
