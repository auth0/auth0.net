using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// Represents a client (App) in Auth0
    /// </summary>
    public class Client : ClientBase
    {
        /// <summary>
        /// The id of the client.
        /// </summary>
        [JsonProperty("client_id")]
        public string ClientId { get; set; }

        /// <summary>
        /// Client signing keys.
        /// </summary>
        [JsonProperty("signing_keys")]
        public SigningKey[] SigningKeys { get; set; }

        /// <summary>
        /// The type of application this client represents
        /// </summary>
        [JsonProperty("app_type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ClientApplicationType ApplicationType { get; set; }

        /// <summary>
        /// Defines the requested authentication method for the token endpoint.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        [JsonProperty("token_endpoint_auth_method")]
        [JsonConverter(typeof(StringEnumConverter))]
        public TokenEndpointAuthMethod TokenEndpointAuthMethod { get; set; }

        /// <summary>
        /// The client's authentication methods
        /// </summary>
        [JsonProperty("client_authentication_methods")]
        public ClientAuthenticationMethods ClientAuthenticationMethods { get; set; }
    }

    /// <summary>
    /// Structure for a client's authentication methods
    /// </summary>
    public class ClientAuthenticationMethods
    {
        [JsonProperty("private_key_jwt")]
        public PrivateKeyJwt PrivateKeyJwt { get; set; }
    }

    /// <summary>
    /// Structure for credentials using Private Key JWT
    /// </summary>
    public class PrivateKeyJwt
    {
        [JsonProperty("credentials")]
        public IList<CredentialId> Credentials { get; set; }
    }

    /// <summary>
    /// Structure for a client's credential.
    /// </summary>
    /// <remarks>
    /// Only contains the credential's id.
    /// </remarks>
    public class CredentialId
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}