﻿using System;
using System.Collections.Concurrent;
using WDBXEditor.Data.Helpers.Connections.Dtos;
using WDBXEditor.Data.Helpers.Connections.Interfaces;

namespace WDBXEditor.Data.Helpers.Connections
{
	/// <summary>
	/// Cache for <see cref="MySqlConnectionInfo"/> instances.
	/// </summary>
	internal class MySqlConnectionInfoCache : IMySqlConnectionInfoCache
	{
		private readonly ConcurrentDictionary<string, MySqlConnectionInfo> _connectionStringCache = new ConcurrentDictionary<string, MySqlConnectionInfo>();

		public MySqlConnectionInfo GetOrAdd(string key, Func<MySqlConnectionInfo> factory)
		{
			if (factory == null)
			{
				throw new ArgumentNullException(nameof(factory));
			}

			return _connectionStringCache.GetOrAdd(key, x => factory());
		}

		public void OnConnectionStringUpdated()
		{
			_connectionStringCache.Clear();
		}
	}
}
