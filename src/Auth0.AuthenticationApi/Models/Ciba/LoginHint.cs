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