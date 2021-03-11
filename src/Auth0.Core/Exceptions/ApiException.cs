using System;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Auth0.Core.Exceptions
{
    /// <summary>
    /// Represents an exception that occurs when making API calls.
    /// </summary>
    [Serializable]
    public abstract class ApiException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorApiException"/> class.
        /// </summary>
        protected ApiException()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        protected ApiException(string message)
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
        protected ApiException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <inheritdoc />
        protected ApiException(SerializationInfo serializationInfo, StreamingContext streamingContext)
            : base(serializationInfo, streamingContext)
        {
        }

        /// <summary>
        /// Create an instance of the specific exception required for this unsuccessful <see cref="HttpResponseMessage"/>.
        /// </summary>
        /// <param name="response"><see cref="HttpResponseMessage"/> to parse for the correct exception.</param>
        /// <returns>An instance of a <see cref="ApiException"/> subclass containing the appropriate exception for this response.</returns>
        public static async Task<ApiException> CreateSpecificExceptionAsync(HttpResponseMessage response)
        {
            switch ((int)response.StatusCode)
            {
                case 429:
                    return await RateLimitApiException.CreateAsync(response).ConfigureAwait(false);
                default:
                    return await ErrorApiException.CreateAsync(response).ConfigureAwait(false);
            }
        }
    }
}