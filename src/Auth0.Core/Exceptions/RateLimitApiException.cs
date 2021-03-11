using System;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Auth0.Core.Exceptions
{
    /// <summary>
    /// Represents errors caused by rate limits being exceeded when making API calls.
    /// </summary>
    [Serializable]
    public class RateLimitApiException : ApiException
    {
        /// <summary>
        /// <see cref="RateLimit"/> as determined by the server.
        /// </summary>
        public RateLimit RateLimit { get; }

        /// <summary>
        /// Optional <see cref="Exceptions.ApiError"/> from the failing API call.
        /// </summary>
        public ApiError ApiError { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RateLimitApiException"/> class.
        /// </summary>
        public RateLimitApiException() {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RateLimitApiException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public RateLimitApiException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RateLimitApiException"/> class with a specified error message
        /// and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null 
        /// reference if no inner exception is specified.</param>
        public RateLimitApiException(string message, Exception innerException)
            : base(message, innerException)
        {
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="RateLimitApiException"/> class with a specified <paramref name="rateLimit"/>.
        /// </summary>
        /// <param name="rateLimit"><see cref="Exceptions.RateLimit"/> received on the API call that failed.</param>
        /// <param name="apiError"><see cref="Exceptions.ApiError"/> received on the API call that failed.</param>
        public RateLimitApiException(RateLimit rateLimit, ApiError apiError = null)
            : this("Rate limits exceeded")
        {
            RateLimit = rateLimit;
            ApiError = apiError;
        }

        internal static async Task<RateLimitApiException> CreateAsync(HttpResponseMessage response)
        {
	        return new RateLimitApiException(RateLimit.Parse(response.Headers), await ApiError.Parse(response).ConfigureAwait(false));
        }

        /// <inheritdoc />
        protected RateLimitApiException(SerializationInfo serializationInfo, StreamingContext streamingContext)
            : base(serializationInfo, streamingContext)
        {
        }
    }
}
