using System;
using System.Net;
using Auth0.Core.Models;

namespace Auth0.ManagementApi.Client.Exceptions
{
    /// <summary>
    /// Represents errors that occur when making API calls.
    /// </summary>
    public class ApiException : Exception
    {
        /// <summary>
        ///     The exception payload from the response
        /// </summary>
        public ApiError ApiError { get; private set; }

        /// <summary>
        ///     The HTTP status code associated with the repsonse
        /// </summary>
        public HttpStatusCode StatusCode { get; private set; }


        public ApiException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public ApiException(HttpStatusCode statusCode)
            : base(statusCode.ToString())
        {
        }

        public ApiException(HttpStatusCode statusCode, ApiError apiError)
            : base(apiError == null ? statusCode.ToString() : apiError.Message)
        {
            StatusCode = statusCode;
            ApiError = apiError;
        }
    }
}