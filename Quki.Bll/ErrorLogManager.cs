using Microsoft.Extensions.DependencyInjection;
using System;
using Quki.Bll.Base;
using Quki.Dal.Abstract;
using Quki.Entity.Models;
using Quki.Entity.Parameters;
using Quki.Entity.ViewModel;
using Quki.Interface;

namespace Quki.Bll
{
    public class ErrorLogManager : BllBase<ErrorLog, ErrorLogModel>, IErrorLogService
    {
        public readonly IErrorLogRepository repo;
        public ErrorLogManager(IServiceProvider service) : base(service)
        {
            repo = service.GetService<IErrorLogRepository>();
        }

        public void ErrorLogAdd(ErrorLogModel error) {
            ErrorLog NewError = new ErrorLog();
            NewError.InnerException = error.InnerException;
            NewError.Message = error.Message;
            NewError.StackTrace = error.StackTrace;
            NewError.TerminalNo = LogTerminal.Web;
            NewError.TypeID = error.TypeID;
            NewError.CreateDate = DateTime.Now;
            TAdd(NewError);
           
        }
        public void ErrorLogAdd(string Message) {
            ErrorLog NewError = new ErrorLog();
            NewError.InnerException = "";
            NewError.Message = Message;
            NewError.StackTrace = "";
            NewError.TerminalNo = LogTerminal.Web;
            NewError.TypeID = 0;
            NewError.CreateDate = DateTime.Now;
            TAdd(NewError);
        }

    }
}
