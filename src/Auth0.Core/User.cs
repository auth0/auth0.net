using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace Auth0.Core
{

    /// <summary>
    /// 
    /// </summary>
    //[JsonConverter(typeof(TestConverter))]
    public class User : UserBase
    {

        /// <summary>
        /// Gets or sets the date the user was created.
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// An array of objects with information about the user's identities. More than one will exists in case accounts are linked
        /// </summary>
        [JsonProperty("identities")]
        public Identity[] Identities { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("last_ip")]
        public string LastIpAddress { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("last_login")]
        public DateTime LastLogin { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Returned for the Facebook, Google, and Microsoft social providers.
        /// </remarks>
        [JsonProperty("locale")]
        public string Locale { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("logins_count")]
        public string LoginsCount { get; set; }

        /// <summary>
        /// Gets or sets whether the user's phone number is verified.
        /// </summary>
        /// <remarks>
        /// True if the phone is verified, otherwise false.
        /// 
        /// This is only valid for users from SMS connections.
        /// </remarks>
        [JsonProperty("phone_verified")]
        public bool PhoneVerified { get; set; }

        /// <summary>
        /// Gets or sets the date the user was last updated (modified).
        /// </summary>
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// A unique identifier of the user per identity provider, same for all apps (e.g.: google-oauth2|103547991597142817347). ALWAYS GENERATED
        /// </summary>
        [JsonProperty("user_id")]
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets whether the user is blocked. True if the user is blocked, otherwise false.
        /// </summary>
        [JsonProperty("blocked")]
        public bool Blocked { get; set; }

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

        /// <summary>
        /// The Nickname of the user.
        /// </summary>
        [JsonProperty("nickname")]
        public string NickName { get; set; }

        /// <summary>
        /// The first name of the user (if available).
        /// </summary>
        /// <remarks>
        /// This is the given_name attribute supplied by the underlying API.
        /// </remarks>
        [JsonProperty("given_name")]
        public string FirstName { get; set; }

        /// <summary>
        /// The full name of the user (e.g.: John Foo). ALWAYS GENERATED.
        /// </summary>
        /// <remarks>
        /// This is the name attribute supplied by the underlying API.
        /// </remarks>
        [JsonProperty("name")]
        public string FullName { get; set; }

        /// <summary>
        /// The last name of the user (if available).
        /// </summary>
        /// <remarks>
        /// This is the family_name attribute supplied by the underlying API.
        /// </remarks>
        [JsonProperty("family_name")]
        public string LastName { get; set; }

        /// <summary>
        /// URL pointing to the user picture (if not available, will use gravatar.com with the email). ALWAYS GENERATED
        /// </summary>
        [JsonProperty("picture")]
        public string Picture { get; set; }
    }
    
}