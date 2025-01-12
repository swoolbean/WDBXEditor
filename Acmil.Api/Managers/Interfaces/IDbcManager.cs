﻿using Acmil.Common.Utility.Connections;

namespace Acmil.Api.Managers.Interfaces
{
	/// <summary>
	/// Manager for interacting with DBC files.
	/// </summary>
	public interface IDbcManager
	{
		public void LoadDbcIntoDatabase(MySqlConnectionInfo connectionInfo, string database, string dbcPath, string tableName = null);

		public void WriteDbcDataFromDatabase(MySqlConnectionInfo connectionInfo, string database, string dbcPath, string tableName);
		//void LoadDbcIntoSql(string filepath, int buildNumber);

		//void LoadDbcIntoSql(string dbcDirectory, string dbcFileName, int buildNumber);

		//void LoadDbcFromSql(string filepath, int buildNumber, string tableName, UpdateMode updateStrategy);

		//void LoadDbcFromSql(string dbcDirectory, string dbcFileName, int buildNumber, string tableName, UpdateMode updateStrategy);
	}
}
