using Newtonsoft.Json;
using System;

namespace Auth0.AuthenticationApi.Models
{
    /// <summary>
    /// Represents the response from signing up a new user.
    /// </summary>
    public class SignupUserResponse
    {
        /// <summary>
        /// The email address of the new user.
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// Indicates whether the email has been verified or not.
        /// </summary>
        /// <value><c>true</c> if the email is verified; otherwise, <c>false</c>.</value>
        [JsonProperty("email_verified")]
        public bool EmailVerified { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the response.
        /// </summary>
        [JsonProperty("_id")]
        public string Id { get; set; }

        /// <summary>
        /// Contains user meta data.
        /// </summary>
        [JsonProperty("user_metadata")]
        public dynamic UserMetadata { get; set; }

        /// <summary>
        /// Gets or sets the user's username.
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
    }
}