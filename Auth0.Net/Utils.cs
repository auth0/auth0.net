namespace Auth0
{
    using System;

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
    }
}
