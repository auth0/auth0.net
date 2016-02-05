namespace Auth0.Core.Http
{
    /// <summary>
    /// Represents information about an API call.
    /// </summary>
    public class ApiInfo
    {
        /// <summary>
        /// Information about the current rate limit.
        /// </summary>
        public RateLimit RateLimit { get; internal set; }

        /// <summary>
        /// Creates a new instance of the ApiInfo class.
        /// </summary>
        /// <param name="rateLimit">The current rate limit information.</param>
        public ApiInfo(RateLimit rateLimit)
        {
            RateLimit = rateLimit;
        }
    }
}