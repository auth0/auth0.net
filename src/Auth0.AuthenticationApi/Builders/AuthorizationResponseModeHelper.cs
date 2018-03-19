using System;
using System.Collections.Generic;
using Auth0.AuthenticationApi.Models;

namespace Auth0.AuthenticationApi.Builders
{
    public class AuthorizationResponseModeHelper
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
