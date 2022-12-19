using Microsoft.EntityFrameworkCore;
using Quki.Dal.Abstract;
using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quki.Dal.Concrete.Entityframework.Repostories
{
    public class slu_Rvc_RelationRepository:GenericRepository<slu_Rvc_Relation>,Islu_Rvc_RelationRepository
    {
        public slu_Rvc_RelationRepository(ProjeDBZuposDBContext context) : base(context)
        {
        }
    }
}
