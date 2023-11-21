using System.Collections.Generic;
using Microsoft.IdentityModel.Tokens;

namespace Auth0.AuthenticationApi.Models
{
    public class PushedAuthorizationRequest : IClientAuthentication
    {
        /// <summary>
        /// Client ID of the application.
        /// </summary>
        public string ClientId { get; set; }
        
        /// <summary>
        /// URI to redirect to.
        /// </summary>
        public string RedirectUri { get; set; }
        
        /// <summary>
        /// Client secret of the application.
        /// </summary>
        /// <remarks>
        /// Optional except when using <see cref="AuthorizationCodeRequestBase"/>.
        /// </remarks>
        public string ClientSecret { get; set; }
        
        /// <summary>
        /// <see cref="AuthorizationResponseType"/> the client expects.
        /// </summary>
        public AuthorizationResponseType ResponseType { get; set; }
        
        /// <summary>
        /// Response mode to use.
        /// </summary>
        public AuthorizationResponseMode? ResponseMode { get; set; }
        
        /// <summary>
        /// The nonce.
        /// </summary>
        public string Nonce { get; set; }

        /// <summary>
        /// Security Key to use with Client Assertion
        /// </summary>
        public SecurityKey ClientAssertionSecurityKey { get; set; }

        /// <summary>
        /// Algorithm for the Security Key to use with Client Assertion
        /// </summary>
        public string ClientAssertionSecurityKeyAlgorithm { get; set; }
        
        /// <summary>
        /// State value to be passed back on successful authorization.
        /// </summary>
        public string State { get; set; }
        
        /// <summary>
        /// Name of the connection.
        /// </summary>
        public string Connection { get; set; }
        
        /// <summary>
        /// Scopes to request.
        /// </summary>
        /// <remarks>
        /// Multiple scopes must be separated by a space character.
        /// </remarks>
        public string Scope { get; set; }
        
        /// <summary>
        /// Audience to request API access for.
        /// </summary>
        public string Audience { get; set; }
        
        /// <summary>
        /// The organization to log the user in to.
        /// </summary>
        public string Organization { get; set; }
        
        /// <summary>
        /// The Id of an invitation to accept. 
        /// </summary>
        /// <remarks>
        /// This is available from the URL that is given when participating in a user invitation flow.
        /// </remarks>
        public string Invitation { get; set; }

        /// <summary>
        /// Any additional properties to use.
        /// </summary>
        public IDictionary<string, string> AdditionalProperties { get; set; } = new Dictionary<string, string>();
    }
}