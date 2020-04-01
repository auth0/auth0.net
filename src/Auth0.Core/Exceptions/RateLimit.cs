using System;
using System.Linq;
using System.Net.Http.Headers;

namespace Auth0.Core.Exceptions
{
    /// <summary>
    /// Represents information about the rate limit for API calls.
    /// </summary>
    public class RateLimit
    {
        private static DateTimeOffset epoch = new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero);

        /// <summary>
        /// The maximum number of requests the consumer is allowed to make.
        /// </summary>
        public long Limit { get; internal set; }

        /// <summary>
        /// The number of requests remaining in the current rate limit window.
        /// </summary>
        public long Remaining { get; internal set; }

        /// <summary>
        /// The date and time offset at which the current rate limit window is reset.
        /// </summary>
        public DateTimeOffset? Reset { get; internal set; }

        /// <summary>
        /// Parse the rate limit headers into a <see cref="RateLimit"/> object.
        /// </summary>
        /// <param name="headers"><see cref="HttpHeaders"/> to parse.</param>
        /// <returns>Instance of <see cref="RateLimit"/> containing parsed rate limit headers.</returns>
        public static RateLimit Parse(HttpHeaders headers)
        {
            var reset = GetHeaderValue(headers, "x-ratelimit-reset");
            return new RateLimit
            {
                Limit = GetHeaderValue(headers, "x-ratelimit-limit"),
                Remaining = GetHeaderValue(headers, "x-ratelimit-remaining"),
                Reset = reset == 0 ? null : (DateTimeOffset?)epoch.AddSeconds(reset)
            };
        }

        private static long GetHeaderValue(HttpHeaders headers, string name)
        {
            if (headers.TryGetValues(name, out var v) && long.TryParse(v?.FirstOrDefault(), out var value))
                return value;

            return 0;
        }
    }
}