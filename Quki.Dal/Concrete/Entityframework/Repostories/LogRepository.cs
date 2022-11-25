using System.Collections.Generic;
using System.Linq;
using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Entity.DtoModels.ApiModels;
using Quki.Entity.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Quki.Entity.DtoModels.LogModels;
using System;
using Microsoft.EntityFrameworkCore;
using Quki.Dal.Abstract;

namespace Quki.Dal.Concrete.Entityframework.Repostories
{
    public class LogRepository : GenericRepository<LogForTransaction>, ILogRepository
    {
        public LogRepository(DbContext context) : base(context)
        {
            context = new ProjeDBContext();
        }
        

        
    }
}
