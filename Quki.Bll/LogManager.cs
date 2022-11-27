using System.Collections.Generic;
using System.Linq;
using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Entity.DtoModels.ApiModels;
using Quki.Entity.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Quki.Entity.DtoModels.LogModels;
using System;
using Quki.Bll.Base;
using Quki.Dal.Abstract;
using Microsoft.Extensions.DependencyInjection;
using Quki.Interface;

namespace Quki.Bll
{
    public class LogManager : BllBase<LogForTransaction, LogForTransactionModel>,ILogService
    {
        public readonly ILogRepository repo;
        public LogManager(IServiceProvider service) : base(service)
        {
            repo = service.GetService<ILogRepository>();
        }
        public bool AddLog(LogApiModel logApiModel)
        {
         
            List<LogForTransaction> logForTransactionList = new List<LogForTransaction>();
            foreach (var logItem in logApiModel.logList)
            {
                LogForTransaction logForTransaction = new LogForTransaction();
                logForTransaction.ClientLogKeyId = logItem.keyId;
                if (logItem.logLevel== "High")
                {
                    logForTransaction.LogLevel = 1;
                }
                if (logItem.logLevel== "Meddium")
                {
                    logForTransaction.LogLevel = 2;
                }
                if (logItem.logLevel== "Low")
                {
                    logForTransaction.LogLevel = 3;
                }
                if (logItem.logType == "ERROR")
                {
                    logForTransaction.LogTypeID = 1;
                }
                if (logItem.logType == "INFO")
                {
                    logForTransaction.LogTypeID = 2;
                }
                if (logItem.logType == "WARNING")
                {
                    logForTransaction.LogTypeID = 3;
                }
                logForTransaction.LogTypeGroupID = 1;
                logForTransaction.ClientLanguageID = logApiModel.languageId;
                logForTransaction.CounrtyID = logApiModel.counrtyId;
                logForTransaction.VersionForSDK = logApiModel.versionSdkInt;
                logForTransaction.VersionApp = logApiModel.appVersion;
                logForTransaction.OperationSystem = logApiModel.type;
                logForTransaction.DeviceInformation = logApiModel.model;
                logForTransaction.DeviceModelID = logApiModel.deviceId;
                logForTransaction.IsFiscalDevice = logApiModel.isPhysicalDevice;
                logForTransaction.ClassName = logItem.className;
                logForTransaction.MethodName = logItem.methodName;
                logForTransaction.Message = logItem.text;
                logForTransaction.Exception = logItem.errorString;
                logForTransaction.TimeZone = logItem.timeZone;
                logForTransaction.CreatedTimeOnClient = logItem.dateTime;
                logForTransaction.CreatedBy = logApiModel.customerDefNo;
                logForTransaction.CreatedOn = DateTime.Now;
                logForTransaction.CodeBlock = logItem.stacktraceString;
                logForTransaction.Email = logApiModel.email;
                logForTransaction.ProfileName = logApiModel.profileName;
                logForTransaction.CounrtyCode=logApiModel.countryCode;
                logForTransaction.Environtment = logApiModel.environtment;
                logForTransactionList.Add(logForTransaction);
            }
            TAddRange(logForTransactionList);

            return true;
        }

        
    }
}
