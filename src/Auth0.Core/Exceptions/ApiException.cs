using System;
using System.Net;

namespace Auth0.Core.Exceptions
{
    /// <summary>
    /// Represents errors that occur when making API calls.
    /// </summary>
    public class ApiException : Exception
    {
        /// <summary>
        /// The <see cref="Core.ApiError"/> from the response.
        /// </summary>
        public ApiError ApiError { get; }

        /// <summary>
        /// The <see cref="HttpStatusCode"/> code associated with the response.
        /// </summary>
        public HttpStatusCode StatusCode { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiException"/> class.
        /// </summary>
        public ApiException()
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

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiException"/> class with a specified
        /// <see cref="HttpStatusCode"/>.
        /// </summary>
        /// The <see cref="HttpStatusCode"/> code associated with the response.
        public ApiException(HttpStatusCode statusCode)
            : this(statusCode.ToString())
        {
            StatusCode = statusCode;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiException"/> class with a specified
        /// <see cref="HttpStatusCode"/> and <see cref="Core.ApiError"/>.
        /// </summary>
        /// <param name="statusCode">The status code.</param>
        /// <param name="apiError">The API error.</param>
        public ApiException(HttpStatusCode statusCode, ApiError apiError)
            : this(apiError == null ? statusCode.ToString() : apiError.Message)
        {
            StatusCode = statusCode;
            ApiError = apiError;
        }
    }
}