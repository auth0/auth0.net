using Auth0.AuthenticationApi.Models;
using System;
using System.Collections.Generic;

namespace Auth0.AuthenticationApi.Builders
{
    public static class AuthorizationResponseModeHelper
    {
        private static readonly Dictionary<AuthorizationResponseMode, string> Map = new Dictionary<AuthorizationResponseMode, string>
        {
            { AuthorizationResponseMode.FormPost, "form_post" }
        };

        public static string ConvertToString(AuthorizationResponseMode responseMode)
        {
            if (!Map.TryGetValue(responseMode, out var value))
            {
                throw new ArgumentException("Unknown response type.", nameof(responseMode));
            }

            return value;
        }
    }
}
