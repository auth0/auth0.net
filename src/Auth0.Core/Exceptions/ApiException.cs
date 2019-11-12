using System;

namespace Auth0.Core.Exceptions
{
    /// <summary>
    /// Represents an exception that occurs when making API calls.
    /// </summary>
    public abstract class ApiException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorApiException"/> class.
        /// </summary>
        public ApiException()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public ApiException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiException"/> class with a specified error message
        /// and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null 
        /// reference if no inner exception is specified.</param>
        public ApiException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}