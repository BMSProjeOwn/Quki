using Microsoft.Extensions.DependencyInjection;
using System;
using Quki.Bll.Base;
using Quki.Dal.Abstract;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;
using Quki.Interface;

namespace Quki.Bll
{
    public class MessagesManager : BllBase<Messages, MessagesModel>, IMessagesService
    {
        public readonly IMessagesRepository repo;
        public MessagesManager(IServiceProvider service) : base(service)
        {
            repo = service.GetService<IMessagesRepository>();
        }
        public void CreateMessageApi() { repo.CreateMessageApi(); }

    }
}
