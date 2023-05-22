using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.Users
{
    public class AuthenticationMethodUpdateRequest
    {
        /// <summary>
        /// A human-readable label to identify the authentication method.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The preferred authentication method for phone authentication method.
        /// </summary>
        [JsonProperty("preferred_authentication_method")]
        public string PreferredAuthenticationMethod { get; set; }
    }
}

