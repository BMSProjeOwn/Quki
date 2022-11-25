using System.Collections.Generic;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;

namespace Quki.Interface
{
    public interface IEmailTemplateService : IGenericService<NotificationTemplatess, EmailTemplateAddModel>
    {

        public void AddEmailTemplate(EmailTemplateAddModel emailTemplateAddModel);
        public void TestEmailTemplate(EmailTemplateAddModel emailTemplateAddModel);
        public NotificationTemplatess FindTamplewithId(int TypeId);
        public List<NotificationTemplatess> GetTemplateList();
        public bool UpdateEmailTemplate(EmailTemplateAddModel model);
        public EmailTemplateAddModel getEmailTemplateByID(int id);
        public List<NotificationTemplatess> GetTemplateListByType(int TypeID);
        public bool DeleteEmailTemplate(int id);

    }
}
