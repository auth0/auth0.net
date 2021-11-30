using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Auth0.Core.Http
{
    internal static class Utils
    {
        internal static byte[] Base64UrlDecode(string input)
        {
            var output = input;
            output = output.Replace('-', '+');          // 62nd char of encoding
            output = output.Replace('_', '/');          // 63rd char of encoding

            switch (output.Length % 4)                  // Pad with trailing '='s
            {
                case 0: break;                          // No pad chars in this case
                case 2: output += "=="; break;          // Two pad chars
                case 3: output += "="; break;           // One pad char
                default: throw new InvalidOperationException("Illegal base64url string!");
            }

            return Convert.FromBase64String(output);    // Standard base64 decoder
        }

        internal static string Base64UrlEncode(byte[] input)
        {
            var output = Convert.ToBase64String(input);
            output = output.Replace('-', '+');
            output = output.Replace('_', '/');
            output = output.PadRight(output.Length + (4 - output.Length % 4) % 4, '=');

            return output;
        }

        internal static Uri BuildUri(string baseUrl, string resource, IDictionary<string, string> urlSegments, IDictionary<string, string> queryStrings, bool includeEmptyParameters = false)
        {
            // Replace the URL Segments
            if (urlSegments != null)
            {
                foreach (var urlSegment in urlSegments)
                {
                    resource = resource.Replace($"{{{urlSegment.Key}}}", Uri.EscapeDataString(urlSegment.Value ?? String.Empty));
                }

                // Remove trailing slash
                resource = resource.TrimEnd('/');
            }

            // Add the query strings
            var queryString = queryStrings?.Aggregate(new StringBuilder(), (sb, kvp) =>
                {
                    if (kvp.Value != null)
                    {
                        if (sb.Length > 0)
                            sb = sb.Append("&");

                        sb.Append($"{Uri.EscapeDataString(kvp.Key)}={Uri.EscapeDataString(kvp.Value)}");
                    }
                    else if (includeEmptyParameters)
                    {
                        if (sb.Length > 0)
                            sb = sb.Append("&");

                        sb.Append(Uri.EscapeDataString(kvp.Key));
                    }

                    return sb;
                })
                .ToString();

            // If we have a querystring, append it to the resource
            if (!string.IsNullOrEmpty(queryString))
            {
                resource = resource.Contains("?") ? $"{resource}&{queryString}" : $"{resource}?{queryString}";
            }

            resource = CombineUriParts(baseUrl, resource);

            return new Uri(resource, UriKind.RelativeOrAbsolute);
        }

        /// <summary>
        /// Combines URI parts, taking care of trailing and starting slashes.
        /// See http://stackoverflow.com/a/6704287
        /// </summary>
        /// <param name="uriParts">The URI parts to combine.</param>
        internal static string CombineUriParts(params string[] uriParts)
        {
            var uri = string.Empty;
            if (uriParts != null && uriParts.Any())
            {
                uriParts = uriParts.Where(part => !string.IsNullOrWhiteSpace(part)).ToArray();
                char[] trimChars = { '\\', '/' };
                uri = (uriParts[0] ?? string.Empty).TrimEnd(trimChars);
                for (var i = 1; i < uriParts.Length; i++)
                {
                    uri = $"{uri.TrimEnd(trimChars)}/{(uriParts[i] ?? string.Empty).TrimStart(trimChars)}";
                }
            }
            return uri;
        }

    }
}