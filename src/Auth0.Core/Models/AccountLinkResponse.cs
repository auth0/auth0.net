using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Auth0.Core.Models
{
    public class AccountLinkResponse
    {
        /// <summary>
        /// The profile data
        /// </summary>
        [JsonProperty("profileData")]
        public AccountLinkResponseProfiledata ProfileData { get; set; }

        /// <summary>
        /// The name of the connection for the identity.
        /// </summary>
        [JsonProperty("connection")]
        public string Connection { get; set; }

        /// <summary>
        /// The unique identifier for the user for the identity.
        /// </summary>
        [JsonProperty("user_id")]
        public string UserId { get; set; }

        /// <summary>
        /// The type of identity provider.
        /// </summary>
        [JsonProperty("provider")]
        public string Provider { get; set; }

        /// <summary>
        /// Indicates whether this is a social connection.
        /// </summary>
        [JsonProperty("isSocial")]
        public bool IsSocial { get; set; }
    }

    public class AccountLinkResponseProfiledata
    {
        /// <summary>
        /// The email address for the profile.
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// Indicates whether the <see cref="Email"/> is verified.
        /// </summary>
        [JsonProperty("email_verified")]
        public bool EmailVerified { get; set; }
    }
}
