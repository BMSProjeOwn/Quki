using Quki.Entity.DtoModels;
using Quki.Entity.Models;

namespace Quki.Interface
{
    public interface IMessagesService : IGenericService<Messages, MessagesModel>
    {

        public void CreateMessageApi();
        
    }
}
