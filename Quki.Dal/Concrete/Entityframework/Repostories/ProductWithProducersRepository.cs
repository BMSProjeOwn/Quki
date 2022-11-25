using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quki.Dal.Abstract;
using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;

namespace Quki.Dal.Concrete.Entityframework.Repostories
{
    public class ProductWithProducersRepository : GenericRepository<ProductWithProducers>, IProductWithProducersRepository
    {
        public ProductWithProducersRepository(DbContext context) : base(context)
        {
            
        }
        //public void AddProductWithProducers(ProductWithProducersModel model)
        //{
        //    ProductWithProducers productWithProducers = new ProductWithProducers();
        //    productWithProducers.ProducerSeqID = model.ProducerSeqID;
        //    productWithProducers.Description = model.Description;
        //    productWithProducers.ProductSeqID = model.ProductSeqID;
        //    productWithProducers.ProducerTypeSeqID = model.ProducerTypeSeqID;
        //    productWithProducers.Name = dbset.Where(I=>I.ProducerSeqID== model.ProducerSeqID).FirstOrDefault().Name;
        //    productWithProducers.CreatedOn = DateTime.Now;
        //    productWithProducers.UpdatedOn = DateTime.Now;
        //    TAdd(productWithProducers);
        //}

        //public List<ProductWithProducers> GetProductProducersByProductID(int productID)// ürüne ait kategorileri getiriyor.
        //{
        //    return dbset.Where(I => I.ProductSeqID == productID).ToList();
        //}


        //public void Delete(int id)
        //{
        //    var a = dbset.Where(x => x.ProductWithProducerSeqID == id).FirstOrDefault();

        //    TDelete(a);

        //}
    }
}
