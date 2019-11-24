using Newtonsoft.Json;
using System;

namespace Auth0.AuthenticationApi.Models
{
    /// <summary>
    /// Represents a request to sign up a new user.
    /// </summary>
    public class SignupUserRequest : UserMaintenanceRequestBase
    {
        /// <summary>
        /// Initial password for this user.
        /// </summary>
        [JsonProperty("password")]
        public string Password { get; set; }

        /// <summary>
        /// Username of this user. Only valid if the connection requires a username.
        /// </summary>
        [JsonProperty("username")]
        public string Username { get; set; }

        /// <summary>
        /// Given name for this user.
        /// </summary>
        [JsonProperty("given_name")]
        public string GivenName { get; set; }

        /// <summary>
        /// Family name for this user.
        /// </summary>
        [JsonProperty("family_name")]
        public string FamilyName { get; set; }

        /// <summary>
        /// Name of this user.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Nickname of this user.
        /// </summary>
        [JsonProperty("nickname")]
        public string Nickname { get; set; }

        /// <summary>
        /// URL to a picture of this user.
        /// </summary>
        [JsonProperty("picture")]
        public Uri Picture { get; set; }

        /// <summary>
        /// Metadata the user has read/write access to. 
        /// </summary>
        [JsonProperty("user_metadata")]
        public dynamic UserMetadata { get; set; }
    }
}