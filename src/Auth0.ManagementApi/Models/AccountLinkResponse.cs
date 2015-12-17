using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{

    /// <summary>
    /// 
    /// </summary>
    public class AccountLinkResponse
    {

        /// <summary>
        /// The name of the connection for the identity.
        /// </summary>
        [JsonProperty("connection")]
        public string Connection { get; set; }

        /// <summary>
        /// Indicates whether this is a social connection.
        /// </summary>
        [JsonProperty("isSocial")]
        public bool IsSocial { get; set; }

        /// <summary>
        /// The profile data
        /// </summary>
        [JsonProperty("profileData")]
        public AccountLinkResponseProfileData ProfileData { get; set; }

        /// <summary>
        /// The type of identity provider.
        /// </summary>
        [JsonProperty("provider")]
        public string Provider { get; set; }

        /// <summary>
        /// The unique identifier for the user for the identity.
        /// </summary>
        [JsonProperty("user_id")]
        public string UserId { get; set; }

    }

}