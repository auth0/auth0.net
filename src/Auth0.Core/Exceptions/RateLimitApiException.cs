using System;
using System.Runtime.Serialization;

namespace Auth0.Core.Exceptions
{
    /// <summary>
    /// Represents errors caused by rate limits being exceeded when making API calls.
    /// </summary>
    [Serializable]
    public class RateLimitApiException : ApiException
    {
        public RateLimit RateLimit { get; }

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
        /// <param name="rateLimit"><see cref="Core.RateLimit"/> received on the API call that failed.</param>
        public RateLimitApiException(RateLimit rateLimit)
            : this("Rate limits exceeded")
        {
            RateLimit = rateLimit;
        }

        /// <inheritdoc />
        protected RateLimitApiException(SerializationInfo serializationInfo, StreamingContext streamingContext)
            : base(serializationInfo, streamingContext)
        {
        }
    }
}
