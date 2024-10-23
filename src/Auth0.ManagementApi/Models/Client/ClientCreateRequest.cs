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
        
        /// <summary>
        /// JWT-secured Authorization Requests (JAR) settings.
        /// </summary>
        [JsonProperty("signed_request_object")]
        public CreateSignedRequestObject SignedRequestObject { get; set; }
    }
    
    /// <summary>
    /// Structure for creating a new SignedRequestObject
    /// </summary>
    public class CreateSignedRequestObject
    {
        
        /// <summary>
        /// Indicates whether the JAR requests are mandatory
        /// </summary>
        [JsonProperty("required")]
        public bool? Required { get; set; }
        
        /// <summary>
        /// List of <see cref="Credentials"/> for the JAR requests
        /// </summary>
        [JsonProperty("credentials")]
        public IList<CredentialsCreateRequest> Credentials { get; set; }
    }
}