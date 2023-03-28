using Log.Appenders;

namespace Log.Extensions
{
	public static class AdoNetAppenderExtensions
	{
		/// <summary>
		/// Sets a connection string to AdoNetAppender instance
		/// </summary>
		/// <param name="adoNetAppender">AdoNetAppender instance</param>
		/// <param name="connectionString">Database connection string</param>
		/// <returns>AdoNetAppender instance after setting the database connection string</returns>
		public static AdoNetAppender SetConnectionString(this AdoNetAppender adoNetAppender, string connectionString)
		{
			if (adoNetAppender != null)
			{
				adoNetAppender.ConnectionString = connectionString;
				adoNetAppender.ActivateOptions();
			}

			return adoNetAppender;
		}
	}
}
