using Microsoft.EntityFrameworkCore;
using Quki.Dal.Abstract;
using Quki.Entity.Models;

namespace Quki.Dal.Concrete.Entityframework.Repostories
{
    public class ProducerTypeRepository : GenericRepository<ProducerType>, IProducerTypeRepository
    {

        public ProducerTypeRepository(DbContext context) : base(context)
        {
            
        }

        
    }
}
