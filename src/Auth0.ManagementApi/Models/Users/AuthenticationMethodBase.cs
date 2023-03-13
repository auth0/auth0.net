using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.Users
{
    public class AuthenticationMethodBase
    {
        /// <summary>
        /// The ID of the authentication method (auto generated)
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// The type of the authentication method
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }
	}
}

