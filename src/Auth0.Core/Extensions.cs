using System.Collections.Generic;
using System.Linq;

using Auth0.Core.Exceptions;

namespace Auth0.Core
{
    public static class Extensions
    {
        /// <summary>
        /// Extracts the <see cref="ClientQuotaLimit"/> from the response headers.
        /// </summary>
        /// <param name="headers">The source response headers</param>
        /// <returns><see cref="ClientQuotaLimit"/></returns>
        public static ClientQuotaLimit GetClientQuotaLimit(this IDictionary<string, IEnumerable<string>> headers)
        {
            return ParseClientLimit(GetRawHeaders(headers, "X-Quota-Client-Limit"));
        }

        /// <summary>
        /// Extracts the <see cref="OrganizationQuotaLimit"/> from the response headers
        /// </summary>
        /// <param name="headers">The source response headers</param>
        /// <returns><see cref="OrganizationQuotaLimit"/></returns>
        public static OrganizationQuotaLimit GetOrganizationQuotaLimit(
            this IDictionary<string, IEnumerable<string>> headers)
        {
            return ParseOrganizationLimit(GetRawHeaders(headers, "X-Quota-Organization-Limit"));
        }

        internal static string GetRawHeaders(IDictionary<string, IEnumerable<string>> headers, string headerName)
        {
            if (headers == null)
            {
                return null;
            }
            return !headers.TryGetValue(headerName, out var values) ? null : values.FirstOrDefault();
        }
        
        internal static ClientQuotaLimit ParseClientLimit(string headerValue)
        {
            if (string.IsNullOrEmpty(headerValue))
            {
                return null;
            }
            var buckets = headerValue.Split(',');
            var quotaClientLimit = new ClientQuotaLimit();
            foreach (var eachBucket in buckets)
            {
                var quotaLimit = ParseQuotaLimit(eachBucket, out var bucket);
                if (bucket == "per_hour")
                {
                    quotaClientLimit.PerHour = quotaLimit;
                }
                else
                {
                    quotaClientLimit.PerDay = quotaLimit;    
                }
            }

            return quotaClientLimit;
        }

        internal static OrganizationQuotaLimit ParseOrganizationLimit(string headerValue)
        {
            if (string.IsNullOrEmpty(headerValue))
            {
                return null;
            }
            
            var buckets = headerValue.Split(',');
            var quotaOrganizationLimit = new OrganizationQuotaLimit();
            foreach (var eachBucket in buckets)
            {
                var quotaLimit = ParseQuotaLimit(eachBucket, out var bucket);
                if (bucket == "per_hour")
                {
                    quotaOrganizationLimit.PerHour = quotaLimit;
                    continue;
                }

                quotaOrganizationLimit.PerDay = quotaLimit;
            }

            return quotaOrganizationLimit;
        }

        internal static QuotaLimit ParseQuotaLimit(string headerValue, out string bucket)
        {
            bucket = null;

            if (string.IsNullOrEmpty(headerValue))
                return null;

            var kvp = headerValue
                .Split(';')
                .Select(x => x.Split('='))
                .ToDictionary(keyValue => keyValue[0], keyValue => keyValue[1]);
            bucket = kvp["b"];
            return new QuotaLimit
            {
                Quota = int.Parse(kvp["q"]),
                Remaining = int.Parse(kvp["r"]),
                Time = int.Parse(kvp["t"])
            };
        }
    }
}