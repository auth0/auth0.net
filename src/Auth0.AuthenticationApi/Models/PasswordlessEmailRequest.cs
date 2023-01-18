using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Auth0.AuthenticationApi.Models
{
    /// <summary>
    /// Represents a request to start a Passwordless email flow.
    /// </summary>
    public class PasswordlessEmailRequest
    {
        /// <summary>
        /// Client ID of the application.
        /// </summary>
        [JsonProperty("client_id")]
        public string ClientId { get; set; }

        /// <summary>
        /// Client Secret of the application.
        /// </summary>
        [JsonProperty("client_secret")]
        public string ClientSecret { get; set; }

        /// <summary>
        /// Security Key to use with Client Assertion
        /// </summary>
        public SecurityKey ClientAssertionSecurityKey { get; set; }

        /// <summary>
        /// Algorithm for the Security Key to use with Client Assertion
        /// </summary>
        public string ClientAssertionSecurityKeyAlgorithm { get; set; }

        /// <summary>
        /// Email to which the link or code must be sent.
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// <see cref="PasswordlessEmailRequestType"/> of the request.
        /// </summary>
        [JsonProperty("send")]
        public PasswordlessEmailRequestType Type { get; set; }

        /// <summary>
        /// Additional authentication parameters.
        /// </summary>
        [JsonProperty("authParams")]
        public IDictionary<string, object> AuthenticationParameters { get; set; } = new Dictionary<string, object>();
    }
}