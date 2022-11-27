using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quki.Bll.Base;
using Quki.Dal.Abstract;
using Quki.Entity.DtoModels;
using Quki.Entity.DtoModels.ApiModels;
using Quki.Entity.Models;
using Quki.Bll;
using Quki.Interface;

namespace Quki.Bll
{
    public class AttributeStaticValueManager : BllBase<AttributeStaticValue, AttributeStaticValueModel>, IAttributeStaticValueService
    {
        public readonly IAttributeStaticValueRepository attributeStaticValueRepository;
        public readonly IProductWithAttributeStaticValueRepository productWithAttributeStaticValueRepository;

        public AttributeStaticValueManager(IServiceProvider service) :base(service)
        {
            attributeStaticValueRepository = service.GetService<IAttributeStaticValueRepository>();
            productWithAttributeStaticValueRepository = service.GetService<IProductWithAttributeStaticValueRepository>();
        }
        public List<AttributeStaticValue> GetAttributeStaticValuesById(int id)
        {
            List<AttributeStaticValue> liste = TGetList(x => x.AttributeStaticSeqID == id).ToList();
            return liste;
        }

        public List<ProductAttributeModelApi> GetProductAttribute(int ProductID)
        {
            List<ProductAttributeModelApi> list = new List<ProductAttributeModelApi>();
            list = productWithAttributeStaticValueRepository.TGetList()
               .Join(TGetList().ToList(), A => A.AttributeStaticValueSeqID, PA => PA.AttributeStaticValueSeqID, (productWithAttributeStaticValues, attributeStaticValue) => new
               {
                   AttributeStaticValue = attributeStaticValue,
                   ProductWithAttributeStaticValues = productWithAttributeStaticValues
               })
               .Where(I => I.ProductWithAttributeStaticValues.ProductSeqID == ProductID)
               .Select(I => new ProductAttributeModelApi
               {
                   Value = I.AttributeStaticValue.IsDynamic == true ? I.ProductWithAttributeStaticValues.Value : I.AttributeStaticValue.Remark,
                   ValueName = I.AttributeStaticValue.ValueName
               }).ToList();
            return list;
        }

        public List<ProductAttribute> GetHomeProductAttribute(int ProductID)
        {
            List<ProductAttribute> list = new List<ProductAttribute>();
            list = productWithAttributeStaticValueRepository.TGetList()
               .Join(TGetList().ToList(), A => A.AttributeStaticValueSeqID, PA => PA.AttributeStaticValueSeqID,
               (productWithAttributeStaticValues, attributeStaticValue) => new
               {
                   AttributeStaticValue = attributeStaticValue,
                   ProductWithAttributeStaticValues = productWithAttributeStaticValues
               })
               .Where(I => I.ProductWithAttributeStaticValues.ProductSeqID == ProductID)
               .Select(I => new ProductAttribute
               {
                   value = I.AttributeStaticValue.IsDynamic == true ? I.ProductWithAttributeStaticValues.Value : I.AttributeStaticValue.Remark,
                   name = I.AttributeStaticValue.ValueName
               }).ToList();
            return list;
        }

    }
}
