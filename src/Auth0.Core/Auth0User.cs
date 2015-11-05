using System;
using Newtonsoft.Json;

namespace Auth0.Core
{

    /// <summary>
    /// 
    /// </summary>
    public class Auth0User
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("email_verified")]
        public bool EmailVerified { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("picture")]
        public string Picture { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("username")]
        public string UserName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("user_id")]
        public string UserId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("nickname")]
        public string Nickname { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("identities_ids")]
        public string[] IdentitiesIds { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("identities")]
        public Identity[] Identities { get; set; }

        /// <summary>
        /// Data related to the user that does affect the application's core functionality.
        /// </summary>
        [JsonProperty("app_metadata")]
        public AppMetadataBase AppMetadata { get; set; }

        /// <summary>
        /// Data related to the user that does not affect the application's core functionality.
        /// </summary>
        [JsonProperty("user_metadata")]
        public UserMetadataBase UserMetadata { get; set; }
    }
}