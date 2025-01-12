﻿using Acmil.Data.Helpers.Connections.Dtos;
using Acmil.Data.Helpers.Connections.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Acmil.Data.Helpers.Connections
{
	public class MySqlConnectionInfoFactory : IMySqlConnectionInfoFactory
	{
		private static Lazy<IMySqlConnectionInfoFactory> _instance = new Lazy<IMySqlConnectionInfoFactory>(() => new MySqlConnectionInfoFactory());

		private IMySqlConnectionInfoCache _cache;
		private IMySqlConnectionEnricher _enricher;

		/// <summary>
		/// Initializes a new instance of <see cref="MySqlConnectionInfoFactory"/>.
		/// </summary>
		/// <param name="cache">An implementation of <see cref="IMySqlConnectionInfoCache"/>.</param>
		/// <param name="enricher">An implementation of <see cref="IMySqlConnectionEnricher"/>.</param>
		internal MySqlConnectionInfoFactory(IMySqlConnectionInfoCache cache, IMySqlConnectionEnricher enricher)
		{
			_cache = cache;
			_enricher = enricher;
		}

		private MySqlConnectionInfoFactory() : this(new MySqlConnectionInfoCache(), MySqlConnectionEnricher.Instance) { }

		/// <summary>
		/// Gets the current instance of <see cref="MySqlConnectionInfoFactory"/>.
		/// </summary>
		public static IMySqlConnectionInfoFactory Instance => _instance.Value;

		public MySqlConnectionInfoInternal GetConnectionInfo(string connectionString)
		{
			return _cache.GetOrAdd(connectionString, () => GetMySqlConnectionInfo(connectionString, null));
		}

		public void OnConnectionStringUpdated()
		{
			_cache.OnConnectionStringUpdated();
		}

		public void RegisterLogin(IMySqlLoginProvider loginProvider)
		{
			if (loginProvider is null)
			{
				throw new ArgumentNullException(nameof(loginProvider));
			}

			if (loginProvider.Username is null)
			{
				throw new ArgumentNullException(nameof(loginProvider.Username));
			}

			_enricher.RegisterLogin(loginProvider);
		}



		private MySqlConnectionInfoInternal GetMySqlConnectionInfo(string connectionString, MySqlConnectionOverrides overrides)
		{
			var builder = new MySqlConnectionStringBuilder(connectionString);
			_enricher.EnsureConnectionString(builder, overrides);
			return new MySqlConnectionInfoInternal(builder);
		}
	}
}
