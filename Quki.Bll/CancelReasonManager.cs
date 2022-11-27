using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using Quki.Bll.Base;
using Quki.Dal.Abstract;
using Quki.Entity.DtoModels;
using Quki.Entity.DtoModels.ApiModels;
using Quki.Entity.Models;
using Quki.Interface;

namespace Quki.Bll
{
    public class CancelReasonManager : BllBase<CancelReason, CancelReasonModel>, ICancelReasonService
    {

        public readonly ICancelReasonRepository repo;

        public CancelReasonManager(IServiceProvider service) : base(service)
        {
            repo = service.GetService<ICancelReasonRepository>();
        }
        public List<CancelReason> GetAllActiveCanselReason(int languageID)
        {
            var list = TGetList(x => x.IsActive == true && x.LanguageID==languageID).ToList();
            return list;
        }
        public List<CancelReasonApiModel> GetAllActiveCanselReasonApi(int languageId)
        {
            List<CancelReasonApiModel> cancelReasonList = new List<CancelReasonApiModel>();
            CancelReasonApiModel cancelReason;
            var list = TGetList(x => x.IsActive == true && x.LanguageID == languageId).ToList();
            foreach (var item in list)
            {
                cancelReason = new CancelReasonApiModel();
                cancelReason.CancelReasonSeqID = item.CancelReasonSeqID;
                cancelReason.Remark = item.Remark;
                cancelReasonList.Add(cancelReason);
            }
            return cancelReasonList;
        }



    }
}
