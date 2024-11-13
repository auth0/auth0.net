using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.Connections
{
    /// <summary>
    /// Token-based authentication settings to be applied when connection is using an sms strategy.
    /// </summary>
    public class GatewayAuthentication
    {
        /// <summary>
        /// The Authorization header type.
        /// </summary>
        [JsonProperty("method")]
        public string Method { get; set; }
        
        /// <summary>
        /// The subject to be added to the JWT payload.
        /// </summary>
        [JsonProperty("subject")]
        public string Subject { get; set; }
        
        /// <summary>
        /// The audience to be added to the JWT payload.
        /// </summary>
        [JsonProperty("audience")]
        public string Audience { get; set; }
        
        /// <summary>
        /// The secret to be used for signing tokens.
        /// </summary>
        [JsonProperty("secret")]
        public string Secret { get; set; }
        
        /// <summary>
        /// Set to true if the provided secret is base64 encoded.
        /// </summary>
        [JsonProperty("secret_base64_encoded")]
        public bool? SecretBase64Encoded { get; set; }
    }
}