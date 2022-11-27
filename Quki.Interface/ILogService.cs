using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Quki.Entity.DtoModels;
using Quki.Entity.DtoModels.ApiModels;
using Quki.Entity.DtoModels.LogModels;
using Quki.Entity.Models;

namespace Quki.Interface
{
    public interface ILogService : IGenericService<LogForTransaction, LogForTransactionModel>
    {
        public bool AddLog(LogApiModel logApiModel);

    }
}
