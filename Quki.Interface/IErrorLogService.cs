using Quki.Entity.Models;
using Quki.Entity.ViewModel;

namespace Quki.Interface
{
    public interface IErrorLogService : IGenericService<ErrorLog, ErrorLogModel>
    {

        public void ErrorLogAdd(ErrorLogModel error);
        public void ErrorLogAdd(string Message);

    }
}
