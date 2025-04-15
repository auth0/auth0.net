using System;
using System.Collections.Generic;
using System.Linq;
using Auth0.AuthenticationApi.Models;
using Auth0.Core.Exceptions;

namespace Auth0.AuthenticationApi
{
    /// <summary>
    /// Provider of generic extension methods.
    /// </summary>
    internal static class ExtensionMethods
    {
        /// <summary>
        /// Adds a key and value to the dictionary provided the value
        /// is not <see langword="null"/> or empty.
        /// </summary>
        /// <param name="dictionary">Dictionary to add the key and value to.</param>
        /// <param name="key">Key of the item to add if <paramref name="value"/> is not <see langword="null"/> or empty.</param>
        /// <param name="value">Value of the item to add if it is not <see langword="null"/> or empty.</param>
        public static void AddIfNotEmpty(this IDictionary<string, string> dictionary, string key, string value)
        {
            if (!string.IsNullOrEmpty(value))
                dictionary.Add(key, value);
        }

        /// <summary>
        /// Adds all items from the source to the target dictionary.
        /// </summary>
        /// <param name="targetDictionary">Dictionary to add the items to.</param>
        /// <param name="sourceDictionary">Dictionary whose items you want to add to the target.</param>
        public static void AddAll(this IDictionary<string, string> targetDictionary,
            IDictionary<string, string> sourceDictionary)
        {
            foreach (var keyValuePair in sourceDictionary)
            {
                if (targetDictionary.ContainsKey(keyValuePair.Key))
                {
                    targetDictionary[keyValuePair.Key] = keyValuePair.Value;
                }
                else
                {
                    targetDictionary.Add(keyValuePair);
                }
            }
        }

        /// <summary>
        /// Get the string value for the corresponding <see cref="AuthorizationResponseMode"/>.
        /// </summary>
        /// <param name="responseMode">The <see cref="AuthorizationResponseMode"/>. for which you want to get the string value.</param>
        /// <returns>The corresponding string value.</returns>
        public static string ToStringValue(this AuthorizationResponseMode responseMode)
        {
            if (responseMode == AuthorizationResponseMode.FormPost)
            {
                return "form_post";
            }

            return null;
        }

        /// <summary>
        /// Get the string value for the corresponding <see cref="AuthorizationResponseType"/>.
        /// </summary>
        /// <param name="responseType">The <see cref="AuthorizationResponseType"/> for which you want to get the string value.</param>
        /// <returns>The corresponding string value.</returns>
        public static string ToStringValue(this AuthorizationResponseType responseType)
        {
            switch (responseType)
            {
                case AuthorizationResponseType.Code:
                    return "code";
                case AuthorizationResponseType.IdToken:
                    return "id_token";
                case AuthorizationResponseType.Token:
                    return "token";
                default:
                    return null;
            }
        }

        /// <summary>
        /// Throws an <see cref="ArgumentNullException"/> if the input object is <see langword="null"/>.
        /// </summary>
        public static void ThrowIfNull(this object input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
        }

        /// <summary>
        /// Extracts the <see cref="QuotaClientLimit"/> from the response headers.
        /// </summary>
        /// <param name="headers">The source response headers</param>
        /// <returns><see cref="QuotaClientLimit"/></returns>
        public static QuotaClientLimit GetClientQuotaLimit(this IDictionary<string, IEnumerable<string>> headers)
        {
            return ParseClientLimit(GetRawHeaders(headers, "X-Quota-Client-Limit"));
        }

        /// <summary>
        /// Extracts the <see cref="QuotaOrganizationLimit"/> from the response headers
        /// </summary>
        /// <param name="headers">The source response headers</param>
        /// <returns><see cref="QuotaOrganizationLimit"/></returns>
        public static QuotaOrganizationLimit GetOrganizationQuotaLimit(
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
        
        internal static QuotaClientLimit ParseClientLimit(string headerValue)
        {
            if (string.IsNullOrEmpty(headerValue))
            {
                return null;
            }
            var buckets = headerValue.Split(',');
            var quotaClientLimit = new QuotaClientLimit();
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

        internal static QuotaOrganizationLimit ParseOrganizationLimit(string headerValue)
        {
            if (string.IsNullOrEmpty(headerValue))
            {
                return null;
            }
            
            var buckets = headerValue.Split(',');
            var quotaOrganizationLimit = new QuotaOrganizationLimit();
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
