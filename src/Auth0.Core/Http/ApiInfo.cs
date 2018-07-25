using System;

namespace Auth0.Core.Http
{
    /// <summary>
    /// Represents information about an API call.
    /// </summary>
    public class ApiInfo
    {
        /// <summary>
        ///   Information about the current rate limit.
        /// </summary>
        public RateLimit RateLimit { get; internal set; }

        /// <summary>
        ///   The server time of the last request as provided by the Date http header
        /// </summary>
        public DateTimeOffset? ServerTime { get; internal set; }
        
        /// <summary>
        /// Creates a new instance of the ApiInfo class.
        /// </summary>
        /// <param name="rateLimit">The current rate limit information.</param>
        public ApiInfo(RateLimit rateLimit) : this(rateLimit, null)
        {
        }
        
        /// <summary>
        /// Creates a new instance of the ApiInfo class.
        /// </summary>
        /// <param name="rateLimit">The current rate limit information.</param>
        /// <param name="serverTime">The current server time</param>
        public ApiInfo(RateLimit rateLimit, DateTimeOffset? serverTime)
        {
            RateLimit = rateLimit;
            ServerTime = serverTime;
        }
    }
}