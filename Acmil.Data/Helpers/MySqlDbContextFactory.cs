﻿using Acmil.Common.Utility.Connections;
using Acmil.Data.Contexts;
using Acmil.Data.Helpers.Interfaces;
using System.Runtime.InteropServices;
using System.Security;

namespace Acmil.Data.Helpers
{
	/// <summary>
	/// Factory class for creating instances of <see cref="MySqlContext"/>.
	/// </summary>
	public class MySqlDbContextFactory : IDbContextFactory
	{
		public IDbContext GetContext(string hostname, string username, SecureString password, string database)
		{
			string connectionString = BuildConnectionStringWithSecuredPassword(hostname, username, password, database);
			return new MySqlContext(connectionString);
		}

		public IDbContext GetContext(MySqlConnectionInfo connectionInfo, string database)
		{
			return GetContext(
				connectionInfo.Hostname,
				connectionInfo.Credential.UserName,
				connectionInfo.Credential.Password,
				database
			);
		}

		// It would be a good idea to not convert the password to plaintext,
		// but we'd need to come up with a reasonable cross-platform solution.
		private string BuildConnectionStringWithSecuredPassword(string hostname, string username, SecureString password, string database)
		{
			var valuePtr = Marshal.SecureStringToBSTR(password);
			string unsecuredPassword = Marshal.PtrToStringUni(valuePtr);
			string connectionString = $"Server={hostname};Uid={username};Pwd={unsecuredPassword};";

			if (!string.IsNullOrWhiteSpace(database))
			{
				connectionString += $"Database={database};";
			}

			return connectionString;
		}
	}
}
