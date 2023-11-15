using Acmil.Common.Utility.Configuration;
using System.Runtime.Serialization;

namespace Acmil.Common.Utility.Exceptions
{
	/// <summary>
	/// Represents the error where something attempts to read the configured MySQL connection info from
	/// <see cref="ConfigurationManager"/>, but no connection info has been configured.
	/// </summary>
	[Serializable]
	public class NoConnectionInfoSetException : Exception
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="NoConnectionInfoSetException"/> class.
		/// </summary>
		public NoConnectionInfoSetException()
		{

		}

		/// <summary>
		/// Initializes a new instance of the <see cref="NoConnectionInfoSetException"/> class with a specified error message.
		/// </summary>
		/// <param name="message">The message that describes the error.</param>
		public NoConnectionInfoSetException(string message) : base(message)
		{

		}

		/// <summary>
		/// Initializes a new instance of the <see cref="NoConnectionInfoSetException"/> class with a specified error message and a reference to the inner exception that is the cause of the exception.
		/// </summary>
		/// <param name="message">The message that describes the error.</param>
		/// <param name="inner">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
		public NoConnectionInfoSetException(string message, Exception inner) : base(message, inner)
		{

		}

		/// <summary>
		/// Initializes a new instance of the <see cref="NoConnectionInfoSetException"/> class with serialized data.
		/// </summary>
		/// <param name="info">The <see cref="SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
		/// <param name="context">The <see cref="StreamingContext"/> that contains contextual information about the source or destination.</param>
		protected NoConnectionInfoSetException(SerializationInfo info, StreamingContext context) : base(info, context)
		{

		}
	}
}