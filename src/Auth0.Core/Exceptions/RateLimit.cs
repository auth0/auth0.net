using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Xml.Schema;

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
        /// Represents Client Quota Headers returned.  
        /// </summary>
        public ClientQuotaLimit ClientQuotaLimit { get; internal set; }

        /// <summary>
        /// Represents Client Quota Headers returned.  
        /// </summary>
        public OrganizationQuotaLimit OrganizationQuotaLimit { get; internal set; }

        /// <summary>
        /// Parse the rate limit headers into a <see cref="RateLimit"/> object.
        /// </summary>
        /// <param name="headers"><see cref="HttpHeaders"/> to parse.</param>
        /// <returns>Instance of <see cref="RateLimit"/> containing parsed rate limit headers.</returns>
        public static RateLimit Parse(HttpHeaders headers)
        {
            var headersKvp = 
                headers?.ToDictionary(h => h.Key, h => h.Value);
            var reset = GetHeaderValue(headersKvp, "x-ratelimit-reset");
            return new RateLimit
            {
                Limit = GetHeaderValue(headersKvp, "x-ratelimit-limit"),
                Remaining = GetHeaderValue(headersKvp, "x-ratelimit-remaining"),
                Reset = reset == 0 ? null : (DateTimeOffset?)epoch.AddSeconds(reset),
                ClientQuotaLimit = headersKvp.GetClientQuotaLimit(),
                OrganizationQuotaLimit = headersKvp.GetOrganizationQuotaLimit()
            };
        }

        private static long GetHeaderValue(IDictionary<string, IEnumerable<string>> headers, string name)
        {
            if (headers.TryGetValue(name, out var v) && long.TryParse(v?.FirstOrDefault(), out var value))
                return value;

            return 0;
        }
    }
}