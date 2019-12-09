using System.Collections.Generic;

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
    }
}
