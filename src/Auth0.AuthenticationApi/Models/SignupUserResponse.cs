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
        /// Email address of the new user.
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
        /// Unique identifier of the user.
        /// </summary>
        /// <remarks>
        /// The server can return `_id`, `id` or `user_id` depending on various factors.
        /// For convenience we expose it here as just one.
        /// </remarks>
        public string Id
        {
            get { return _id ?? id ?? user_id; }
            set { _id = value; }
        }

        [JsonProperty("_id")]
        private string _id;        // Standard connection

#pragma warning disable 0649
        [JsonProperty("id")]
        private string id;         // Custom connection

        [JsonProperty("user_id")]
        private readonly string user_id;    // Custom connection external
#pragma warning restore 0649

        /// <summary>
        /// Username of this user.
        /// </summary>
        [JsonProperty("username")]
        public string Username { get; set; }

        /// <summary>
        /// Given name of this user.
        /// </summary>
        [JsonProperty("given_name")]
        public string GivenName { get; set; }

        /// <summary>
        /// Family name of this user.
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
        /// Url to a picture of this user.
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