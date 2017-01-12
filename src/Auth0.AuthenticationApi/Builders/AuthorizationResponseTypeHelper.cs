using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Auth0.AuthenticationApi.Builders
{
    using Auth0.AuthenticationApi.Models;
    
    public class AuthorizationResponseTypeHelper
    {
        private static Dictionary<AuthorizationResponseType, string> Map = new Dictionary<AuthorizationResponseType, string>
        {
            { AuthorizationResponseType.Code, "code" },
            { AuthorizationResponseType.IdToken, "id_token" },
            { AuthorizationResponseType.Token, "token" }
        };

        public static string ConvertToString(AuthorizationResponseType responseType)
        {
            string value;
            if (!Map.TryGetValue(responseType, out value))
            {
                throw new ArgumentException("Unknown response type.", nameof(responseType));
            }

            return value;
        }
    }
}
