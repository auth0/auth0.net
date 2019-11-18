using System.Collections.Generic;

namespace Auth0.AuthenticationApi
{
    internal static class Extensions
    {
        public static void AddIfNotEmpty(this IDictionary<string, object> dictionary, string key, string value)
        {
            if (!string.IsNullOrEmpty(value))
                dictionary.Add(key, value);
        }
    }
}
