using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;

namespace Quki.Dal.Abstract
{
    public interface IProductWithProducersRepository : IGenericRepository<ProductWithProducers>
    {
        //public void AddProductWithProducers(ProductWithProducersModel model);
        //public List<ProductWithProducers> GetProductProducersByProductID(int productID);
        //public void Delete(int id);
       
    }
}
