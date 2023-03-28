using Microsoft.Extensions.Configuration;

namespace Log
{
	public static class ConfigurationHelper
	{
		public static IConfiguration BuildConfiguration()
		{
			var configuration = new ConfigurationBuilder()
				.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
				.Build();

			return configuration;
		}
	}
}