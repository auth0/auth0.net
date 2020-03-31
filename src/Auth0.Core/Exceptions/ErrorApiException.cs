using System;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Auth0.Core.Exceptions
{
    /// <summary>
    /// Represents errors that occur when making API calls.
    /// </summary>
    [Serializable]
    public class ErrorApiException : ApiException
    {
        /// <summary>
        /// Optional <see cref="Exceptions.ApiError"/> from the failing API call.
        /// </summary>
        public ApiError ApiError { get; }

        /// <summary>
        /// <see cref="HttpStatusCode"/> code from the failing API call.
        /// </summary>
        public HttpStatusCode StatusCode { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorApiException"/> class.
        /// </summary>
        public ErrorApiException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorApiException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public ErrorApiException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorApiException"/> class with a specified error message
        /// and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null 
        /// reference if no inner exception is specified.</param>
        public ErrorApiException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiException"/> class with a specified
        /// <paramref name="statusCode"/> and optional <paramref name="apiError"/>.
        /// </summary>
        /// <param name="statusCode"><see cref="HttpStatusCode"/>code of the failing API call.</param>
        /// <param name="apiError">Optional <see cref="ApiError"/> of the failing API call.</param>
        public ErrorApiException(HttpStatusCode statusCode, ApiError apiError = null)
            : this(apiError == null ? statusCode.ToString() : apiError.Message)
        {
            StatusCode = statusCode;
            ApiError = apiError;
        }

        /// <inheritdoc />
        protected ErrorApiException(SerializationInfo serializationInfo, StreamingContext streamingContext)
            : base(serializationInfo, streamingContext)
        {
        }

        internal static async Task<ErrorApiException> CreateAsync(HttpResponseMessage response)
        {
            return new ErrorApiException(response.StatusCode, await ApiError.Parse(response).ConfigureAwait(false));
        }
    }
}