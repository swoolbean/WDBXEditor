﻿using Acmil.Common.Utility.Configuration.Interfaces;
using Acmil.Common.Utility.Configuration.SettingsModels.Logging;
using Acmil.Common.Utility.Logging.Enums;
using Acmil.Common.Utility.Logging.Interfaces;
using System.Text;

namespace Acmil.Common.Utility.Logging
{
	/// <summary>
	/// A helper class for logging messages.
	/// </summary>
	public class Logger : ILogger
	{
		private readonly LoggingLevel _configuredLoggingLevel;
		private readonly LoggingDestinations _configuredLoggingDestinations;

		private readonly bool _isAnyLoggingDestinationSet;

		/// <summary>
		/// Initializes a new instance of <see cref="Logger"/> using the provided <see cref="IConfigurationManager"/>.
		/// </summary>
		/// <param name="configurationManager">An implementation of <see cref="IConfigurationManager"/> configure the instance with.</param>
		public Logger(IConfigurationManager configurationManager)
		{
			LoggingConfiguration loggingSettings = configurationManager.GetConfiguration().Logging;
			_configuredLoggingDestinations = loggingSettings.Destinations;
			_isAnyLoggingDestinationSet = _configuredLoggingDestinations.Console || _configuredLoggingDestinations.File;
			_configuredLoggingLevel = Enum.Parse<LoggingLevel>(loggingSettings.Level, ignoreCase: true);
		}

		public void LogCritical(string message) => Log(message, LoggingLevel.Critical);

		public void LogCritical(Exception exception, string message) => Log(exception, message, LoggingLevel.Critical);

		public void LogError(string message) => Log(message, LoggingLevel.Error);

		public void LogError(Exception exception, string message) => Log(exception, message, LoggingLevel.Error);

		public void LogWarning(string message) => Log(message, LoggingLevel.Warning);

		public void LogWarning(Exception exception, string message) => Log(exception, message, LoggingLevel.Warning);

		public void LogDebug(string message) => Log(message, LoggingLevel.Debug);

		public void LogDebug(Exception exception, string message) => Log(exception, message, LoggingLevel.Debug);

		public void LogInformation(string message) => Log(message, LoggingLevel.Information);

		public void LogInformation(Exception exception, string message) => Log(exception, message, LoggingLevel.Information);

		public void LogVerbose(string message) => Log(message, LoggingLevel.Verbose);

		public void LogVerbose(Exception exception, string message) => Log(exception, message, LoggingLevel.Verbose);

		private void Log(string message, LoggingLevel loggingLevel) => Log(null, message, loggingLevel);

		private void Log(Exception exception, string message, LoggingLevel loggingLevel)
		{
			if (loggingLevel >= _configuredLoggingLevel && _isAnyLoggingDestinationSet)
			{
				DateTime timestamp = DateTime.Now;
				var builder = new StringBuilder();

				// Add the current timestamp.
				builder.AppendFormat("[{0}]", timestamp.ToString("yyyy-MM-dd HH:mm:ss"));

				// Add the message level.
				builder.AppendFormat("[{0}] ", loggingLevel.ToString().ToUpper());
				builder.Append(message);

				if (exception is not null)
				{
					builder.AppendLine();
					AppendException(builder, exception);
				}

				// Add one more newline to set up the next logged message.
				builder.AppendLine();

				string messageToLog = builder.ToString();
				if (_configuredLoggingDestinations.Console)
				{
					WriteMessageToConsole(messageToLog);
				}

				if (_configuredLoggingDestinations.File)
				{
					WriteMessageToFile(messageToLog);
				}
			}

		}

		private void WriteMessageToConsole(string message)
		{
			Console.Write(message);
		}

		private void WriteMessageToFile(string message)
		{
			// TODO: Implement this.
			throw new NotImplementedException("Logging to a file is not yet supported.");
		}

		private void AppendException(StringBuilder builder, Exception ex)
		{
			builder.AppendFormat("{0}: {1}", ex.GetType().FullName, ex.Message);
			builder.AppendLine();
			builder.AppendLine("Full Stack Trace:");
			builder.Append(ex.StackTrace);
		}
	}
}
