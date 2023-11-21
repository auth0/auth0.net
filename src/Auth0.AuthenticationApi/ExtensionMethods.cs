using System.Collections.Generic;
using Auth0.AuthenticationApi.Models;

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
        public static void AddAll(this IDictionary<string, string> targetDictionary, IDictionary<string, string> sourceDictionary)
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
    }
}
