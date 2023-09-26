using Quki.Dal.Abstract;
using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Entity.Models;

namespace Quki.Dal.Concrete.Entityframework.Repostories
{
    public class CondimentRelationRepository : GenericRepository<CondimentRelation>, ICondimentRelationRepository
    {
        public CondimentRelationRepository(ProjeDBZuposDBContext context) : base(context)
        {
        }
    }
}
