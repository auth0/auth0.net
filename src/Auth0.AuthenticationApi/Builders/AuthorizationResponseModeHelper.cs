using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Auth0.AuthenticationApi.Builders
{
    using Auth0.AuthenticationApi.Models;
    
    public class AuthorizationResponseModeHelper
    {
        private static Dictionary<AuthorizationResponseMode, string> Map = new Dictionary<AuthorizationResponseMode, string>
        {
            { AuthorizationResponseMode.FormPost, "form_post" }
        };

        public static string ConvertToString(AuthorizationResponseMode responseMode)
        {
            string value;
            if (!Map.TryGetValue(responseMode, out value))
            {
                throw new ArgumentException("Unknown response type.", nameof(responseMode));
            }

            return value;
        }
    }
}
