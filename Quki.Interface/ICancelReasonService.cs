using System.Collections.Generic;
using Quki.Entity.DtoModels;
using Quki.Entity.DtoModels.ApiModels;
using Quki.Entity.Models;

namespace Quki.Interface
{
    public interface ICancelReasonService : IGenericService<CancelReason, CancelReasonModel>
    {

        public List<CancelReason> GetAllActiveCanselReason(int languageId);
        public List<CancelReasonApiModel> GetAllActiveCanselReasonApi(int languageId);

        
    }
}
