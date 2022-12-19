using log4net.Core;
using log4net.Layout.Pattern;
using System.Net;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http;
using System;
using static Log.LogProcess;

namespace LogFunctionClasses
{
    public class GetIPAdress : PatternLayoutConverter
    {
        protected override void Convert(System.IO.TextWriter writer, LoggingEvent loggingEvent)
        {
            //Use the value in Option as a key into HttpContext.Current.Session

            string externalIP;
            externalIP = (new WebClient()).DownloadString("http://checkip.dyndns.org/");
            externalIP = (new Regex(@"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}"))
                         .Matches(externalIP)[0].ToString();
            writer.Write(externalIP);

        }
    }
    public class GetLogType : PatternLayoutConverter
    {
        protected override void Convert(System.IO.TextWriter writer, LoggingEvent loggingEvent)
        {
            //Use the value in Option as a key into HttpContext.Current.Session

            string LogType = LogClass.LogType.ToString(); ;
            writer.Write(LogType);

        }
    }
    public class GetUserId : PatternLayoutConverter
    {
        protected override void Convert(System.IO.TextWriter writer, LoggingEvent loggingEvent)
        {
            //Use the value in Option as a key into HttpContext.Current.Session

            Guid userId = LogClass.UserID;
            writer.Write(userId);

        }
    }
    public class GetLogger : PatternLayoutConverter
    {
        protected override void Convert(System.IO.TextWriter writer, LoggingEvent loggingEvent)
        {
            //Use the value in Option as a key into HttpContext.Current.Session

            string logger = LogClass.Logger;
            writer.Write(logger);

        }
    }
    public class GetURL : PatternLayoutConverter
    {
        protected override void Convert(System.IO.TextWriter writer, LoggingEvent loggingEvent)
        {
            //Use the value in Option as a key into HttpContext.Current.Session
            string Url = LogClass.Url;
            writer.Write(Url);


        }
    }
    public class GetTerminalID : PatternLayoutConverter
    {
        protected override void Convert(System.IO.TextWriter writer, LoggingEvent loggingEvent)
        {
            //Use the value in Option as a key into HttpContext.Current.Session
            
            writer.Write(loggingEvent.UserName);


        }
    }
}