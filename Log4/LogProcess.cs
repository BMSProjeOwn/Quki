using Log.Helpers;
using log4net;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Log
{
    public static class LogProcess
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger("Log.AdoNetLogger");
        private static readonly Assembly _RepositoryAssembly = typeof(LogProcess).Assembly;
        private static readonly string _connectionString = ConnectionString();
        public static string ConnectionString()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                        .AddJsonFile("appsettings.json")
                        .Build();

            return configuration.GetConnectionString("DefaultConnection").ToString();
        }
        public static void setLogForTranstion(Exception ex = null)
        {
            Log4NetHelper.ConfigureLog4Net("LogForTransection.config");
            var results = AdoNetAppenderHelper.SetConnectionString(_connectionString);
            var logger = LogManager.GetLogger(_RepositoryAssembly, "Log.AdoNetLogger");
            if (LogClass.LogLevel == LogLevel.Error)
            {
                logger.Error(LogClass.Message, ex);
            }
            if (LogClass.LogLevel == LogLevel.Info)
            {
                logger.Info(LogClass.Message, ex);
            }
            ResetLog();
        }
        private static void ResetLog()
        {
            LogClass.UserID = new Guid();
            LogClass.LogLevel = LogLevel.Reset;
            LogClass.TerminalId = ""
; LogClass.Message = "";
            LogClass.Url = "";
            LogClass.LogType = LogType.NotSet;
            LogClass.Logger = "";
        }
        public static void setLogForDefiniton(Exception ex = null)
        {
            Log4NetHelper.ConfigureLog4Net("LofForDefinition.config");
            var results = AdoNetAppenderHelper.SetConnectionString(_connectionString);
            var logger = LogManager.GetLogger(_RepositoryAssembly, "Log.AdoNetLogger");
            if (LogClass.LogLevel == LogLevel.Error)
            {
                logger.Error(LogClass.Message, ex);
            }
            if (LogClass.LogLevel == LogLevel.Info)
            {
                logger.Info(LogClass.Message, ex);
            }
            ResetLog();
        }
        public static void setLogForError(Exception ex = null)
        {

            Log4NetHelper.SetLog4NetConfiguration();
            var logger = LogManager.GetLogger("Log.AdoNetLogger");
            if (LogClass.LogLevel == LogLevel.Error)
            {
                logger.Error(LogClass.Message);
            }
            if (LogClass.LogLevel == LogLevel.Info)
            {
                logger.Info(LogClass.Message);
            }
            ResetLog();
        }

        public class LogClass
        {
            public static Guid UserID;
            public static LogLevel LogLevel;
            public static string TerminalId;
            public static string Message;
            public static string Url;
            public static LogType LogType;
            public static string Logger;
        }
        public enum LogLevel
        {
            Error = 1,
            Info = 2,
            Reset = 3
        }
        public enum LogType
        {

            Update = 1,
            Insert = 2,
            Delete = 3,
            Login = 4,
            Error= 5,
            NotSet
        }
    }
}
