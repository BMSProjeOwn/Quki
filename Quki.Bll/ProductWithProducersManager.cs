using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using Quki.Bll.Base;
using Quki.Dal.Abstract;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;
using Quki.Interface;

namespace Quki.Bll
{
    public class ProductWithProducersManager : BllBase<ProductWithProducers,ProductWithProducersModel >, IProductWithProducersService
    {
        public readonly IProductWithProducersRepository repo;
        public ProductWithProducersManager(IServiceProvider service) : base(service)
        {
            repo = service.GetService<IProductWithProducersRepository>();
        }
        public void AddProductWithProducers(ProductWithProducersModel model)
        {
            ProductWithProducers productWithProducers = new ProductWithProducers();
            productWithProducers.ProducerSeqID = model.ProducerSeqID;
            productWithProducers.Description = model.Description;
            productWithProducers.ProductSeqID = model.ProductSeqID;
            productWithProducers.ProducerTypeSeqID = model.ProducerTypeSeqID;
            productWithProducers.Name = TGetList(I => I.ProducerSeqID == model.ProducerSeqID).FirstOrDefault().Name;
            productWithProducers.CreatedOn = DateTime.Now;
            productWithProducers.UpdatedOn = DateTime.Now;
            TAdd(productWithProducers);
        }

        public List<ProductWithProducers> GetProductProducersByProductID(int productID)// ürüne ait kategorileri getiriyor.
        {
            return TGetList(I => I.ProductSeqID == productID).ToList();
        }


        public void Delete(int id)
        {
            var a = TGetList(x => x.ProductWithProducerSeqID == id).FirstOrDefault();

            TDelete(a);

        }

    }
}
