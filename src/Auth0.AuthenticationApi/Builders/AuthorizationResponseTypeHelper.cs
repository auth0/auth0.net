using Auth0.AuthenticationApi.Models;
using System;
using System.Collections.Generic;

namespace Auth0.AuthenticationApi.Builders
{
    public static class AuthorizationResponseTypeHelper
    {
        private static readonly Dictionary<AuthorizationResponseType, string> Map = new Dictionary<AuthorizationResponseType, string>
        {
            { AuthorizationResponseType.Code, "code" },
            { AuthorizationResponseType.IdToken, "id_token" },
            { AuthorizationResponseType.Token, "token" }
        };

        public static string ConvertToString(AuthorizationResponseType responseType)
        {
            if (!Map.TryGetValue(responseType, out var value))
            {
                throw new ArgumentException("Unknown response type.", nameof(responseType));
            }

            return value;
        }
    }
}
