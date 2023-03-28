using log4net;
using log4net.Config;
using System;
using System.IO;
using System.Reflection;
using System.Xml;

namespace Log
{
	public static class Log4NetHelper
	{
		public static void ConfigureLog4Net(string FileName)
		{
			var type = typeof(Log4NetHelper);
			var assembly = type.Assembly;

			XmlConfigurator.Configure(
				LogManager.GetRepository(assembly),
				new FileInfo($@"{AppDomain.CurrentDomain.BaseDirectory}{FileName}")
			);
		}
		

		public static ILog GetLogger(Type type)
		{
			return LogManager.GetLogger(type);
		}

		public static void SetLog4NetConfiguration()
		{
			XmlConfigurator.Configure(new FileInfo($@"{AppDomain.CurrentDomain.BaseDirectory}LogForError.config"));
		}
	}
}
