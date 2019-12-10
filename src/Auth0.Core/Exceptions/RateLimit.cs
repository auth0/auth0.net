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
        public DateTimeOffset Reset { get; internal set; }

        public static RateLimit Parse(HttpResponseHeaders headers)
        {
            // Determine reset
            long resetInUnixTime = GetHeaderValue(headers, "x-ratelimit-reset");
            DateTimeOffset epoch = new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero);
            DateTimeOffset reset = epoch.AddSeconds(resetInUnixTime);

            return new RateLimit
            {
                Limit = GetHeaderValue(headers, "x-ratelimit-limit"),
                Remaining = GetHeaderValue(headers, "x-ratelimit-remaining"),
                Reset = reset
            };
        }

        private static long GetHeaderValue(HttpResponseHeaders headers, string name)
        {
            long result = 0;

            headers.TryGetValues(name, out var values);
            string value = values?.FirstOrDefault();
            if (value != null)
            {
                long.TryParse(value, out result);
            }

            return result;
        }
    }
}