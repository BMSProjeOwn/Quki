using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using Quki.Bll.Base;
using Quki.Dal.Abstract;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;
using Quki.Interface;

namespace Quki.Bll
{
    public class MailManager : BllBase<NotificationTemplatess, EmailTemplateAddModel>, IMailService
    {
        public readonly IMailRepository repo;
        public MailManager(IServiceProvider service) : base(service)
        {
            repo = service.GetService<IMailRepository>();
        }



    }
}
