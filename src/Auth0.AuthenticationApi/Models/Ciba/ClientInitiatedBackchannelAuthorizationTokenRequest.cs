using System.Collections.Generic;
using Microsoft.IdentityModel.Tokens;

namespace Auth0.AuthenticationApi.Models.Ciba
{
    /// <summary>
    /// Contains information required for request token using CIBA.
    /// </summary>
    public class ClientInitiatedBackchannelAuthorizationTokenRequest : IClientAuthentication
    {
        /// <inheritdoc cref="IClientAuthentication.ClientId"/>
        public string ClientId { get; set; }

        /// <inheritdoc cref="IClientAuthentication.ClientSecret"/>
        public string ClientSecret { get; set; }
        
        /// <inheritdoc cref="IClientAuthentication.ClientAssertionSecurityKey"/>
        public SecurityKey ClientAssertionSecurityKey { get; set; }
        
        /// <inheritdoc cref="IClientAuthentication.ClientAssertionSecurityKeyAlgorithm"/>
        public string ClientAssertionSecurityKeyAlgorithm { get; set; }

        /// <summary>
        /// Unique identifier of the authorization request. This value will be returned from the call to /bc-authorize.
        /// </summary>
        public string AuthRequestId { get; set; }
        
        /// <summary>
        /// Any additional properties to use.
        /// </summary>
        public IDictionary<string, string> AdditionalProperties { get; set; } = new Dictionary<string, string>();
    }
}