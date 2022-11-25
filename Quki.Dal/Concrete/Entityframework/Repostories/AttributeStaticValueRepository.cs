using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quki.Dal.Abstract;
using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Entity.DtoModels;
using Quki.Entity.DtoModels.ApiModels;
using Quki.Entity.Models;

namespace Quki.Dal.Concrete.Entityframework.Repostories
{

    public class AttributeStaticValueRepository : GenericRepository<AttributeStaticValue>, IAttributeStaticValueRepository
    {
        public AttributeStaticValueRepository(DbContext context):base(context)
        {
           
        }
        //public List<AttributeStaticValue> GetAttributeStaticValuesById(int id)
        //{
        //    List<AttributeStaticValue> liste   = context.Set<AttributeStaticValue>().Where(x=>x.AttributeStaticSeqID== id).ToList();
        //    return liste;
        //}

        public List<ProductAttributeModelApi> GetProductAttribute(int ProductID)
        {
            List<ProductAttributeModelApi> list = new List<ProductAttributeModelApi>();
            list = context.Set<ProductWithAttributeStaticValue>()
               .Join(context.Set<AttributeStaticValue>(), A => A.AttributeStaticValueSeqID, PA => PA.AttributeStaticValueSeqID, (productWithAttributeStaticValues, attributeStaticValue) => new
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
            list = context.Set<ProductWithAttributeStaticValue>()
               .Join(context.Set<AttributeStaticValue>(), A => A.AttributeStaticValueSeqID, PA => PA.AttributeStaticValueSeqID,
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
