using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;

namespace Auth0.Core.Http
{
    internal static class ApiInfoParser
    {
        public static ApiInfo Parse(HttpResponseHeaders headers)
        {
            RateLimit rateLimit = ParseRateLimit(headers);

            return new ApiInfo(rateLimit);
        }

        private static RateLimit ParseRateLimit(HttpResponseHeaders headers)
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

            IEnumerable<string> values = null;
            headers.TryGetValues(name, out values);
            string value = values?.FirstOrDefault();
            if (value != null)
            {
                long.TryParse(value, out result);
            }

            return result;
        }
    }
}