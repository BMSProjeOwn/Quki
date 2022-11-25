using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quki.Dal.Abstract;
using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Entity.DtoModels.ApiModels;
using Quki.Entity.Models;

namespace Quki.Dal.Concrete.Entityframework.Repostories
{
    public class ProtoectInformationRepository : GenericRepository<ProtoectInformation>, IProtoectInformationRepository
    {
        public ProtoectInformationRepository(DbContext context) : base(context)
        {
            
        }
        public NotificationsTypeApi AccountSettingResponse(string customer_def_no)
        {
            NotificationsTypeApi res = new NotificationsTypeApi();
            res.NotificationsTypes = dbset.Where(w => w.IsActive == true && w.IsShowScreen == true && w.TypeGorupID == 2).Select(s => new NotificationsTypeItemsApi
            {
                id = s.ProtectionInformationSeqID,
                name = s.ProtectionInformationHeaderLine,
                remark = s.Remark,
                status = context.Set<UserProtoectInformation>()
                               .Where(wu => wu.ProtectionInformationSeqID == s.ProtectionInformationSeqID && wu.UserId == customer_def_no)
                               .Select(su => su.IsConfirmation).FirstOrDefault()
            }).ToList();
            return res;
        }
        public List<ProtoectInformation> GetProtoectInformationListwithLanguageId(int languageId)
        {
            List<ProtoectInformation> list = new List<ProtoectInformation>();
            try
            {
                list = context.Set<ProtoectInformation>().Where(x => x.LanguageID.Equals(languageId)).OrderBy(x=>x.ProtectInformationCode).ToList();
            }
            catch { }
            return list;
        }
    }
}
