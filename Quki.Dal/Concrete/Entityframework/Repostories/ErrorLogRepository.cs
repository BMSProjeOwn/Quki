using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quki.Dal.Abstract;
using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Entity.Models;
using Quki.Entity.Parameters;
using Quki.Entity.ViewModel;

namespace Quki.Dal.Concrete.Entityframework.Repostories
{
    public class ErrorLogRepository : GenericRepository<ErrorLog>, IErrorLogRepository
    {
        public ErrorLogRepository(DbContext context) : base(context)
        {
            
        }
        //public void ErrorLogAdd(ErrorLogModel error)
        //{
        //    ErrorLog NewError = new ErrorLog();
        //    NewError.InnerException = error.InnerException;
        //    NewError.Message = error.Message;
        //    NewError.StackTrace = error.StackTrace;
        //    NewError.TerminalNo = LogTerminal.Web;
        //    NewError.TypeID = error.TypeID;
        //    NewError.CreateDate = DateTime.Now;
        //    TAdd(NewError);
        //}

        //public void ErrorLogAdd(string Message)
        //{
        //    ErrorLog NewError = new ErrorLog();
        //    NewError.InnerException = "";
        //    NewError.Message = Message;
        //    NewError.StackTrace = "";
        //    NewError.TerminalNo = LogTerminal.Web;
        //    NewError.TypeID = 0;
        //    NewError.CreateDate = DateTime.Now;
        //    TAdd(NewError);
        //}

    }
}
