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
    public class ProtoectInformationManager : BllBase<ProtoectInformation, ProtoectInformationModel>, IProtoectInformationService
    {
        public readonly IProtoectInformationRepository repo;
        public readonly IUserProtoectInformationRepository userProtoectInformationRepository;
        public ProtoectInformationManager(IServiceProvider service) : base(service)
        {
            repo = service.GetService<IProtoectInformationRepository>();
            userProtoectInformationRepository = service.GetService<IUserProtoectInformationRepository>();
        }
        public NotificationsTypeApi AccountSettingResponse(string customer_def_no,int languageId)
        {
            NotificationsTypeApi res = new NotificationsTypeApi();
            res.NotificationsTypes = TGetList(w => w.IsActive == true && w.IsShowScreen == true && w.TypeGorupID == 2 && w.LanguageID==languageId).Select(s => new NotificationsTypeItemsApi
            {
                id = s.ProtectionInformationSeqID,
                name = s.ProtectionInformationHeaderLine,
                remark = s.Remark,
                status = userProtoectInformationRepository.TGetList(wu => wu.ProtectionInformationSeqID == s.ProtectionInformationSeqID && wu.UserId == customer_def_no)
                               .Select(su => su.IsConfirmation).FirstOrDefault()
            }).ToList();
            return res;
        }
        public List<ProtoectInformation> GetProtoectInformationListwithLanguageId(int languageId)
        {
            List<ProtoectInformation> list = new List<ProtoectInformation>();
            try
            {
                list = TGetList(x => x.LanguageID.Equals(languageId)).ToList();
            }
            catch { }
            return list;
        }

    }
}
