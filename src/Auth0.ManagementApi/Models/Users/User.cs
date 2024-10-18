using System;
using System.Collections.Generic;
using Auth0.Core.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// Represents a user as returned from various APIs.
    /// </summary>
    public class User : UserBase
    {
        /// <summary>
        /// Gets or sets the date the user was created.
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// An array of objects with information about the user's identities. More than one will exists in case accounts are linked
        /// </summary>
        [JsonProperty("identities")]
        public Identity[] Identities { get; set; }

        /// <summary>
        /// The last login IP address.
        /// </summary>
        [JsonProperty("last_ip")]
        public string LastIpAddress { get; set; }

        /// <summary>
        /// The last login date for this user.
        /// </summary>
        [JsonProperty("last_login")]
        public DateTime? LastLogin { get; set; }

        /// <summary>
        /// Gets or sets the date the user last reset their password.
        /// </summary>
        [JsonProperty("last_password_reset")]
        public DateTime? LastPasswordReset { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <remarks>
        /// Returned for the Facebook, Google, and Microsoft social providers.
        /// </remarks>
        [JsonProperty("locale")]
        [JsonConverter(typeof(StringOrObjectAsStringConverter))]
        public string Locale { get; set; }

        /// <summary>
        /// The number of logins for this user.
        /// </summary>
        [JsonProperty("logins_count")]
        public string LoginsCount { get; set; }

        /// <summary>
        /// Gets or sets the date the user was last updated (modified).
        /// </summary>
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// A unique identifier of the user per identity provider, same for all apps (e.g.: google-oauth2|103547991597142817347). ALWAYS GENERATED
        /// </summary>
        [JsonProperty("user_id")]
        public string UserId { get; set; }

        /// <summary>
        /// Contains a lists of all the extra provider specific user attributes over and above those contained in the <a href="https://auth0.com/docs/user-profile/normalized">normalized user profile</a>.
        /// </summary>
        [JsonExtensionData]
        public IDictionary<string, JToken> ProviderAttributes { get; set; }

        /// <summary>
        /// Multifactor settings.
        /// </summary>
        [JsonProperty("multifactor")]
        public string[] Multifactor { get; set; }
    }
}
