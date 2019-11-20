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
        /// Gets or sets the user's password.
        /// </summary>
        [JsonProperty("password")]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the user's username. Only valid if the connection requires a username.
        /// </summary>
        [JsonProperty("username")]
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the user's given name(s).
        /// </summary>
        [JsonProperty("given_name")]
        public string GivenName { get; set; }

        /// <summary>
        /// Gets or sets the user's family name(s).
        /// </summary>
        [JsonProperty("family_name")]
        public string FamilyName { get; set; }

        /// <summary>
        /// Gets or sets the user's name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the user's nickname.
        /// </summary>
        [JsonProperty("nickname")]
        public string Nickname { get; set; }

        /// <summary>
        /// Gets or sets a uri to the user's picture.
        /// </summary>
        [JsonProperty("picture")]
        public Uri Picture { get; set; }

        /// <summary>
        /// Contains user metadata. The user has read/write access to data.
        /// </summary>
        [JsonProperty("user_metadata")]
        public dynamic UserMetadata { get; set; }
    }
}