using System.Collections.Generic;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;

namespace Quki.Interface
{
    public interface IProductWithProducersService : IGenericService<ProductWithProducers,ProductWithProducersModel >
    {
        public void AddProductWithProducers(ProductWithProducersModel model);
        public List<ProductWithProducers> GetProductProducersByProductID(int productID);
        public void Delete(int id);
       
    }
}
