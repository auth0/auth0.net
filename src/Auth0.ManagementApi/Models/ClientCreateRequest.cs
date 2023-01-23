using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Auth0.ManagementApi.Models
{

    /// <summary>
    /// Requests structure for creating a new client.
    /// </summary>
    public class ClientCreateRequest : ClientBase
    {
        /// <summary>
        /// True if the client is a heroku application, false otherwise
        /// </summary>
        [JsonProperty("is_heroku_app")]
        public bool? IsHerokuApp { get; set; }

        /// <summary>
        /// The type of application this client represents
        /// </summary>
        [JsonProperty("app_type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ClientApplicationType ApplicationType { get; set; } = ClientApplicationType.Native;

        /// <summary>
        /// Defines the requested authentication method for the token endpoint.
        /// </summary>
        [JsonProperty("token_endpoint_auth_method")]
        [JsonConverter(typeof(StringEnumConverter))]
        public TokenEndpointAuthMethod? TokenEndpointAuthMethod { get; set; }

        /// <summary>
        /// Defines the client authentication methods to use
        /// </summary>
        [JsonProperty("client_authentication_methods")]
        public CreateClientAuthenticationMethods ClientAuthenticationMethods { get; set; }
    }

    /// <summary>
    /// Structure for creating new client authentication methods
    /// </summary>
    public class CreateClientAuthenticationMethods
    {
        [JsonProperty("private_key_jwt")]
        public CreatePrivateKeyJwt PrivateKeyJwt { get; set; }
    }

    /// <summary>
    /// Structure for creating a new client credential using Private Key JWT
    /// </summary>
    public class CreatePrivateKeyJwt
    {
        [JsonProperty("credentials")]
        public IList<CreateCredential> Credentials { get; set; }
    }

    /// <summary>
    /// Structure for creating a new client credential
    /// </summary>
    public class CreateCredential
    {
        /// <summary>
        /// The type of the credential
        /// </summary>
        [JsonProperty("credential_type")]
        public string CredentialType { get; set; }
        /// <summary>
        /// The name of the credential
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// The value of the credential in PEM format.
        /// </summary>
        [JsonProperty("pem")]
        public string Pem { get; set; }
    }
}