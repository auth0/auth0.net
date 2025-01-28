using Newtonsoft.Json;

namespace Auth0.AuthenticationApi.Models.Ciba
{
    /// <summary>
    /// Contains information about the user to contact for authentication.
    /// </summary>
    public class LoginHint
    {
        [JsonProperty("format")]
        public string Format { get; set; }
        
        /// <summary>
        /// Issuer of the ID Token. 
        /// This value should match the 'Issuer' value configured in the well-known configuration.
        /// </summary>
        [JsonProperty("iss")]
        public string Issuer { get; set; }
        
        [JsonProperty("sub")]
        public string Subject { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}